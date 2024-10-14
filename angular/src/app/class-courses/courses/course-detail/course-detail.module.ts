import { NgModule } from '@angular/core';
import { CourseDetailRoutingModule } from './course-detail-routing.module';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';
import { CourseDetailComponent } from './course-detail.component';

@NgModule({
    declarations: [CourseDetailComponent],
    imports: [SharedModule, CourseDetailRoutingModule, CommonModule],
})
export class CourseDetailModule {}
