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
      imageUrl: 'https://example.com/path/to/new-course-image.jpg',
      description: 'Description of the new course.',
      subjects: ['Subject 1', 'Subject 2']
    });
    this.cdr.detectChanges();
  }

  selectCourse(course: any) {
    this.selectedCourse = course;
  }

  closeDialog() {
    this.selectedCourse = null;
  }

  imgError(event: any) {
    event.target.classList.add('hidden');
  }
}
