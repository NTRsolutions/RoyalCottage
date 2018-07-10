import { Injectable } from '@angular/core';

@Injectable()
export class MessageService {
  successMessages: string[] = [];
  failureMessages: string[] = [];

  addSuccess(message: string) {
    this.successMessages.push(message);
  }

  addFailure(message: string) {
    this.failureMessages.push(message);
  }

  clearSuccess() {
    this.successMessages = [];
  }

  clearFailure() {
    this.failureMessages = [];
  }
}
