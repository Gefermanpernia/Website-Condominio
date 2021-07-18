import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { ToolbarModule } from '../Shared/toolbar/toolbar.module';
import { DashboardLayoutComponent } from './dashboard-layout/dashboard-layout.component';
import { SidebarModule } from '../Shared/sidebar/sidebar.module';


@NgModule({
  declarations: [DashboardLayoutComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    ToolbarModule,
    SidebarModule
  ]
})
export class DashboardModule { }
