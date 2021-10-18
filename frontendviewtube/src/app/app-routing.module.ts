import { VideoplayerComponent } from './videoplayer/videoplayer.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FavouriteComponent } from './favourite/favourite.component';
import { HomeComponent } from './home/home.component';

//import { RegistrationComponent } from './registration/registration.component';

import { AuthGuard } from './Auth/auth.guard';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { ViewtubedashboardComponent } from './viewtubedashboard/viewtubedashboard.component';
import { LoginComponent } from './login/login.component';



const routes: Routes = [
  {path:'',redirectTo:'/login',pathMatch:'full'},
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },

    ]
  },

  {path:"login",component:LoginComponent},
  {path:"viewtubedashboard",component:ViewtubedashboardComponent},

  {path:"home",component:HomeComponent,canActivate:[AuthGuard]},
 
  {path:"favourite",component:FavouriteComponent,canActivate:[AuthGuard]},
  {path:"videoplayer",component:VideoplayerComponent,canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
