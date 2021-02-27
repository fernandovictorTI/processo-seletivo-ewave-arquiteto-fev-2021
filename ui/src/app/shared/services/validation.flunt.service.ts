import { Injectable } from '@angular/core';
import { NotificationMessageService } from './notification-message.service';

@Injectable()
export class ValidationFluntService {

    constructor(protected notification: NotificationMessageService) {
    }
}