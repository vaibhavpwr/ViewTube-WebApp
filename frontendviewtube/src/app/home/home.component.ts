import { AuthServiceService } from './../Services/auth-service.service';
import { HttpClient, HttpClientModule, HttpHandler } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ApiServiceService } from '../api-service.service';
import { MiddleService } from '../middle.service';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FavServiceService } from '../Services/fav-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  faUser = faUser;
  @ViewChild('channelName') channelName: ElementRef;
  @ViewChild('categoryChannel') categoryChannel: ElementRef;
  popularVideos: any
  //cat: any = []
  isHOme : boolean = true;
  catChannl:any;
  cID: any = [];
  searchedVideos: any;
  videosByCategory : any;
  //isUser : boolean = false;
  videoData:any;
  constructor(private http: HttpClient,private authservice:AuthServiceService, private favservice:FavServiceService, private service: ApiServiceService, private router: Router, private mservice: MiddleService) {
  }
  //email : any = sessionStorage.getItem("email");


  ngOnInit(): void {

    this.service.getPopularVideos().subscribe(
      (data) => {
        console.log("fetching all channels{10}", data);
        this.popularVideos = data.items;
      }
    );
  // testing
  this.service.categoryChannels(this.cID).subscribe((data)=>{
    console.log("category channels:",data)
    this.catChannl=data.items;
    console.log(this.catChannl);
  });


  this.favservice.myfavVideos().subscribe((data) => {
    this.videoData=data;
    console.log(this.videoData)
  })

}

  searchVideos() {
    let channelName = this.channelName.nativeElement.value;
    this.service.searchVideosService(channelName).subscribe((data) => {
      console.log("searched channels", data);
      this.searchedVideos = data.items;
    })
  }

  category(id){
    this.service.categoryChannels(id).subscribe((data) => {
      console.log("got videos by category", data);
      this.videosByCategory = data.items;
      
    })
  }


  //  getFavourites(){
  //    this.router.navigate(['favourite'])
  //  }

    onLogout() {
      localStorage.removeItem('token');
      localStorage.removeItem('userId');
      this.router.navigate(['/login']);
    window.location.reload();

    }
}
