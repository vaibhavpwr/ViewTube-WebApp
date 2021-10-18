import { AuthServiceService } from './../Services/auth-service.service';
import { Component, OnInit,Input } from '@angular/core';
import { ApiServiceService } from '../api-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent implements OnInit {
  videosByCategory:any;
  
  
  constructor(private service:ApiServiceService,private authservice:AuthServiceService,private router:Router) { }

  ngOnInit(): void {
  }
  
category(id) {
  this.service.categoryChannels(id).subscribe((data) => {
    console.log('got videos by category', data);
    this.videosByCategory = data.items;
  });
 
}

// goHome(){
//   this.isUserProfile = true;
// }

// userprofile() {
  
//   this.authservice.getUser().subscribe(
//     (res: any) => {
//   //     //var name = sessionStorage.setItem('name');

//      // this.isUser = true;
//      //this.isUserProfileThere = false;
//       this.router.navigate(['userprofile'])
//     // },
//     // (error: any) => {
//     //   console.log(error);
//     }
//   )
  
// }

}
