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

  getUsers(username: string): Observable<any> {
    let url = this._baseUrl + 'api/Users';
    if (username) {
      url += '/';
      url += username;
    }
    return this._http.get<User[]>(url);
  }

  deleteUser(userId: number): Observable<any> {
    return this._http.delete(this._baseUrl + 'api/User/Delete/' + userId);
  }

  updateUser(user: User): Observable<any> {
    return this._http.put(this._baseUrl + 'api/User/Save', user);
  }
}

