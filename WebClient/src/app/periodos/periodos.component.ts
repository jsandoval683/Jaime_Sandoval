import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableDataSource} from '@angular/material/table';
import { PeriodosService } from '../services/periodos.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-periodos',
  templateUrl: './periodos.component.html',
  styleUrls: ['./periodos.component.css']
})
export class PeriodosComponent implements OnInit {

  periodos: any[] = [];
  hide = 0;

  idAsignatura = 0;

  displayedColumns: string[] = ['ID', 'Nombre', 'Fecha de Inicio', 'Fecha de Final', 'Acciones'];
  dataSource = new MatTableDataSource(this.periodos);

  frmPeriodo: FormGroup;
  validation = false;

  constructor(
    private router: Router,
    private periodoService: PeriodosService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder
  ) { 
    this.createForm();
  }

  ngOnInit(): void {
    this.cargarDatos();
  }

  cargarDatos(){
    this.activatedRoute.params.subscribe((params) => {
      this.idAsignatura = params.idA;
      this.periodoService.getPeriodos().subscribe((res: any) => {
        this.periodos = res;
        this.dataSource = new MatTableDataSource(this.periodos);
      })
    })
  }

  createForm(): void {
    this.frmPeriodo = this.formBuilder.group({
      nombre: new FormControl(null, [Validators.required, Validators.maxLength(50)]),
      fechaInicio: new FormControl(null, [Validators.required, Validators.maxLength(50)]),
      fechaFinal: new FormControl(null, [Validators.required, Validators.maxLength(50)])
    });
  }

  entrar(id){
    this.router.navigate(["estudiantes/"+this.idAsignatura+"/"+id])
  }

  crearPeriodo(){
    this.hide = 1;
  }

  crear(){
    if (!this.frmPeriodo.valid) {
      // Set true validation
      this.validation = true;
    
      Swal.fire(
        'Error',
        'Debe rellenar el formulario',
        'error'
      );
      return;
    }

    let periodo: any;
    periodo = this.frmPeriodo.value;
    this.periodoService.addPeriodo(periodo).subscribe((res: any) => {
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

  get f() { return this.frmPeriodo.controls; }

}
