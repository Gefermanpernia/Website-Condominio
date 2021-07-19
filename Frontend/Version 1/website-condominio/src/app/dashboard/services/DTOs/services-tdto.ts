import { ServiceStatusDTO } from "./service-status-dto";

export interface ServicesTDTO {
  id:            number;
  name:          string;
  serviceStatus: ServiceStatusDTO;
  isEditing?: boolean;
}
