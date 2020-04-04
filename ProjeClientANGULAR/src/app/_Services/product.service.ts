import { Injectable } from '@angular/core';
import { Product } from '../_Model/product';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

type NewType = string;

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl: NewType = 'http://localhost:1414';
  ulist: Product[];
constructor(private http: HttpClient) { }

getUrunler(): Observable<Product[]> {
  return this.http.get<Product[]>( this.baseUrl + '/Urun/GetUrunler');
}

}


