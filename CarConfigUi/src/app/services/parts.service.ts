import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import { Observable } from 'rxjs';
import {Part} from "../models/parts.models";


@Injectable({providedIn: "root"})
export class PartsService {
  public API = 'https://localhost:44309';
  public userAPI = this.API + '/parts';

  constructor(private http: HttpClient) {
  }

  public getAvailablePartsByCarId(id): Observable<Part[]>{
    this.http.get<Part[]>(this.userAPI + `/car/${id}`).subscribe(x =>{
      console.log(x);
    })
    return this.http.get<Part[]>(this.userAPI + `/car/${id}`);
  }
}
