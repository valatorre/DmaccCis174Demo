import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AllStudentsComponent} from './all-students/all-students.component';
import {GetSingleStudentComponent} from './get-single-student/get-single-student.component';

const routes: Routes = [
  { path: 'students', component: AllStudentsComponent},
  { path: 'details', component: GetSingleStudentComponent}
]

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
