import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-registration',
  templateUrl:'./registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserService,private router: Router,  private toastr: ToastrService) { }

  ngOnInit(): void {
  }


  onSubmit() 
  {
    this.service.register().subscribe(
      (res: any) => 
      {
        if (res) {
          this.service.formModel.reset();        
          this.toastr.success('New user created!', 'Registration successful.');
          console.log("Succesfully registered");
        }  
        else {
          res.errors.forEach(element => 
            {
            switch (element.code) 
            {
              case 'fails':
                this.toastr.error('Registration failed.');
                break;
              default:
              this.toastr.error(element.description,'Registration failed.');
                break;
            }
          });
        }
      },
        err =>
        {
          console.log(err);
          this.toastr.error('Please fill the feilds');
        }
    );
  }

  loginNavigate()
  {
    this.router.navigateByUrl('/login');
  }
}
