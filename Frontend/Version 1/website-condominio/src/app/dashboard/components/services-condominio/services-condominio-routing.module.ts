import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ServicesCondominioComponent } from './services-condominio.component';

const routes: Routes = [{ path: '', component: ServicesCondominioComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ServicesCondominioRoutingModule { }
