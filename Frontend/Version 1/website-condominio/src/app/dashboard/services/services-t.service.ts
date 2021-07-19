import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseCrudService } from 'src/app/Shared/Utils/baseCrudMethods';
import { ServicesCreationDTO } from './DTOs/services-creation-dto';
import { ServicesFilterDTO } from './DTOs/services-filter-dto';
import { ServicesTDTO } from './DTOs/services-tdto';

@Injectable({
  providedIn: 'root',
})
export class ServicesTService extends BaseCrudService<
  ServicesCreationDTO,
  ServicesTDTO,
  ServicesFilterDTO
> {
  constructor(httpClient: HttpClient) {
    super(httpClient, 'Service');
  }
}
