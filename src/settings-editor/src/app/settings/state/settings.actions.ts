import { Action } from '@ngrx/store';

export enum SettingsActionTypes {
    LoadCurrentConfig = 'Load the state of the current config',
    LoadCurrentConfigSuccess = 'Successfully loaded the state of the current config',
    Save = 'Save the settings'
}

export class LoadCurrentConfig implements Action {
    readonly type = SettingsActionTypes.LoadCurrentConfig;

}

export class LoadCurrentConfigSuccess implements Action {
    readonly type = SettingsActionTypes.LoadCurrentConfigSuccess;

    constructor(private settings: any) {
    }
}

export class Save implements Action {
    readonly type = SettingsActionTypes.Save;

}

export type SettingsActions = LoadCurrentConfig
| LoadCurrentConfigSuccess
| Save;
