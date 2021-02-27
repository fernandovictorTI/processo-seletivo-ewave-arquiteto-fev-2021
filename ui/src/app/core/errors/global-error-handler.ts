import { ErrorHandler, Injectable, NgZone } from "@angular/core";
import { NotificationMessageService } from "src/app/shared/services/notification-message.service";

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
    constructor(private notificationMessageService: NotificationMessageService, private zone: NgZone) { }

    handleError(error: Error) {

        this.zone.run(() =>
            this.notificationMessageService.mostrarMensagemErro(
                error.message || "Erro indefinido"
            ));

        console.error("Error de global error handler", error);
    }
}