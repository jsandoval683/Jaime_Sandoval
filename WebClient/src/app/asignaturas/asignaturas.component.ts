import { Component, OnInit } from '@angular/core';
import { AsignaturasService } from '../services/asignaturas.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { MatTableDataSource} from '@angular/material/table';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-asignaturas',
  templateUrl: './asignaturas.component.html',
  styleUrls: ['./asignaturas.component.css']
})
export class AsignaturasComponent implements OnInit {

  asignaturas: any[] = [];
  hide = 0;

  displayedColumns: string[] = ['ID', 'Nombre', 'Acciones'];
  dataSource = new MatTableDataSource(this.asignaturas);

  frmAsignatura: FormGroup;
  validation = false;

  constructor(
    private router: Router,
    private asignaturaService: AsignaturasService,
    private formBuilder: FormBuilder
    ) { 
      this.createForm();
    }

  ngOnInit(): void {
    this.cargarDatos();
  }

  cargarDatos(){
    this.asignaturaService.getAsignaturas().subscribe((res: any) => {
      this.asignaturas = res;
      this.dataSource = new MatTableDataSource(this.asignaturas);
    })
  }

  createForm(): void {
    this.frmAsignatura = this.formBuilder.group({
      nombre: new FormControl(null, [Validators.required, Validators.maxLength(50)])
    });
  }

  entrar(id){
    this.router.navigate(["periodos/"+id]);
  }

  crearAsignatura(){
    this.hide = 1;
  }

  crear(){
    if (!this.frmAsignatura.valid) {
      // Set true validation
      this.validation = true;
    
      Swal.fire(
        'Error',
        'Debe rellenar el formulario',
        'error'
      );
      return;
    }

    let asignatura: any;
    asignatura = this.frmAsignatura.value;
    this.asignaturaService.addAsignatura(asignatura).subscribe((res: any) => {
      Swal.fire('Creado', 'Guardado exitosamente', 'success').then(() => {
        this.hide = 0;
        this.cargarDatos();
      });
    },
    (err) => {
      Swal.fire('Error', 'Unexpected error', 'error');
    },
    () => {
      // Complete
    });
  }

  cancelar(){
    this.hide = 0;
  }

  get f() { return this.frmAsignatura.controls; }

}
