import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { VideoDetails } from '../Models/videoDetails';
import { AuthServiceService } from './auth-service.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FavServiceService {

  favVideoDetails:any;
  
  constructor(private httpclient:HttpClient , private authService:AuthServiceService) { }
  loggedUser = localStorage.getItem("userId");
  addFavVideoEndpoint = "https://localhost:44393/api/FavouriteVideos/add";  
  deleteFavVideoEndpoint = "http://localhost:5001/api/favouriteVideos/delete"


  listOfFavVideos = `https://localhost:44393/api/FavouriteVideos/getUserVideo?userId=`+this.loggedUser;
  apiget = `https://localhost:44380/api/Video/get-videos`;

  public addVideos(videoDetails: VideoDetails){
    let videoData = {"userId": videoDetails.userId, "thumbnail":videoDetails.thumbnail,"videoTitle":videoDetails.videoTitle,"videoId":videoDetails.videoId,"channelTitle":videoDetails.channelTitle}
    console.log(videoData);
    this.favVideoDetails=videoData
    return this.httpclient.post( this.addFavVideoEndpoint,videoData,{
    headers: new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem("token")}`)
  });
  }

  public myfavVideos():Observable<any>{ 
    return this.httpclient.get<any>(this.listOfFavVideos,{
    headers: new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem("token")}`)
  })
 }

/*
 public deleteFavVideos(videoDetails: VideoDetails){
  let videoData = {"userId": videoDetails.userId, "thumbnail":videoDetails.thumbnail,"videoTitle":videoDetails.videoTitle,"videoId":videoDetails.videoId,"channelTitle":videoDetails.channelTitle}
   return this.httpclient.post(this.deleteFavVideoEndpoint,videoData,{responseType: 'text'})
 }*/

}
