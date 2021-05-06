import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Car} from "../models/parts.models";

@Injectable({providedIn: "root"})
export class CarService {
  public API = 'https://localhost:44309';
  public userAPI = this.API + '/car';

  constructor(private http: HttpClient) {
  }

  getById(id) {
    return this.http.get<Car>(this.userAPI + `/${id}`);
  }

  getCarByNewIsTrue(): Observable<Car[]>{
    return this.http.get<Car[]>(this.userAPI + '/allnew');
  }

  getCarByNewIsFalse(): Observable<Car[]>{
    return this.http.get<Car[]>(this.userAPI+'/allnew');
  }


}
