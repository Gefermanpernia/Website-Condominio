import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ActivityRoutingModule } from './activity-routing.module';
import { ActivityComponent } from './activity.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  declarations: [ActivityComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    ActivityRoutingModule
  ]
})
export class ActivityModule { }
