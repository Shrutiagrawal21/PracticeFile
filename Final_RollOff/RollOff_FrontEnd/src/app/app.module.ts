import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SearchComponent } from './search/search.component';
import { RollOffDetailsComponent } from './roll-off-details/roll-off-details.component';
import { RollOffFormComponent } from './RollOffDetails/roll-off-form/roll-off-form.component';
import { LoginComponent } from './login/login.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { SearchPipe } from './roll-off-details/search.pipe';
import { SignUpComponent } from './sign-up/sign-up.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TokenInterceptor } from './interceptor/token.interceptor';
import { AuthService } from './shared/auth.service';
import { JwtModule } from '@auth0/angular-jwt';
import { FormComponent } from './form/form.component';
import { NavbarComponent } from './form/navbar/navbar.component';
import { Nav2Component } from './nav2/nav2.component';

export function tokenGetter(){
  return localStorage.getItem("token");
}
@NgModule({
  declarations: [
    AppComponent,
    SearchComponent,
    RollOffDetailsComponent,
    RollOffFormComponent,
    LoginComponent,
    SearchPipe,
    SignUpComponent,
    DashboardComponent,
    FormComponent,
    NavbarComponent,
    Nav2Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxPaginationModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:tokenGetter,
        allowedDomains : ["localhost:14342"],
        disallowedRoutes:[]
      }
    })
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true
  },
  AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
