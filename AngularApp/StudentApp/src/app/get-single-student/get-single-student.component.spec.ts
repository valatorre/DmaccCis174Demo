import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetSingleStudentComponent } from './get-single-student.component';

describe('GetSingleStudentComponent', () => {
  let component: GetSingleStudentComponent;
  let fixture: ComponentFixture<GetSingleStudentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetSingleStudentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetSingleStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
