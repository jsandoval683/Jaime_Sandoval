import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AsignaturasComponent } from './asignaturas/asignaturas.component';
import { PeriodosComponent } from './periodos/periodos.component';
import { EstudiantesComponent } from './estudiantes/estudiantes.component';
import { NotasComponent } from './notas/notas.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'materias', component: AsignaturasComponent },
  { path: 'periodos/:idA', component: PeriodosComponent },
  { path: 'estudiantes/:idA/:idP', component: EstudiantesComponent },
  { path: 'notas/:idA/:idP/:idE', component: NotasComponent },
  { path: '**', pathMatch: 'full', redirectTo: '/materias' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: "enabled"})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
