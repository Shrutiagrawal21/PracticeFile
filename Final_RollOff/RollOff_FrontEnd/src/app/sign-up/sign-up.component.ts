import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent {
  type:string ="password";
  isText:boolean=false;
  eyeIcon:string="fa-eye-slash";
  registerform!:FormGroup;
    
  constructor(
      private http: HttpClient,
      private auth:AuthService,
      private router:Router
  ){}

     ngOnInit(): void {
      this.registerform = new FormGroup({
        firstName: new FormControl(''),
        lastName: new FormControl(''),
        userName: new FormControl(''),
        email: new FormControl(''),
        password: new FormControl(''),
        role: new FormControl(''),
      });
  
    }

   
    submitForm(){  
      if(this.registerform.valid){
        this.auth.signUp(this.registerform.value)
        .subscribe({
          next:(res=>{
            alert(res.message)
            this.registerform.reset();
            this.router.navigate(['login'])
          }),
          error:(err=>{
            alert(err.error.message)
          })
  
        })
      }

        
      }

      private validateAllFormFields(formGroup:FormGroup){
        Object.keys(formGroup.controls).forEach(field =>{
          const control =formGroup.get(field)
          if(control instanceof FormControl){
            control.markAsDirty({onlySelf:true});
          }else if(control instanceof FormGroup){
            this.validateAllFormFields(control)
          }
        })
      }
    

  hideShowPass(){
      this.isText = !this.isText;
      this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon ="fa-eye-slash";
      this.isText ? this.type= "text" : this.type="password";
  }
}
