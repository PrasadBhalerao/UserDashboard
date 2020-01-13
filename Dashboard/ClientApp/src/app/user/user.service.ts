import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './models';
import { Observable } from 'rxjs';

@Injectable()
export class UserService {
  private _http: HttpClient;
  private _baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  getUsers(): Observable<any> {
    return this._http.get<User[]>(this._baseUrl + 'api/User/GetAll');
  }


}

