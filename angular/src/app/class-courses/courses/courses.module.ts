import { NgModule } from '@angular/core';
import { CoursesRoutingModule } from './courses-routing.module';
import { CoursesComponent } from './courses.component';
import { SharedModule } from '../../../shared/shared.module';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [CoursesComponent],
    imports: [SharedModule, CoursesRoutingModule, CommonModule],
})
export class CoursesModule {}
