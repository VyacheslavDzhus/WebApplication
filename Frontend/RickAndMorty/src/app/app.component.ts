import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'RickAndMorty';
  jwtToken = localStorage.getItem("authToken");
  userName = localStorage.getItem("userName");
  userLastName = localStorage.getItem("userLastName");

  logout(){
    localStorage.removeItem("authToken");
    localStorage.removeItem("userName");
    localStorage.removeItem("userLastName");
    location.href = "http://localhost:4200/";
  }
}
