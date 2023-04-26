import { Component } from '@angular/core';
import { ApiService } from '../shared/api.service';
import { AuthService } from '../shared/auth.service';
import { UserStoreService } from '../shared/user-store.service';

@Component({
  selector: 'app-nav2',
  templateUrl: './nav2.component.html',
  styleUrls: ['./nav2.component.css']
})
export class Nav2Component {
  public users:any =[];
   public fullname:string = "";
    constructor(private api:ApiService, private auth:AuthService,private userStore:UserStoreService) {}
     ngOnInIt(){
      this.api.getUser()
      .subscribe(res=>{
        this.users = res;
      });
      this.userStore.getFullNameFromStore()
      .subscribe(val=>{
        let fullNameFromToken = this.auth.getFullNameFromToken();
        this.fullname = val || fullNameFromToken
      })
     }
      logout(){
        this.auth.signOut();
       }

}
