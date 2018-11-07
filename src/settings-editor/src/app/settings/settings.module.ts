import { StoreModule } from '@ngrx/store';
import { NgModule } from '@angular/core';
import { reducer } from './state/settings.reducer';


@NgModule({
    imports: [StoreModule.forFeature('settings', reducer)],
    exports: [],
    declarations: [],
    providers: [],
})
export class SettingsModule { }
