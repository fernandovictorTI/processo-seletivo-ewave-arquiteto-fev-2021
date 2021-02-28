
import {
    HttpHandler,
    HttpRequest,
    HttpEvent,
    HttpErrorResponse,
    HttpInterceptor
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, finalize } from "rxjs/operators";
import { Injectable } from "@angular/core";
import { NotificationMessageService } from "src/app/shared/services/notification-message.service";
import { of } from "rxjs";

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
    constructor(private notificationMessageService: NotificationMessageService) { }
    intercept(
        request: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {

        return next.handle(request).pipe(
            catchError((error: HttpErrorResponse) => {

                switch (error.status) {
                    case 400:
                        this.notificationMessageService.mostrarMensagemErro(this.formatarMensagem400(error));
                        return of([]);
                        break;

                    case 500:
                        this.notificationMessageService.mostrarMensagemErro(error.error || error.message);
                        break;

                    default:
                        throwError(error);
                        break;
                }

            })
        ) as Observable<HttpEvent<any>>;
    }

    private formatarMensagem400(erro) {
        let mensagemRetorno = '';

        if (erro.error.errors) {
            const { error: { errors } } = erro;

            var keys = Object.keys(errors);

            mensagemRetorno = keys.map(key => {
                return errors[key]
            }).join(', ');

            return mensagemRetorno;
        }

        if (erro.error) {
            const { error } = erro;

            mensagemRetorno = error.map(errMap => errMap.message).join(', ');
            return mensagemRetorno;
        }

        return mensagemRetorno;
    }
}