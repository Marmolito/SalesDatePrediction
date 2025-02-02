import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appSettings } from '../Settings/appSettings';
import { ResponseAPI } from '../Models/ResponseAPI';

@Injectable({
  providedIn: 'root'
})
export class ProductService {


  private http = inject(HttpClient);
  private apiUrl: string = appSettings.apiUrl + "Product";

  constructor() { }

  getProducts() {
    return this.http.get<ResponseAPI>(this.apiUrl);
  }
}
