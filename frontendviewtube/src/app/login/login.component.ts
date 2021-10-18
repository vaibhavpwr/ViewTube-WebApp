import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MiddleService } from '../middle.service';
import { faVideo } from '@fortawesome/free-solid-svg-icons';
import { AuthServiceService } from '../Services/auth-service.service';
import { LoginUser } from '../Models/loginUser';
import { RegisterUser } from '../Models/registerUser';
import { UserService } from '../Services/user.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {

  formModel = {
    UserId: '',
    Password: ''
  }
  constructor(public service: UserService,private router: Router,  private toastr: ToastrService) { }

  ngOnInit() {
    this.service.formModel.reset();
    if (localStorage.getItem('token') != null)
    {
      this.router.navigateByUrl('/home');
    }
    
  }


  onLogin(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        localStorage.setItem('userId',form.value.UserId);
        this.router.navigateByUrl('/home');
      },
      err => {
        if (err.status == 401)
          this.toastr.error('Incorrect username or password.', 'Authentication failed.');
        else
          console.log(err);
      }
    );
  }

  RegisterNavigate()
  {
    this.router.navigateByUrl('/user/registration');
  }
  }
