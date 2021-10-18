import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  videoIdIs : any
  favVideoList:any =[]
  constructor() { }

  setVideoId(videoId){
    this.videoIdIs = videoId;
  }

  getVideoId(){
    return this.videoIdIs;
  }
  addToFavourite(videoDetails){
    this.favVideoList.push(videoDetails);
  }
  getFavourites(){
   return this.favVideoList;
 }
}
