export function reducer(state, action) {
    switch (action.type) {
        case 'notification_changed':
        console.log(action.payload);
        return {
            ...state
        };

        default:
            return state;
    }
}
