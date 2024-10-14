import { Component, ChangeDetectionStrategy, OnInit, Injector, ChangeDetectorRef } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { tap, catchError, of } from 'rxjs';
import { CoursesService } from './courses.service';

@Component({
  templateUrl: './courses.component.html',
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent extends AppComponentBase implements OnInit {
  courses: any[] = [];
  selectedCourse: any;

  constructor(
    injector: Injector,
    private courseService: CoursesService,
    private cdr: ChangeDetectorRef
  ) {
    super(injector);
  }

  ngOnInit() {
    this.loadCourses();
  }

  loadCourses() {
    this.courseService.getCourses().pipe(
      tap((data) => {
        console.log(data.result.items);
        this.courses = data.result.items;
        this.cdr.detectChanges();
      }),
      catchError((error) => {
        console.error('Error fetching courses:', error);
        return of([]);
      })
    ).subscribe();
  }

  addCourse() {
    this.courses.push({
      name: 'New Course',
      imageUrl: 'https://clarkes.team/wp-content/uploads/2023/07/Redis.png',
      description: 'Description of the new course.',
      subjects: ['Subject 1', 'Subject 2']
    });
    this.cdr.detectChanges();
  }

  selectCourse(course: any) {
    this.getCourseDetails(course.id);
  }

  getCourseDetails(courseId: string) {
    this.courseService.getCourseDetails(courseId).pipe(
      tap((data) => {
        console.log(data);
        this.selectedCourse = data.result; // Assuming the response has a 'result' field
        this.cdr.detectChanges();
      }),
      catchError((error) => {
        console.error('Error fetching course details:', error);
        return of(null);
      })
    ).subscribe();
  }

  closeDialog() {
    this.selectedCourse = null;
  }

  imgError(event: any) {
    event.target.classList.add('hidden');
  }
}