import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-products-home',
  templateUrl: './products-home.component.html',
  styleUrls: ['./products-home.component.css']
})
export class ProductsHomeComponent implements OnInit {
  products = [];
  deleteProducttId: any;

  constructor(private _httpService: HttpService) { }
  
  ngOnInit() {
    this.getProductsFromService();
  
  }
  getProductsFromService(){
    let observable = this._httpService.getProducts();
    observable.subscribe(data => {
      console.log("got our products in home", data) 
     
       
      this.products = data['products'];
      
    })
  }
  destroyProduct(product) {
    let observable = this._httpService.delete(product);
    observable.subscribe(data => {
      console.log(data);
    });
    
  };
    

}