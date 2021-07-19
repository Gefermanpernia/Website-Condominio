export function parseObjProps(source:any,destination:any){
  let propsSource =  Object.getOwnPropertyNames(source);
  for(let i=0;i<propsSource.length;i++){
    if(source[propsSource[i]] ||  source[propsSource[i]] ===false){

      destination[propsSource[i]] = source[propsSource[i]]
    }
  }
  return destination;
}
