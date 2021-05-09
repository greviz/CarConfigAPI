import {AfterViewInit, Component, Inject, OnInit, ViewChild, ViewChildren, ViewEncapsulation} from '@angular/core';
import {NgbCarousel} from '@ng-bootstrap/ng-bootstrap';
import {Car, Configuration, Exterior, Interior, Mechanical, Options, Part, secondaryType} from "../models/parts.models";
import {CarService} from "../services/car.service";
import {PartsService} from "../services/parts.service";
import {ActivatedRoute, Router} from "@angular/router";
import {MatCheckbox} from "@angular/material/checkbox";
import {MatRadioButton} from "@angular/material/radio";
import {AuthenticationService} from "../services/authentication.service";
import {User} from "../models/user.model";
import {ConfigurationService} from "../services/configuration.service";
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { DatePipe, formatDate } from '@angular/common';


@Component({
  selector: 'app-configurator',
  templateUrl: './configurator.component.html',
  styleUrls: ['./configurator.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ConfiguratorComponent implements OnInit {

//#region Fields

  private user: User;
  private currentUserConfigurationCount: number;

  cfg: Configuration;
  isPrivate: boolean;

  pickedColor: string = "#F0F0F0";

  generatePreset: boolean;

  carId: number;
  carImages: string[] = [];

  partsPrice: number = 0;
  desc: string;

  private pickedParts: Part[] = [];

  private pickedCar: Car;
  private mechanical: Mechanical = { gearbox:[], suspension:[]};
  interior: Interior = {seats: [],material: []};
  exterior: Exterior = {color: [],rims: [], brakes: []};
  optional: Options = {audio_equipment: [], interior_equipment: [], assisting_systems: []};

  chosenGearbox: Part;
  chosenSuspension: Part;

  chosenRims: Part;
  chosenColor: Part;
  chosenBrakes: Part;

  chosenSeats: Part;
  chosenMaterial: Part;

  chosenAssistingSystems: Part[];
  chosenInteriorEquipment: Part[];
  chosenAudioSystem: Part;
  chosenRadioButtons: Part[] = [];
  parts: Part[];
  previousConfigurationParts: Part[];

//#endregion

  constructor(private carService: CarService,
              private partService: PartsService,
              public dialog: MatDialog,
              private router: Router,
              private route: ActivatedRoute,
              private configurationService: ConfigurationService,
              private authenticationService: AuthenticationService)
  {
    this.user = this.authenticationService.currentUserValue;
  }

  @ViewChild('carousel', {static : true}) carousel: NgbCarousel;

  @ViewChildren(MatCheckbox) public allCheckboxes: MatCheckbox[];

  @ViewChildren(MatRadioButton) public allRadioButtons: MatRadioButton[];

  // popDialog(){
  //   if(this.currentUserConfigurationCount > 0)
  //   {
  //     const dialogRef = this.dialog.open(HelperDialogComponent, {
  //       width: '40%',
  //       data: {name: this.user.username}
  //     });

  //     dialogRef.afterClosed().subscribe(result => {
  //       this.generatePreset = result;
  //     },error1 => {},()=>{
  //       this.setUserPreset();
  //     });
  //   }
  // }

  setCurrentUserConfigurationCount(){
    this.configurationService.getConfigurationsByUserId(this.user.id).subscribe( configs =>{
      this.currentUserConfigurationCount = configs.length;
      //this.popDialog();
    })
  }

  setUserPreset(){
    if(this.generatePreset)
    {
      this.configurationService.getConfigurationsByUserId(this.user.id).subscribe( x =>{
        x.sort((a,b) => a.createdOn - b.createdOn);
        this.cfg = x[0];

      }, error1 => {}, () => {
        this.configurationService.getConfigurationPartsByConfigurationId(this.cfg.id).subscribe(p =>{
          //const order = [  "GEARBOX", "SUSPENSION", "ENGINE", "COLOR", "RIM", "BRAKE", "CAR_SEAT", "INTERIOR_MATERIAL",
          //     "ASSISTING_SYSTEM", "INTERIOR_EQUIPMENT", "AUDIO"];
          //p.sort((a, b) => order.indexOf(a.secondaryType) - order.indexOf(b.secondaryType));
          this.previousConfigurationParts = p;
        },error1 => {},() => { this.setUserPresetParts(this.previousConfigurationParts)
        })
      });
      //this.updatePrice();
    }
  }

  setUserPresetParts(parts: Part[]){
    for(let part of parts){
      switch (part.secondaryType) {
        case "GEARBOX":{
          if(this.mechanical.gearbox.find( x => x.id = part.id)){
            this.chosenGearbox = part;
          }
          break;
        }
        case "SUSPENSION":{
          if(this.mechanical.suspension.find( x => x.id = part.id)){
            this.chosenSuspension = part;
          }
          break;
        }
        case "COLOR":{
          if(this.exterior.color.find( x => x.id = part.id)){
            this.chosenColor = part;
          }
          break;
        }
        case "BRAKE":{
          if(this.exterior.brakes.find( x => x.id = part.id)){
            this.chosenBrakes = part;
          }
          break;
        }
        case "RIM":{
          if(this.exterior.rims.find( x => x.id = part.id)){
            this.chosenRims = part;
          }
          break;
        }
        case "CAR_SEAT":{
          if(this.interior.seats.find( x => x.id = part.id)){
            this.chosenSeats = part;
          }
          break;
        }
        case "INTERIOR_MATERIAL":{
          if(this.interior.material.find( x => x.id = part.id)){
            this.chosenMaterial = part;
          }
          break;
        }
        case "ASSISTING_SYSTEM":{
          if(this.optional.assisting_systems.find( x => x.id = part.id)){
            this.chosenAssistingSystems.push(part);
          }
          break;
        }
        case "INTERIOR_EQUIPMENT":{
          if(this.optional.interior_equipment.find( x => x.id = part.id)){
            this.chosenInteriorEquipment.push(part);
          }
          break;
        }
        case "AUDIO":{
          if(this.optional.assisting_systems.find( x => x.id = part.id)){
            this.chosenAudioSystem = part;
          }
          break;
        }
        default: {
          break;
        }
      }
    }
    this.setChosenRadioButtons();
    this.setCheckedOnInputs();
    this.updatePrice();
  }

  setCheckedOnInputs(){
    this.allCheckboxes.forEach(checkbox =>{
      const helperPart: Part = JSON.parse(JSON.stringify(checkbox.value));

      for (let as of this.chosenAssistingSystems){
        if(as.id == helperPart.id){
          checkbox.checked = true;
        }
      }
      for (let ie of this.chosenInteriorEquipment) {
        if (ie.id == helperPart.id){
          checkbox.checked = true;
        }
      }
    });
    this.allRadioButtons.forEach( rbtn =>{
      let part: Part = JSON.parse(JSON.stringify(rbtn.value));
      for(let p of this.chosenRadioButtons){
        if(p.id == part.id){
          rbtn.checked = true;
        }
      }
    })
  }

  setChosenRadioButtons(){
    this.chosenRadioButtons.push(this.chosenAudioSystem);
    this.chosenRadioButtons.push(this.chosenMaterial);
    this.chosenRadioButtons.push(this.chosenSeats);
    this.chosenRadioButtons.push(this.chosenRims);
    this.chosenRadioButtons.push(this.chosenBrakes);
    this.chosenRadioButtons.push(this.chosenColor);
    this.chosenRadioButtons.push(this.chosenSuspension);
    this.chosenRadioButtons.push(this.chosenGearbox);
  }

  resetCheckbox(){
    this.allCheckboxes.forEach(checkbox =>{
      checkbox.checked = false;
    });
    this.allRadioButtons.forEach( rbtn =>{
      for(let p of this.parts){
        if(p.price == 0){
          rbtn.checked = true;
        }
      }
    })
  }

  ngOnInit() {
    this.route.queryParamMap.subscribe(params =>{
      this.carId = Number.parseInt(params.get('carId'));
      this.setPickedCar(this.carId);
      this.fetchParts(this.carId);
      this.setCurrentUserConfigurationCount();
    },
        error1 => {

    },()=>{
      });
  }

  getPickedParts(){
    this.pickedParts.push(this.chosenSeats);
    this.pickedParts.push(this.chosenAudioSystem);
    this.pickedParts.push(this.chosenRims);
    this.pickedParts.push(this.chosenColor);
    this.pickedParts.push(this.chosenGearbox);
    this.pickedParts.push(this.chosenSuspension);
    this.pickedParts.push(this.chosenBrakes);
    this.pickedParts.push(this.chosenMaterial);
    for(let p of this.chosenInteriorEquipment){
      this.pickedParts.push(p)
    }
    for(let p of this.chosenAssistingSystems){
      this.pickedParts.push(p)
    }
  }

  assignParts(parts: Part[]){
    console.log(parts)
    for (let p of parts)
    {
      switch (p.secondaryType) {
        case secondaryType.GEARBOX: {
          this.mechanical.gearbox.push(p);
          break;
        }
        case secondaryType.SUSPENSION: {
          this.mechanical.suspension.push(p);
          break;
        }
        case secondaryType.BRAKE:{
          this.exterior.brakes.push(p);
          break;
        }
        case secondaryType.COLOR:{
          this.exterior.color.push(p);
          break;
        }
        case secondaryType.RIM:{
          this.exterior.rims.push(p);
          break;
        }
        case secondaryType.CAR_SEAT:{
          this.interior.seats.push(p);
          break;
        }
        case secondaryType.INTERIOR_MATERIAL:{
          this.interior.material.push(p);
          break;
        }
        case secondaryType.ASSISTING_SYSTEM:{
          this.optional.assisting_systems.push(p);
          break;
        }
        case secondaryType.INTERIOR_EQUIPMENT:{
          this.optional.interior_equipment.push(p);
          break;
        }
        case secondaryType.AUDIO:{
          this.optional.audio_equipment.push(p);
          break;
        }
        default:{ console.log("ERROR IN READING PARTS!")
                   break;}
      }
    }
    console.log(this.mechanical.suspension)
    this.setDefaultRadioButtons()
  }

  fetchParts(carId: number){
    this.partService.getAvailablePartsByCarId(carId).subscribe(data =>{
      console.log(data)
      this.parts = data;
      console.log(this.parts)
      this.assignParts(data);
    });
  }

  setPickedCar(id: number){
    this.carService.getById(id).subscribe((data: Car) =>{
      this.pickedCar = data;
      this.loadImages(this.pickedCar.imageFolder);
    })
  }

  updatePrice(){
    this.partsPrice = 0;
    if(this.interior.seats.length != 0)
      this.partsPrice += this.chosenSeats.price;
    if(this.interior.material.length != 0)
      this.partsPrice += this.chosenMaterial.price;
    if(this.exterior.rims.length != 0)
      this.partsPrice += this.chosenRims.price;
    if(this.exterior.brakes.length != 0)
      this.partsPrice += this.chosenBrakes.price;
    if(this.exterior.color.length != 0)
      this.partsPrice += this.chosenColor.price;
    if(this.mechanical.suspension.length != 0)
      this.partsPrice += this.chosenSuspension.price;
    if(this.mechanical.gearbox.length != 0)
      this.partsPrice += this.chosenGearbox.price;
    if(this.optional.audio_equipment.length != 0)
      this.partsPrice += this.chosenAudioSystem.price;

    for(let a of this.chosenAssistingSystems)
    {
      this.partsPrice += a.price;
    }
    for(let i of this.chosenInteriorEquipment)
    {
      this.partsPrice += i.price;
    }

  }

  chooseAssistingSystems(assist){
    let element = this.chosenAssistingSystems.find(a=> a.id === assist.id);
    if(element) {
      this.chosenAssistingSystems.splice(this.chosenAssistingSystems.indexOf(element),1)
    } else {
      this.chosenAssistingSystems.push(assist);
    }
    if(this.chosenAssistingSystems)
      this.updatePrice();
  }

  chooseInteriorEquipment(ie){
    let element = this.chosenInteriorEquipment.find(i => i.id === ie.id);
    if(element) {
      this.chosenInteriorEquipment.splice(this.chosenInteriorEquipment.indexOf(element), 1)
    } else {
      this.chosenInteriorEquipment.push(ie);
    }
    if(this.chosenAssistingSystems)
      this.updatePrice();
  }

  loadImages(path: string) {
    for(let i=0; i<3;i++){
      let image = path + `/${this.pickedCar.brand.toLowerCase()}_${this.pickedCar.model.toLowerCase()}_${i}.jpg`;
      this.carImages.push(image);
    }
  }

  setDefaultRadioButtons(){
    this.sortPartsByPrice();
    console.log(this.mechanical.suspension)
    if(this.mechanical.gearbox.length != 0){
      this.chosenGearbox = this.mechanical.gearbox.find(x => x.price == 0);
    }
    if(this.mechanical.suspension.length != 0){
      this.chosenSuspension = this.mechanical.suspension.find(x => x.price == 0);
    }
    if(this.exterior.brakes.length != 0){
      this.chosenBrakes = this.exterior.brakes.find(x => x.price == 0);
    }
    if(this.interior.material.length != 0){
      this.chosenMaterial = this.interior.material.find(x => x.price == 0);
    }
    if(this.exterior.rims.length != 0){
      this.chosenRims = this.exterior.rims.find(x => x.price == 0);
    }
    if(this.interior.seats.length != 0){
      this.chosenSeats = this.interior.seats.find(x => x.price == 0);
    }
    if(this.exterior.color.length != 0){
      this.chosenColor = this.exterior.color.find(x => x.price == 0);
    }
    if(this.optional.audio_equipment.length != 0){
      this.chosenAudioSystem = this.optional.audio_equipment.find(x => x.price == 0);
    }

    this.chosenAssistingSystems = [];
    this.chosenInteriorEquipment = [];
    this.updatePrice();
  }

  sortPartsByPrice(){
    this.mechanical.gearbox.sort((a,b)=> a.price - b.price );
    this.mechanical.suspension.sort((a,b) => a.price - b.price);
    this.exterior.rims.sort((a,b)=> a.price - b.price );
    this.exterior.color.sort((a,b) => a.price - b.price);
    this.exterior.brakes.sort((a,b)=> a.price - b.price );
    this.interior.material.sort((a,b) => a.price - b.price);
    this.interior.seats.sort((a,b)=> a.price - b.price );
    this.optional.audio_equipment.sort((a,b) => a.price - b.price );
  }

  save(){
    const requestBody ={
      TotalPrice: this.pickedCar.price + this.partsPrice,
      //createdOn: formatDate(Date.now(), ),d
      Description: this.desc,
      CreatedByNavigation: this.user,
      Car: this.pickedCar,
      ConfigurationParts: this.pickedParts,
      Private: this.isPrivate,
    };

    this.configurationService.saveConfiguration(requestBody).subscribe(
      x => this.router.navigate(['preview'], { queryParams: {configId: x} }),
        error1 => console.error(error1)
    );
  }

}

// @Component({
//   selector: 'helper-dialog',
//   templateUrl: './helper-dialog.html'
// })
// export class HelperDialogComponent {
//   constructor(
//     public dialogRef: MatDialogRef<HelperDialogComponent>,
//     @Inject(MAT_DIALOG_DATA) public data: DialogData) {}
// }

// export interface DialogData {
//   name: string;
// }
