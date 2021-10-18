import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  constructor(private httpclient:HttpClient) { }
  
  getBearerToken(): string{
    return localStorage.getItem('authToken');
  }
}
