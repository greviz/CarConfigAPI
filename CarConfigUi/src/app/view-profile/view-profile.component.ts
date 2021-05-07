import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";
import {AuthenticationService} from "../services/authentication.service";
import {User} from "../models/user.model";
import {UserService} from "../services/user.service";
import {Configuration} from "../models/parts.models";
import {ConfigurationService} from "../services/configuration.service";

@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css']
})
export class ViewProfileComponent implements OnInit {

  userId: number;
  userToPreview: User;
  private userConfigurations: Configuration[];
  private userCommentCount: number;

  constructor(private http: HttpClient,
              private route: ActivatedRoute,
              private userService: UserService,
              private confService: ConfigurationService,
              private authService: AuthenticationService,) {
                  this.getUserToPreview();
  }

  getConfigurationsByUser(id:number){
    this.confService.getConfigurationsByUserId(id).subscribe( c =>{
        this.userConfigurations = c;
        this.getUserCommentCount(id);
      }
    )
  }
  getUserToPreview(){
    this.route.queryParamMap.subscribe( params=>{
      this.userId = Number.parseInt(params.get("userId"));
      this.getConfigurationsByUser(this.userId);
      this.userService.getUserById(this.userId).subscribe( user => {
          this.userToPreview = user;
        },
        error =>{
          console.log(error)
        })
    })
  }
  getUserCommentCount(id: number){
    this.confService.getCommentCountByUserId(id).subscribe( count =>{
      this.userCommentCount = count;
    })
  }

  ngOnInit() { }

}
