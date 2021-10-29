import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableDataSource} from '@angular/material/table';
import { NotasService } from '../services/notas.service';
import { param } from 'jquery';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { PeriodosService } from '../services/periodos.service';
import { EstudiantesService } from '../services/estudiantes.service';
import { AsignaturasService } from '../services/asignaturas.service';

@Component({
  selector: 'app-notas',
  templateUrl: './notas.component.html',
  styleUrls: ['./notas.component.css']
})
export class NotasComponent implements OnInit {

  notas: any[] = [];
  idAsignatura = 0;
  idPeriodo = 0;
  idEstudiante = 0;
  hide = 0;

  nota: any = [];
  edit = 0;

  listAsignaturas: any[] = [];
  listEstudiantes: any[] = [];
  listPeriodos: any[] = [];

  displayedColumns: string[] = ['ID', 'Nota', 'Acciones'];
  dataSource = new MatTableDataSource(this.notas);

  frmNota: FormGroup;
  validation = false;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private notasService: NotasService,
    private asignaturaService: AsignaturasService,
    private periodoService: PeriodosService,
    private estudianteService: EstudiantesService,
    private formBuilder: FormBuilder
  ) { 
    this.createForm();
    this.asignaturaService.getAsignaturas().subscribe((res: any) => {
      this.listAsignaturas = res;
      this.periodoService.getPeriodos().subscribe((res: any) => {
        this.listPeriodos = res;
        this.estudianteService.getEstudiantes().subscribe((res: any) => {
          this.listEstudiantes = res;
        })
      })
    })
  }

  ngOnInit(): void {
    this.cargarDatos();
    
  }

  cargarDatos(){
    this.activatedRoute.params.subscribe((params) => {
      this.idAsignatura = params.idA;
      this.idEstudiante = params.idE;
      this.idPeriodo = params.idP;
      this.notasService.getNotumsByIds(this.idAsignatura, this.idEstudiante, this.idPeriodo).subscribe((res: any) => {
        this.notas = res;
        this.dataSource = new MatTableDataSource(this.notas);

      })
    })
  }

  createForm(): void {
    this.frmNota = this.formBuilder.group({
      nota: new FormControl(null, [Validators.required, Validators.maxLength(50)]),
      idAsignatura: new FormControl(null, [Validators.pattern('')]),
      idEstudiante: new FormControl(null, [Validators.pattern('')]),
      idPeriodo: new FormControl(null, [Validators.pattern('')])
      
    });
  }

  crearNota(){
    this.hide = 1;
  }

  crear(){
    if (!this.frmNota.valid) {
      // Set true validation
      this.validation = true;
    
      Swal.fire(
        'Error',
        'Debe rellenar el formulario',
        'error'
      );
      return;
    }

    let nota: any;
    nota = this.frmNota.value;

    if(this.edit != 0){
      nota.id = this.edit;
      this.notasService.updateNotum(nota).subscribe((res: any) => {
        Swal.fire('Editado', 'Editado exitosamente', 'success').then(() => {
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

    if(this.edit == 0){
      this.notasService.addNotum(nota).subscribe((res: any) => {
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

    
  }

  cancelar(){
    this.hide = 0;
  }

  eliminar(id){
    this.notasService.deleteNotum(id).subscribe((res: any) => {
      Swal.fire('Eliminado', 'Eliminado exitosamente', 'success').then(() => {
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

  editar(id){
    this.hide = 1;
    this.initForm(id);
  }

  initForm(id){
    this.edit = id;
    this.notasService.getNotumById(id).subscribe((res: any) => {
      this.nota = res;
      // @ts-ignore: Object is possibly 'null'.
      this.frmNota.get('nota').setValue(this.nota.nota);
      // @ts-ignore: Object is possibly 'null'.
      this.frmNota.get('idAsignatura').setValue(this.nota.idAsignatura);
      // @ts-ignore: Object is possibly 'null'.
      this.frmNota.get('idEstudiante').setValue(this.nota.idEstudiante);
      // @ts-ignore: Object is possibly 'null'.
      this.frmNota.get('idPeriodo').setValue(this.nota.idPeriodo);
    })
  }

  get f() { return this.frmNota.controls; }

}
