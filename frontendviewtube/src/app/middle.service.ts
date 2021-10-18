import { Injectable } from '@angular/core';
import { LoginUser } from './Models/loginUser';

@Injectable({
  providedIn: 'root'
})
export class MiddleService {
 users:any[]=[];
 //user:LoginUser=new LoginUser();
 public favLink:any[]=[];
  constructor() { }
   getUsers(){
    console.log(this.users);
    return this.users;
   }
   addFav(channel){
     this.favLink.push(channel);

   }
  getFav(){
    return this.favLink;
  }
  

}
