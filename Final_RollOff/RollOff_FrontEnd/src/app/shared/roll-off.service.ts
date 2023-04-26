import { HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RollOff } from './roll-off.model';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class RollOffService {
  
  constructor(private http:HttpClient) { // contains the object of HttpClient
   }
  formData : RollOff  =new RollOff();
  
  //url:string="https://localhost:44320/RollOff"; // The main API URL.
  getAPI(){ // To fetch the data from the User.
    let apiurl="https://localhost:5001/RollOff";
    return this.http.get(apiurl);  // Where http is HttpClient object, get method to get the data and apiurl the variable name that contains the data. 
  }
  getId(emplyoeeId:string){
    let apiurl="https://localhost:5001/RollOff/"+emplyoeeId;
    return this.http.get(apiurl);
  }
   
}
