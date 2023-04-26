import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { UserStoreService } from '../shared/user-store.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
 
  type:string ="password";
  isText:boolean=false;
  eyeIcon:string="fa-eye-slash";
  loginForm!: FormGroup;

  constructor(private _http: HttpClient, private router: Router,private auth:AuthService,private userStore:UserStoreService) { }

 

  hideShowPass(){
      this.isText = !this.isText;
      this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon ="fa-eye-slash";
      this.isText ? this.type= "text" : this.type="password";
  }

  

  
  
       
        ngOnInit(): void {
         this.loginForm = new FormGroup({
            userName: new FormControl('', [Validators.required,]),  //required validator to controls marked with required attribute
            password: new FormControl('',[Validators.required,Validators.minLength(8),Validators.maxLength(12)]),
          });  //callback method invoked immediatly after default change detectore
        }

        
       
       

              onLogin(){  
                if(this.loginForm.valid){
                  this.auth.login(this.loginForm.value)
                  .subscribe({
                    next:(res=>{
                      alert(res.message);
                      this.loginForm.reset();
                      this.auth.storeToken(res.token);
                      let tokenPayload  =  this.auth.decodedToken();
                      this.userStore.setFullNameFormStore(tokenPayload.name);
                      this.userStore.setRoleForStore(tokenPayload.role);
                      this.router.navigate(['roll-off-details']);

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
              
              

      get userName():FormControl
       {
          return this.loginForm.get("userName") as FormControl;
       }

       get password():FormControl
       {
          return this.loginForm.get("password") as FormControl;
       }
}
