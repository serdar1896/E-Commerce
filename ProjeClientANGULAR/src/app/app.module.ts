import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeiderComponent } from './heider/heider.component';
import { FooterComponent } from './footer/footer.component';
import { ProductsComponent } from './products/products.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { ContactComponent } from './contact/contact.component';
import { CartComponent } from './cart/cart.component';
import { AboutComponent } from './about/about.component';
import { SinglepruductComponent } from './products/singlepruduct/singlepruduct.component';
import { KategorimenuComponent } from './kategorimenu/kategorimenu.component';



@NgModule({
  declarations: [
    AppComponent,
    HeiderComponent,
    FooterComponent,
    ProductsComponent,
    HomeComponent,
    ContactComponent,
    CartComponent,
    AboutComponent,
    SinglepruductComponent,
    KategorimenuComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
