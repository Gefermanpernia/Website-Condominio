import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ServicesCondominioRoutingModule } from './services-condominio-routing.module';
import { ServicesCondominioComponent } from './services-condominio.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';


@NgModule({
  declarations: [ServicesCondominioComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    ServicesCondominioRoutingModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule
  ]
})
export class ServicesCondominioModule { }
