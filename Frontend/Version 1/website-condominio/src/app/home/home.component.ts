import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { map } from 'rxjs/operators';
import { ServicesTDTO } from '../dashboard/services/DTOs/services-tdto';
import { ServicesTService } from '../dashboard/services/services-t.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  servicesDTO: ServicesTDTO[] = [];

  private serviceTimeout: any;
  private serviceSusbcrition!: Subscription;
  constructor(private servicesTService: ServicesTService) { }
  ngOnInit(): void {
    this.loadServices();
  }
  ngOnDestroy(): void {
    if (this.serviceTimeout) {
      clearTimeout(this.serviceTimeout);
    }
    this.serviceSusbcrition?.unsubscribe();
  }
  /**
   * loadServices
   */
  public loadServices() {
    if (this.serviceTimeout) {
      clearTimeout(this.serviceTimeout);
    }
    this.serviceTimeout = setTimeout(() => {
      this.serviceSusbcrition = this.servicesTService
        .getAll({})
        .pipe(
          map((data) => {
            return data.map((service) => {
              service.isEditing = false;
              return service;
            });
          })
        )
        .subscribe((data) => {
          this.servicesDTO = data;
        });
    }, 500);
  }


}
