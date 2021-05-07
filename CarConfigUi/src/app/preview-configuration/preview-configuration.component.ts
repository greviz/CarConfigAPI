import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";
import {Car, Configuration, Part} from "../models/parts.models";
import {ConfigurationService} from "../services/configuration.service";
import {User} from "../models/user.model";

@Component({
  selector: 'app-preview-configuration',
  templateUrl: './preview-configuration.component.html',
  styleUrls: ['./preview-configuration.component.css']
})
export class PreviewConfigurationComponent implements OnInit {

  configId: number;
  public configuration: Configuration;
  private configuredBy: User;
  private configuredCar: Car;
  private configurationParts: Part[];

  constructor(private http: HttpClient,
              private route: ActivatedRoute,
              private configurationService: ConfigurationService
              ) {
    this.route.queryParamMap.subscribe(params =>{
      this.configId = Number.parseInt(params.get('configId'));
      this.getConfiguration(this.configId);
      this.getParts(this.configId);
    });
  }

  ngOnInit() {

  }

  getConfiguration(id: number){
    this.configurationService.getConfigurationById(id).subscribe( c => {
      this.configuration = c;
      this.configuredBy = c.user;
      this.configuredCar = c.car;
    });
  }
  getParts(id: number){
    this.configurationService.getConfigurationPartsByConfigurationId(id).subscribe(parts =>{

      const order = ['MECHANICAL','EXTERIOR','INTERIOR', 'OPTIONAL'];
      parts.sort((a, b) => order.indexOf(a.primaryType) - order.indexOf(b.primaryType));

      this.configurationParts = parts;
    })
  }


}
