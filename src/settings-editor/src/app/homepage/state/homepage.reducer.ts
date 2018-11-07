export function reducer(state, action) {
    if (!state) {
        state = {
            'selectedNotification' : 0
        };
    }
    switch (action.type) {
        case 'selected_notification_changed':
        console.log(action.payload);
        return {
            'selectedNotification' : action.payload
        };

        default:
            return state;
    }
}
