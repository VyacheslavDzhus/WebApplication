import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginDto } from '../models/loginDto';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  public register(user: User): Observable<any>{
    return this.http.post<any>(
      'https://localhost:7084/api/Auth/register',
      user
      );
  }
  public login(user: User): Observable<LoginDto>{
    return this.http.post<any>(
      'https://localhost:7084/api/Auth/login',
      user, 
    );
  }
}
