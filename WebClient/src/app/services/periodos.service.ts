import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PeriodosService {

  url = environment.URL_SER_NODE;

  constructor(private _http: HttpClient) { }

  getPeriodos(){
    return this._http.get<any[]>(this.url+'api/Periodos/GetPeriodos');
  }

  deletePeriodo(id: any){
    return this._http.delete<any[]>(this.url+`api/Periodos/DeletePeriodo/${id}`);
  }

  addPeriodo(Periodo: any){
    return this._http.post<any[]>(this.url+'api/Periodos/AddPeriodo', Periodo);
  }

  getPeriodoById(id: any){
    return this._http.get<any[]>(this.url+`api/Periodos/GetPeriodoById/${id}`);
  }

  updatePeriodo(Periodo: any){
    return this._http.put<any[]>(this.url+'api/Periodos/UpdatePeriodo', Periodo);
  }
}
