import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {

  public errorMessage: string = '';

  constructor() { }

  public handleError = (error: HttpErrorResponse) => {
    if(error.status === 500){
      this.handle500Error(error);
    }
  }

  private handle500Error = (error: HttpErrorResponse) => {
    this.createErrorMessage(error);
  }

  private createErrorMessage = (error: HttpErrorResponse) => {
    this.errorMessage = error.error ? error.error : error.statusText;
    alert("Something is wrong");
  }


}
