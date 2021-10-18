import { SharedService } from './Services/shared.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
//import { RegistrationComponent } from './registration/registration.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';


import { AppRoutingModule } from './app-routing.module';
import { FavouriteComponent } from './favourite/favourite.component';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { VideoSectionComponent } from './video-section/video-section.component';
import { YouTubePlayerModule } from "@angular/youtube-player";
import { VideoplayerComponent } from './videoplayer/videoplayer.component';
import { FavButtonComponent } from './fav-button/fav-button.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { ViewtubedashboardComponent } from './viewtubedashboard/viewtubedashboard.component';





@NgModule({
  declarations: [
    AppComponent,
    //RegistrationComponent,
    HomeComponent,
    LoginComponent,
    FavouriteComponent,
   
    VideoSectionComponent,
    VideoplayerComponent,
    FavButtonComponent,
    SideBarComponent,
    UserComponent,
    RegistrationComponent,
    ViewtubedashboardComponent,
    

  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
    YouTubePlayerModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      progressBar: true
    }) 
    
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
