import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  user = new User();

  constructor(private authService: AuthService) {}

  clearUser(user: User){
    user.lastName = "";
    user.name = "";
    user.login = "";
    user.password = "";
  }
  
  register(user: User){
    this.authService.register(user).subscribe();
    this.clearUser(user);
    location.href = "http://localhost:4200/";
  }

  ngOnInit(): void {
  }

}
