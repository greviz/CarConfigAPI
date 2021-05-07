import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Configuration, Part} from "../models/parts.models";
import {Comment} from "../models/comment.model"

@Injectable({providedIn: "root"})
export class ConfigurationService {
  public API = 'https://localhost:44309/configuration';
  public CommentAPI = 'https://localhost:44309/comment'

  constructor(private http: HttpClient) {
  }

  getAllConfigurations(): Observable<Configuration[]> {
    return this.http.get<Configuration[]>(this.API + '/all');
  }

  saveConfiguration(body): Observable<any> {
    console.log(body);
    return this.http.post(this.API + '/save', body);
  }

  getConfigurationById(id: number): Observable<Configuration> {
    return this.http.get<Configuration>(this.API + `/${id}`);
  }

  getConfigurationPartsByConfigurationId(id: number): Observable<Part[]>{
    return this.http.get<Part[]>(this.API + `/${id}/parts`);
  }

  getCommentsForConfigurationId(id: number): Observable<Comment[]>{
    return this.http.get<Comment[]>(this.CommentAPI + `/configuration/${id}`);
  }

  getConfigurationsByUserId(id: number): Observable<Configuration[]>{
    return this.http.get<Configuration[]>(this.API + `/user/${id}`)
  }

  saveCommentForConfigurationId(body): Observable<any>{
    console.log(body);
    return this.http.post(this.CommentAPI + '/add', body);
  }

  getCommentCountByUserId(id: number):Observable<number>{
    return this.http.get<number>(this.CommentAPI + `/count/user/${id}`)
  }
}
