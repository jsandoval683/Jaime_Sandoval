import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AsignaturasService {

  url = environment.URL_SER_NODE;

  constructor(private _http: HttpClient) { }

  getAsignaturas(){
    return this._http.get<any[]>(this.url+'api/Asignaturas/GetAsignaturas');
  }

  deleteAsignatura(id: any){
    return this._http.delete<any[]>(this.url+`api/Asignaturas/DeleteAsignatura/${id}`);
  }

  addAsignatura(Asignatura: any){
    return this._http.post<any[]>(this.url+'api/Asignaturas/AddAsignatura', Asignatura);
  }

  getAsignaturaById(id: any){
    return this._http.get<any[]>(this.url+`api/Asignaturas/GetAsignaturaById/${id}`);
  }

  updateAsignatura(Asignatura: any){
    return this._http.put<any[]>(this.url+'api/Asignaturas/UpdateAsignatura', Asignatura);
  }
}
