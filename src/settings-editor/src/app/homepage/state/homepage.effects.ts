import { SettingsService } from './../../services/settingsService';
import { LoadCurrentConfigSuccess, ChangedCurrentConfigSuccess } from './../../settings/state/settings.actions';
import { Effect, ofType, Actions } from '@ngrx/effects';
import { switchMap, map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable()
export class HomepageEffects {

    constructor(private actions$: Actions, private settingsService: SettingsService) {}
    @Effect()
    selectedNotificationIndexChanged = this.actions$.pipe(
        ofType('selected_notification_index_changed'),
        map(action => {
            const allSettings = this.settingsService.getAll();
            return new ChangedCurrentConfigSuccess(allSettings, action.payload);
        }));
    }
