import { ApiServiceService } from './../api-service.service';
import { Router } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from '../Services/shared.service';
import { faHeart } from '@fortawesome/free-solid-svg-icons';
import { AuthServiceService } from '../Services/auth-service.service';
import { FavouriteService } from '../Services/favourite.service';
import { Video } from '../Models/video';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-video-section',
  templateUrl: './video-section.component.html',
  styleUrls: ['./video-section.component.css']
})
export class VideoSectionComponent implements OnInit {
  @Input() thumbnail : any;
  @Input() videoTitle : any;
  @Input() videoId :any;
  @Input() channelTitle : any;
  @Input() isUserProfile : any;
  @Input() videoItem: any;
  isFav : boolean = false;
  iconClass : string = "far fa-heart";
  
  userDetails:any;
  singleUser:any;
  confirmationMessage: string;
  errorMessage: string;
  constructor(private router:Router,private authService:AuthServiceService,private shared:SharedService,private toastr: ToastrService,private favService:FavouriteService) { }

  
  handleCick(){
    
    let vid = this.videoId;
    this.shared.setVideoId(vid)
    this.router.navigate(['videoplayer'])
   
  }

  clicked()
  {
    this.toastr.success('This Video is Bookmarked');
  }
  
  ngOnInit(): void {
  
  }


}
