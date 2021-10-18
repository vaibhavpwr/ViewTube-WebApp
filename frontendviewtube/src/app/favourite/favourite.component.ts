import { Router } from '@angular/router';
import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { MiddleService } from '../middle.service';
import { SharedService } from '../Services/shared.service';
import {FavServiceService} from '../Services/fav-service.service';
import { AuthServiceService } from './../Services/auth-service.service';
@Component({
  selector: 'app-favourite',
  templateUrl: './favourite.component.html',
  styleUrls: ['./favourite.component.css']
})
export class FavouriteComponent implements OnInit {
  
  userFavourites:any;
  favChannelList:any;
  userId:string;
  userData : any;
  videoData:any;
  constructor(  private authservice:AuthServiceService,private favservice:FavServiceService ,private mservice:MiddleService,private router:Router,private share:SharedService) { }
 
  ngOnInit(): void {
   
    this.favservice.myfavVideos().subscribe((data) => {
      this.videoData=data;
      console.log(this.videoData)
    })
  }

  getHome(){
    this.router.navigate(['home'])
  }
  logout(){

    localStorage.clear();
    this.router.navigate(['login'])

  }

}
