import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Video } from '../Models/video';
import { AuthServiceService } from './auth-service.service';
import { VideoDetails } from '../Models/videoDetails';

@Injectable({
  providedIn: 'root'
})
export class FavouriteService {

  video_api_url:string = `http://localhost:3000/Videos`

  constructor(private httpClient: HttpClient, private authService: AuthServiceService) {
   

   }

  public addVideo(videoItem: Video): Observable<Video> {
    return this.httpClient.post<Video>(this.video_api_url, videoItem,{
      headers: new HttpHeaders().set('Authorization', `Bearer ${this.authService.getBearerToken()}`)
    });
  }
  

}
