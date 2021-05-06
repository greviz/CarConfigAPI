import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from "@angular/router";
import {UserService} from "../services/user.service";
import {ControlsMustMatch} from "../helpers/must-match.validator";
import {AlertService} from "../services/alert.service";
import {first} from "rxjs/operators";
import {AuthenticationService} from "../services/authentication.service";

@Component({
  selector: 'app-register',
  templateUrl: 'register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  submitted = false;

  constructor(private http: HttpClient,
              private router: Router,
              private userService: UserService,
              private fb: FormBuilder,
              private alertService: AlertService,
              private authenticationService: AuthenticationService )
  {
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(['/dashboard']);
    }
  }

  ngOnInit() {
    this.registerForm = this.fb.group({
        login: ['', Validators.required],
        password: ['', [Validators.required, Validators.minLength(6)]],
        repeatedPassword: ['', [Validators.required, Validators.minLength(6)]],
        email: ['', [Validators.required, Validators.email]],
        username: ['', Validators.required]
      },
      {
        validator: ControlsMustMatch('password', 'repeatedPassword')
      });
  }

  register(){
    this.submitted = true;

    if (this.registerForm.invalid) {
      this.alertService.error("Uzupełnij wymagane pola!", false);
      return;
    }

    this.userService.save(this.registerForm.value).pipe(first()).subscribe(
      data=>{
        this.alertService.success("Rejestracja przebiegła pomyślnie. Możesz się teraz zalogować.", true);
        this.router.navigate(['/login']);
      },
      error=>{
        this.alertService.error("Wystąpił błąd podczas rejestracji! :(", false);
      }
    )

  }

}
