import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.component.html',
  styleUrls: ['./course-detail.component.css']
})
export class CourseDetailComponent { 
  course: any;

  constructor(
    public dialogRef: MatDialogRef<CourseDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.course = data.course;
  }
  close(): void {
    this.dialogRef.close();
  }
}