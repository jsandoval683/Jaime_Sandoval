import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NotasService {

  url = environment.URL_SER_NODE;

  constructor(private _http: HttpClient) { }

  getNotums(){
    return this._http.get<any[]>(this.url+'api/Notas/GetNotums');
  }

  deleteNotum(id: any){
    return this._http.delete<any[]>(this.url+`api/Notas/DeleteNotum/${id}`);
  }

  addNotum(Notum: any){
    return this._http.post<any[]>(this.url+'api/Notas/AddNotum', Notum);
  }

  getNotumById(id: any){
    return this._http.get<any[]>(this.url+`api/Notas/GetNotumById/${id}`);
  }

  getNotumsByIds(idAsignatura: any, idEstudiante: any, idPeriodo: any){
    return this._http.get<any[]>(this.url+`api/Notas/GetNotumsByIds/${idAsignatura}/${idEstudiante}/${idPeriodo}/`);
  }

  updateNotum(Notum: any){
    return this._http.put<any[]>(this.url+'api/Notas/UpdateNotum', Notum);
  }
}
