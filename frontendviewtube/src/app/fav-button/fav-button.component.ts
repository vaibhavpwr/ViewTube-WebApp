import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FavServiceService } from '../Services/fav-service.service';
import { FavouriteService } from '../Services/favourite.service';
import { SharedService } from '../Services/shared.service';



@Component({
  selector: 'app-fav-button',
  templateUrl: './fav-button.component.html',
  styleUrls: ['./fav-button.component.css']
})
export class FavButtonComponent implements OnInit {
  @Input() thumbnail : any;
  @Input() videoTitle : any;
  @Input() videoId :any;
  @Input() channelTitle : any;
  @Input() isUserProfile : any;
  @Input() userId:any;
  isFav : boolean = false;
  iconClass : string = "far fa-heart";
  // userId : number ;
  
   videoDetails:any;
  confirmationMessage: string;
  errorMessage: string;
  currentUser: string;
  constructor( private favVideoService:FavServiceService,private shared:SharedService, private toastr: ToastrService, private router: Router,private favService:FavouriteService) { }

  addToFav(userId,thumbnail,videoTitle,channelTitle,videoId){

    var isLoggedIn = localStorage.getItem("userId");
    if(isLoggedIn != null) {
      this.isFav = !this.isFav;
   
      this.isFav ? this.iconClass = "fas fa-heart" : this.iconClass = "far fa-heart"
      this.currentUser = localStorage.getItem("userId");
      var videoDetails = { 
        userId: this.currentUser,
        thumbnail: thumbnail, 
        videoTitle: videoTitle,
        channelTitle : channelTitle,
        videoId : videoId 
     }; 

     this.favVideoService.addVideos(videoDetails)
     .subscribe(response => {
       console.log(response);
       
       if (response) {        
         this.confirmationMessage = 'This Video is Bookmarked';
         //alert("This Video is Bookmarked");
         this.toastr.success('This Video is Bookmarked');

       }
     },
     error => {
      if (error.status === 400) {
        this.errorMessage = 'Video already added';
        this.toastr.error('Video already added');
      }
       else if (error.status === 404) {
         this.errorMessage = 'Unable to access Video server to add this video';
         this.toastr.error('Unable to access Video server to add this video');
       } else if (error.status === 403) {
         this.errorMessage = 'Unauthorized Access !!!';
       } else {
         this.errorMessage = 'Internal Server Error, Please Try Again Later';
       }
     });
      
    }
    else
    {
     // alert("Login first");
      this.router.navigate(['/']);
    }
  }


  ngOnInit(): void {
    console.log(this.userId);
  
  }

}
