import { NgModule } from '@angular/core';
import { CreateCTCBreakUpComponent } from './createCTCBreakUp.component';
import { CtcBreakUpConfigService } from './ctcbreakupconfig.service';
import { CTCBreakUpRepository } from './ctcbreakupconfig.repository';
import { CoreModule } from '../core/core.module';
import { CwbAppModule } from '../cwbapp.module';

@NgModule({
  imports: [],
  declarations: [],
  exports: [],
  providers: [CtcBreakUpConfigService, CTCBreakUpRepository]
})
export class CTCBreakUpConfigModule { };
