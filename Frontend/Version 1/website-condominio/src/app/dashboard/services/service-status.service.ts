import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ServiceStatusDTO } from './DTOs/service-status-dto';

@Injectable({
  providedIn: 'root'
})
export class ServiceStatusService {
  private baseUrl = environment.apiUrl + 'StatusService'
  constructor(private httpClient:HttpClient) { }

  getAll():Observable<ServiceStatusDTO[]>{
    return this.httpClient.get<ServiceStatusDTO[]>(`${this.baseUrl}`);
  }
}
