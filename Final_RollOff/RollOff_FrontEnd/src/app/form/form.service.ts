import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FormService {

  constructor(private http:HttpClient) { }
  
  createUser(createResource:any){
    console.log(createResource);
    return this.http.post('https://localhost:5001/api/FeedBack',createResource);
  }
}
