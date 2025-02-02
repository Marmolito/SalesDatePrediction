import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appSettings } from '../Settings/appSettings';
import { ResponseAPI } from '../Models/ResponseAPI';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private http = inject(HttpClient);
  private apiUrl: string = appSettings.apiUrl + "Customer";

  constructor() { }

  getCustomers(): Observable<ResponseAPI> {
    return this.http.get<ResponseAPI>(this.apiUrl).pipe(
      catchError((error: HttpErrorResponse) => {
        console.error('Error fetching customers:', error);
        return throwError(() => new Error('Error fetching customers'));
      })
    );
  }

}
