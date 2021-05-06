import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {User} from "../models/user.model";

@Injectable({providedIn: "root"})
export class UserService {
  public API = 'https://localhost:44309';
  public userAPI = this.API + '/user';

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<any> {
    return this.http.get(this.userAPI + '/all')
  }

  save (user: any){
    return this.http.post(this.userAPI + '/add',user)
  }

  getUserById(id: number): Observable<User> {
    return this.http.get<User>(this.userAPI + `/view/${id}`);
  }

}
