import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.prod';
import { buildFormData } from './formDataBuilder';
import { addHttpParams } from './httpParamsParser';
export class BaseCrudService<creationDTO, exposeDTO, filtersObj> {
  constructor(protected httpClient: HttpClient, private urlSection: string) {}
  baseUrl = environment.apiUrl;

  getAll(filterDTO: filtersObj) {
    let params = addHttpParams(filterDTO);
    return this.httpClient.get<exposeDTO[]>(
      `${this.baseUrl}${this.urlSection}`,
      { params }
    );
  }

  getById(id: number) {
    return this.httpClient.get<exposeDTO>(
      `${this.baseUrl}${this.urlSection}/${id}`
    );
  }

  create(createDTO: creationDTO, isFormData: boolean = false) {
    let formData;
    if (isFormData) {
      formData = buildFormData(createDTO);
    }
    return this.httpClient.post(
      `${this.baseUrl}${this.urlSection}`,
      isFormData ? formData : createDTO
    );
  }
  update(createDTO: creationDTO, id: number, isFormData: boolean = false) {
    let formData;
    if (isFormData) {
      formData = buildFormData(createDTO);
    }

    return this.httpClient.put(
      `${this.baseUrl}${this.urlSection}/${id}`,
      isFormData ? formData : createDTO
    );
  }

  delete(id: number) {
    return this.httpClient.delete(`${this.baseUrl}${this.urlSection}/${id}`);
  }
}
