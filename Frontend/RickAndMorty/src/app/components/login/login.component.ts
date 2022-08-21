import { Component, OnInit } from '@angular/core';
import { LoginDto } from 'src/app/models/loginDto';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user = new User();
  
  clearUser(user: User){
    user.lastName = "";
    user.name = "";
    user.login = "";
    user.password = "";
  }

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  login(user: User){
    this.authService.login(user).subscribe((loginDto: LoginDto) => {
      localStorage.setItem('authToken', loginDto.token)
      localStorage.setItem('userName', loginDto.name)
      localStorage.setItem('userLastName', loginDto.lastName)
      this.clearUser(user);
      location.href = "http://localhost:4200/";
    });
  }

}
