import {Component, Input, OnInit} from '@angular/core';
import {Student} from '../student';

@Component({
  selector: 'app-get-single-student',
  templateUrl: './get-single-student.component.html',
  styleUrls: ['./get-single-student.component.css']
})
export class GetSingleStudentComponent implements OnInit {
  @Input() student: Student

  constructor() { }

  ngOnInit() {
  }

}
