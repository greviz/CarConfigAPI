import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { CustomMaterialModule} from "./core/material.module";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";

import { registerLocaleData } from '@angular/common';
import localePl from '@angular/common/locales/pl';
import { AlertComponent } from './helpers/alert.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {ColorPickerModule} from "ngx-color-picker";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { RegisterComponent } from './register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LogoutComponent } from './logout/logout.component';
import { CarPickerComponent } from './car-picker/car-picker.component';
import { ConfiguratorComponent } from './configurator/configurator.component';

registerLocaleData(localePl);

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LogoutComponent,
    RegisterComponent,
    DashboardComponent,
    CarPickerComponent,
    ConfiguratorComponent,
    AlertComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    LayoutModule,
    CustomMaterialModule,
    FormsModule,
    NgbModule,
    ColorPickerModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    { provide: LOCALE_ID, useValue: "pl-PL"}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
