import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { HttpService } from './http.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
//components
import { AppComponent } from './app.component';
import { ProductsHomeComponent } from './products-home/products-home.component';
import { EditComponent } from './edit/edit.component';
import { AddNewComponent  } from './add-new/add-new.component';
import { ShowComponent } from './show/show.component';
import { NewrestaurantComponent } from './newrestaurant/newrestaurant.component';
import { RewiewComponent } from './rewiew/rewiew.component';
@NgModule({
  declarations: [
    AppComponent, 
    ProductsHomeComponent,
    EditComponent,
    AddNewComponent,
    ShowComponent,
    NewrestaurantComponent,
    RewiewComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
