import { Component, OnInit } from '@angular/core';
import {CarService} from "../services/car.service";
import {Car} from "../models/parts.models";
import {Router} from "@angular/router";

@Component({
  selector: 'app-car-picker',
  templateUrl: './car-picker.component.html',
  styleUrls: ['./car-picker.component.css']
})
export class CarPickerComponent implements OnInit {

  public newCars: Car[];
  public usedCars: Car[] = [];

  constructor(private carService: CarService, private router: Router) {
    this.fetchNewCars();
    //this.fetchUsedCars();
  }

  ngOnInit() {


  }

  pickCar(id: number ){
    this.router.navigate(['configurator'],{queryParams: {carId: id}})
  }

  fetchNewCars(){
    this.carService.getCarByNewIsTrue().subscribe((data: Car[]) =>{
      this.newCars = data;
    });
  }

  fetchUsedCars(){
    this.carService.getCarByNewIsFalse().subscribe((data: Car[]) =>{
      this.usedCars = data;
    });
  }
}
