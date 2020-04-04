import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CartComponent } from './cart/cart.component';
import { HomeComponent } from './home/home.component';
import { ContactComponent } from './contact/contact.component';
import { ProductsComponent } from './products/products.component';
import { AboutComponent } from './about/about.component';
import { SinglepruductComponent } from './products/singlepruduct/singlepruduct.component';

const routes: Routes = [
  {path: 'sepet', component: CartComponent},
  {path: 'home', component: HomeComponent},
  {path: 'iletisim', component: ContactComponent},
  {path: 'urunler', component: ProductsComponent},
  {path: 'singleurun', component: SinglepruductComponent},
  {path: 'about', component: AboutComponent},
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: '**', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
