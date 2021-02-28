import { Injectable } from "@angular/core";
import { Actions, createEffect } from "@ngrx/effects";
import { Action } from "@ngrx/store";
import { Observable } from "rxjs";
import * as logsActions from "./logs.actions";

Injectable()
export class LogsEffects {

    constructor(private actions$: Actions) {
    }
}