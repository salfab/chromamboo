import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { mergeMap, map } from 'rxjs/operators';
import { SettingsService } from '../../services/settingsService';
import * as settingsActions from './settings.actions';

@Injectable()
export class SettingsEffects {

    constructor(private actions$: Actions,
        private settingsService: SettingsService) { }

@Effect()
loadCurrentConfig$ = this.actions$.pipe(
    ofType(),
    mergeMap((action: settingsActions.LoadCurrentConfig) => this.settingsService.GetSettings().pipe(
        map((config: any) => (new settingsActions.LoadCurrentConfigSuccess(config)))
    ))
    );
}
