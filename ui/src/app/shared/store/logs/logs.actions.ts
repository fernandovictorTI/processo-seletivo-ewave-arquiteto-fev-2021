import { createAction, props } from "@ngrx/store";

export enum LogActionTypes {
    LOG_ERROS = '[LOG] Erros'
}

export const LogErros = createAction(
    LogActionTypes.LOG_ERROS,
    props<{ erro: any }>()
);

export const fromGarcomActions = {
    LogErros
}