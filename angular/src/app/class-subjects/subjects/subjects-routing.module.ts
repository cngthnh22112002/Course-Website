import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SubjectsComponent } from './subjects.component';

const routes: Routes = [
    {
        path: '',
        component: SubjectsComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class SubjectsRoutingModule {}
