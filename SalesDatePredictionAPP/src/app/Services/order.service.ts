import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appSettings } from '../Settings/appSettings';
import { OrderProduct } from '../Models/OrderProduct';
import { ResponseAPI } from '../Models/ResponseAPI';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private http = inject(HttpClient);
  private apiUrl: string = appSettings.apiUrl + "Orders";

  constructor() { }

  getOrderdersByCustomerId(id: number) {
    return this.http.get<ResponseAPI>(`${this.apiUrl}/${id}`);
  }

  createOrderderProduct(obj: OrderProduct) {
    return this.http.post<ResponseAPI>(this.apiUrl, obj);
  }

}
