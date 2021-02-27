
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

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
    constructor(private notificationMessageService: NotificationMessageService) { }
    intercept(
        request: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {

        return next.handle(request).pipe(
            catchError((error: HttpErrorResponse) => {
                // Deixar somente Dev 
                console.error("Error ao realizar requisição", error);

                this.notificationMessageService.mostrarMensagemErro(error.message ?? JSON.stringify(error));
                return throwError(error);
            })
        ) as Observable<HttpEvent<any>>;
    }
}