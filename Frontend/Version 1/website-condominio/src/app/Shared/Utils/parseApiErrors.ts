export function parseApiErrors(err:any){
  if(err){

  let errors = err["errors"] as any[];

  if(errors){
    let mappedErrors = errors.map(error => {
        let param = error.param;
        let msg = error.msg;

        return `${param ? `${firstLetterUppercase(param)}:` :""}${msg}`;
    });
    return mappedErrors;
  }

}

  return ['Ha ocurrido un error inesperado durante una solicitud'];
}


export function firstLetterUppercase(word:string){

  if(word && word.length >1){
    return word[0].toUpperCase() + word.slice(1);
  }
  return word;
}


export function parseAndJoinApiErrors(err:any):string{
  return parseApiErrors(err).join("<br>");
}

