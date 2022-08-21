import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Character } from '../models/character';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {

  constructor(private http: HttpClient) { }
   
  public getAll(): Observable<Character[]> {
    return this.http.get<Character[]> ('https://localhost:7084/api/character');
  }
}
