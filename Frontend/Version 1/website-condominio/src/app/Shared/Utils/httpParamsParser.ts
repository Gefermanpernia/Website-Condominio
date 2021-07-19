import { HttpParams } from "@angular/common/http";

export function addHttpParams(paramObj:any){

  let params = new HttpParams();
  let paramNames  = Object.getOwnPropertyNames(paramObj);

  for(let i=0;i<paramNames.length;i++){
    params = params.append(paramNames[i],paramObj[paramNames[i]]);
  }

  return params;

}
