import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  private baseUrl:string ="https://localhost:5001/api/User";
  private userPayload:any;

  constructor(private http:HttpClient,private router:Router) {
    this.userPayload = this.decodedToken();
   }
   
  signUp(userObj:any){
    
    return this.http.post<any>(`${this.baseUrl}/Register`,userObj)
  }

  login(userlogin:any){
    return this.http.post<any>(`${this.baseUrl}/authenticate`,userlogin)
  }

  signOut(){
    localStorage.clear();
    this.router.navigate(['']);
    
  }

  storeToken(tokenvalue:string){
    localStorage.setItem('token',tokenvalue)
  }
  getToken(){
    return localStorage.getItem('token');
  }
  isLoggedIn():boolean{
    return !!localStorage.getItem('token');
  }
 decodedToken(){
  const jwtHelper = new JwtHelperService();
  const token = this.getToken()!;
  console.log(jwtHelper.decodeToken(token));
  return jwtHelper.decodeToken(token)
 }

 getFullNameFromToken(){
  if(this.userPayload){
    return this.userPayload.name;
  }
 }

 getRoleFromToken(){
  if(this.userPayload){
    return this.userPayload.role;
  }
 }
}
