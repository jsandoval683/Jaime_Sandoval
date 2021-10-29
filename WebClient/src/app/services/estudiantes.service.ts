import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EstudiantesService {

  url = environment.URL_SER_NODE;

  constructor(private _http: HttpClient) { }

  getEstudiantes(){
    return this._http.get<any[]>(this.url+'api/Estudiantes/GetEstudiantes');
  }

  deleteEstudiante(id: any){
    return this._http.delete<any[]>(this.url+`api/Estudiantes/DeleteEstudiante/${id}`);
  }

  addEstudiante(Estudiante: any){
    return this._http.post<any[]>(this.url+'api/Estudiantes/AddEstudiante', Estudiante);
  }

  getEstudianteById(id: any){
    return this._http.get<any[]>(this.url+`api/Estudiantes/GetEstudianteById/${id}`);
  }

  updateEstudiante(Estudiante: any){
    return this._http.put<any[]>(this.url+'api/Estudiantes/UpdateEstudiante', Estudiante);
  }
}
