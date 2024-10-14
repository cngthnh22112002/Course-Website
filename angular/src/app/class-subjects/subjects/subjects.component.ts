import { ChangeDetectionStrategy, Component, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  templateUrl: './subjects.component.html',
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SubjectsComponent extends AppComponentBase {
  constructor(injector: Injector) {
    super(injector);
  }
}
