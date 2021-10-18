import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {environment} from '../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {
  cat:any
   public videoID:any;
  API_KEY= environment.apiKey;

  constructor(private httpservice:HttpClient) { }
 getPopularVideos():Observable<any>{
  
   const url="https://localhost:44380/api/Video/get-videos"
    return this.httpservice.get<any>(url);
  }
  searchVideosService(text){
    const url="https://localhost:44380/api/Video/search?searchText="+text;
  return this.httpservice.get<any>(url);
  }

  categoryChannels(cID){
    const url="https://localhost:44380/api/Video/get-tendings?categoryId="+cID;
    return this.httpservice.get<any>(url);
  }

  loggedUser = localStorage.getItem("userId")
  listOfFavVideos = `https://localhost:44393/api/FavouriteVideos/getUserVideo?userId=`+this.loggedUser;

  public myfavVideos():Observable<any>{ 
    return this.httpservice.get<any>(this.listOfFavVideos,{
     headers: new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem("token")}`)
   })
  }


}