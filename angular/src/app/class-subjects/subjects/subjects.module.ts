import { NgModule } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { SubjectsComponent } from './subjects.component';
import { SubjectsRoutingModule } from './subjects-routing.module';

@NgModule({
    declarations: [SubjectsComponent],
    imports: [SharedModule, SubjectsRoutingModule],
})
export class SubjectsModule {}
