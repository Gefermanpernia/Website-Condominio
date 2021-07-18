import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthlayoutComponent } from './authlayout/authlayout.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [

  {
    path:'',
    component:AuthlayoutComponent,
    children:[
      {
        component:LoginComponent,
        path:'login'

      },
      {
        component:RegisterComponent,
        path:'register'
      },
      {
        path:'',
        pathMatch:'full',
        redirectTo:'auth/login'
      },
      {
        path:'**',
        pathMatch:'full',
        redirectTo:'auth/login'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
