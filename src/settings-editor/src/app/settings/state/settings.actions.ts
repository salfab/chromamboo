import { Action } from '@ngrx/store';

export enum SettingsActionTypes {
    LoadCurrentConfig = 'Load the state of the current config',
    LoadCurrentConfigSuccess = 'Successfully loaded the state of the current config',
    Save = 'Save the settings',
    ChangedCurrentConfigSuccess = 'Changed current config with success'
}

export class LoadCurrentConfig implements Action {
    payload: any;
    readonly type = SettingsActionTypes.LoadCurrentConfig;

}

export class LoadCurrentConfigSuccess implements Action {
    payload: any;
    readonly type = SettingsActionTypes.LoadCurrentConfigSuccess;

    constructor(private settings: any) {
    }
}

export class ChangedCurrentConfigSuccess implements Action {
    payload: any;
    readonly type = SettingsActionTypes.ChangedCurrentConfigSuccess;

    constructor(private settings: any, private index: number) {
    }
}

export class Save implements Action {
    payload: any;
    readonly type = SettingsActionTypes.Save;

}

export type SettingsActions = LoadCurrentConfig
| LoadCurrentConfigSuccess
| ChangedCurrentConfigSuccess
| Save;
