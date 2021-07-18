import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatToolbarModule} from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

import { ToolbarMenuComponent } from './toolbar-menu.component';


@NgModule({
  declarations: [ToolbarMenuComponent],
  imports: [
    CommonModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule
  ],
  exports:[
    ToolbarMenuComponent
  ]
})
export class ToolbarModule { }
