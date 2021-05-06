import { Component, OnInit } from '@angular/core';
import {User} from "./models/user.model";
import {Router} from "@angular/router";
import {AuthenticationService} from "./services/authentication.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  currentUser: User;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    //console.log(this.currentUser)
  }

  logout() {
    this.authenticationService.logout();
  }

  ngOnInit() {

  }
}