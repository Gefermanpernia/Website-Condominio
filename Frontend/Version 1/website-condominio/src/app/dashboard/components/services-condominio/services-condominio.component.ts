import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { map } from 'rxjs/operators';
import { ServiceStatusDTO } from '../../services/DTOs/service-status-dto';
import { ServicesCreationDTO } from '../../services/DTOs/services-creation-dto';
import { ServicesTDTO } from '../../services/DTOs/services-tdto';
import { ServiceStatusService } from '../../services/service-status.service';
import { ServicesTService } from '../../services/services-t.service';

@Component({
  selector: 'app-services-condominio',
  templateUrl: './services-condominio.component.html',
  styleUrls: ['./services-condominio.component.scss'],
})
export class ServicesCondominioComponent implements OnInit, OnDestroy {
  servicesDTO: ServicesTDTO[] = [];
  serviceStatusDTO: ServiceStatusDTO[] = [];
  serviceCreationDTO!: ServicesCreationDTO;
  private serviceTimeout: any;
  private serviceSusbcrition!: Subscription;
  private serviceStatusSubscription!: Subscription;

  serviceForm: FormGroup;
  serviceStatusTimeout: any;
  constructor(
    private servicesTService: ServicesTService,
    private formBuilder: FormBuilder,
    private serviceStatusService: ServiceStatusService
  ) {
    this.serviceForm = formBuilder.group({
      name: ['', { validators: [Validators.required] }],
      serviceStatusId: [, { validators: [Validators.required] }],
    });
  }
  ngOnDestroy(): void {
    if (this.serviceTimeout) {
      clearTimeout(this.serviceTimeout);
    }
    this.serviceSusbcrition?.unsubscribe();
  }

  ngOnInit(): void {
    this.loadServices();
    this.loadServicesStatus();
  }
  /**
   * loadServices
   */
  protected loadServices() {
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
  protected loadServicesStatus() {
    if (this.serviceStatusTimeout) {
      clearTimeout(this.serviceStatusTimeout);
    }
    this.serviceStatusTimeout = setTimeout(() => {
      this.serviceStatusSubscription = this.serviceStatusService
        .getAll()
        .subscribe((data) => {
          this.serviceStatusDTO = data;
        });
    }, 500);
  }
  private _statusId!: number;
  get statusId(): number | undefined {
    return this._statusId;
  }
  set statusId(value: number | undefined) {
    if (value) {
      this._statusId = value;
    }
  }
  isCreating:boolean = false
  createOrUpdate(isUpdate = false, id?: number, model?: ServicesTDTO) {
    if (!this.serviceForm.valid || this.isCreating) {
      return;
    }

    this.isCreating = true;
    this.serviceCreationDTO = this.serviceForm.value;

    if (isUpdate && model && id) {
      this.serviceCreationDTO.serviceStatusId = id;
      this.servicesTService
        .update(this.serviceCreationDTO, model?.id)
        .subscribe(() => {
          this.loadServices();
          model.isEditing = false;
        });
    } else {
      this.servicesTService.create(this.serviceCreationDTO).subscribe(() => {
        this.loadServices();
        this.isCreating = false
      });
    }
  }

  cancelCreation() {
    this.serviceForm.reset();
    this.isEditing = false;
  }
  isEditing: boolean = false;

  deleteSer(id: number) {
    this.servicesTService
      .delete(id)
      .subscribe(
        () => (this.servicesDTO = this.servicesDTO.filter((m) => m.id != id))
      );
  }
}
