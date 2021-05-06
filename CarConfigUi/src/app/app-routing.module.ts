import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarPickerComponent } from './car-picker/car-picker.component';
import { ConfiguratorComponent } from './configurator/configurator.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './helpers/auth.guard';
import {LoginComponent} from "./login/login.component";
import { LogoutComponent } from './logout/logout.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path:"login", component:LoginComponent},
  { path:"logout", component:LogoutComponent},
  { path:"register", component:RegisterComponent},
  { path:"dashboard", component:DashboardComponent, canActivate:[AuthGuard]},
  { path:"configurator", component:ConfiguratorComponent, canActivate:[AuthGuard]},
  { path:"carpicker", component:CarPickerComponent, canActivate:[AuthGuard]},
  { path:'', component:LoginComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
