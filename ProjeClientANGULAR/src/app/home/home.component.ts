import { Component, OnInit } from '@angular/core';
import { Product } from '../_Model/product';
import { HttpClient } from '@angular/common/http';
import { ProductService } from '../_Services/product.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
  export class HomeComponent implements OnInit {
    secUrun: Product;
    ulist: Product[];
    baslik: string;
    constructor(private urunServ: ProductService, http: HttpClient) { }

 ngOnInit() {
      this.geturunler();
      this.baslik = 'Deneme';
    }
    geturunler() {
      this.urunServ.getUrunler().subscribe(
        (urunler: Product[]) => {
        this.ulist = urunler;
      },
        err => {console.log(err); }
      );
    }
    getUrun(urn: Product) {
      this.secUrun = urn;  }
    }
