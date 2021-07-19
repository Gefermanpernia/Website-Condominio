
export function compareObjProps(source:any, compare:any){

  let sourcePropNames = Object.getOwnPropertyNames(source);
  let comparePropNames= Object.getOwnPropertyNames(compare).filter( p => sourcePropNames.includes(p));;

  let isDifferent = false;
  for(let i=0;i<comparePropNames.length;i++){

    if(source[comparePropNames[i]] != compare[comparePropNames[i]]){

      isDifferent=true;
      break
    }
  }
  return isDifferent;
}
