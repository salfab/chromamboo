import { ChangedCurrentConfigSuccess, SettingsActionTypes } from './../../settings/state/settings.actions';

export function reducer(state, action) {
    if (!state) {
        state = {
            'selectedNotificationIndex' : 0
        };
    }

    switch (action.type) {
        case SettingsActionTypes.ChangedCurrentConfigSuccess:
        console.log(action);
        return {
            'selectedNotificationIndex' : action.index,
            'selectedNotification' : action.settings[action.index],
            'allSettings' : action.settings
        };
        default:
            return state;
    }
}
