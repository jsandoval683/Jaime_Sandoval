import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableDataSource} from '@angular/material/table';
import { EstudiantesService } from '../services/estudiantes.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-estudiantes',
  templateUrl: './estudiantes.component.html',
  styleUrls: ['./estudiantes.component.css']
})
export class EstudiantesComponent implements OnInit {

  estudiantes: any[] = [];
  idAsignatura = 0;
  idPeriodo = 0;
  hide = 0;

  displayedColumns: string[] = ['ID', 'Nombre', 'Código', 'Acciones'];
  dataSource = new MatTableDataSource(this.estudiantes);

  frmEstudiante: FormGroup;
  validation = false;

  constructor(
    private router: Router,
    private activatedroute: ActivatedRoute,
    private estudiantesService: EstudiantesService,
    private formBuilder: FormBuilder
  ) {
    this.createForm();
   }

  ngOnInit(): void {
    this.cargarDatos();
    
  }

  cargarDatos(){
    this.activatedroute.params.subscribe((params) => {
      this.idAsignatura = params.idA;
      this.idPeriodo = params.idP;
      this.estudiantesService.getEstudiantes().subscribe((res: any) => {
        this.estudiantes = res;
        this.dataSource = new MatTableDataSource(this.estudiantes);
      })
    })
  }

  createForm(): void {
    this.frmEstudiante = this.formBuilder.group({
      nombre: new FormControl(null, [Validators.required, Validators.maxLength(50)]),
      codigo: new FormControl(null, [Validators.required, Validators.maxLength(50)])
    });
  }

  entrar(id){
    this.router.navigate(["notas/"+this.idAsignatura+"/"+this.idPeriodo+"/"+id]);
  }

  crearEstudiante(){
    this.hide = 1;
  }

  crear(){
    if (!this.frmEstudiante.valid) {
      // Set true validation
      this.validation = true;
    
      Swal.fire(
        'Error',
        'Debe rellenar el formulario',
        'error'
      );
      return;
    }

    let estudiante: any;
    estudiante = this.frmEstudiante.value;
    this.estudiantesService.addEstudiante(estudiante).subscribe((res: any) => {
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

  get f() { return this.frmEstudiante.controls; }

}
