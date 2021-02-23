import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable()
export class NotificationMessageService {

    constructor(protected messageService: MessageService) {
    }

    mostrarMensagemErro(msg: string) {
        this.mostrarMensagem('error', 'Erro', msg);
    }

    mostrarMensagemSucesso(msg: string) {
        this.mostrarMensagem('success', 'Sucesso', msg);
    }

    mostrarMensagemAlert(msg: string) {
        this.mostrarMensagem('warn', 'Alerta', msg);
    }

    mostrarMensagemInfo(msg: string) {
        this.mostrarMensagem('info', 'Informação', msg);
    }

    private mostrarMensagem(severity, summary, detail) {
        this.messageService.add({ severity, summary, detail });
    }
}