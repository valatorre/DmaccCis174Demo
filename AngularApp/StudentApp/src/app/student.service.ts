import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {Student} from './student';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(
    private http: HttpClient) { }

    private studentApiUrl = 'http://localhost:53457/api/v1/students';

  public getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(this.studentApiUrl);
  }
}
