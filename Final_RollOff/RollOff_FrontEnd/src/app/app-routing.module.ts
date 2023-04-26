import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FormComponent } from './form/form.component';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './login/login.component';
import { RollOffDetailsComponent } from './roll-off-details/roll-off-details.component';
import { RollOffFormComponent } from './RollOffDetails/roll-off-form/roll-off-form.component';
import { SignUpComponent } from './sign-up/sign-up.component';

const routes: Routes = [
  {
    path: '',
    component:LoginComponent
  },
  {
    path: 'roll-off-details',
    component: RollOffDetailsComponent, canActivate:[AuthGuard]
  },
  {
    path: 'roll-off-form/:id',
    component: RollOffFormComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent, canActivate:[AuthGuard]
  },
  {
    path: 'sign-up',
    component:SignUpComponent
  },
  {
    path: 'form',
    component:FormComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
