import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private _http: HttpClient) { }
  addProduct(newProduct){
    console.log(newProduct);
    
    return this._http.post('/products', newProduct)
  }
  getProducts() {
    return this._http.get('/products');
  }
  delete(product) {
    // console.log(/tasks/' + taskId);
    // console.log( deletetaskId);
    return this._http.delete('/products/' + product._id);
  };
  editedProduct(urlId){
    console.log(urlId)
    console.log("inservice")
    return this._http.get('/products/' + urlId);
    // return this._http.put('/authors/:id', updatedAuthor);
  }
  editedProductId(updatedProduct){
    console.log(updatedProduct);
    console.log("inservice");
    return this._http.put('/products/' + updatedProduct.product._id, updatedProduct.product);
  }
  getProductsId(id){
    return this._http.get('/products/' + id );
    
  }
  addReview(newProduct){
    console.log(newProduct);
    
    return this._http.post('/products', newProduct.product._id)
  }
} 