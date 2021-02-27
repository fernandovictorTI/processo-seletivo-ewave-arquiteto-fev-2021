import { createReducer, on } from "@ngrx/store";
import { fromGarcomActions } from './logs.actions';

export const initialState = '';

const _logsReducer = createReducer(
    initialState,
    on(fromGarcomActions.LogErros, (state) => state)
);

export function reducer(state, action) {
    return _logsReducer(state, action);
}