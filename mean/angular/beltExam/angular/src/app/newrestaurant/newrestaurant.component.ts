import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-newrestaurant',
  templateUrl: './newrestaurant.component.html',
  styleUrls: ['./newrestaurant.component.css']
})
export class NewrestaurantComponent implements OnInit {
  newProduct: any;
  constructor(private _httpService: HttpService, private _router: Router) { }

  ngOnInit() {
    this.newProduct = { restaurant: "", cuisine: "" }

  }
  onSubmit(newProduct){
    
    // Code to send off the form data (this.newTask) to the Service
    let observable = this._httpService.addProduct(this.newProduct);
      observable.subscribe(data => {
      console.log("Got our authors!", data);
    // ...
    // Reset this.newTask to a new, clean object.
    this.newProduct = { restaurant: "", cuisine: "" };
    this.goHome();
   });

  }
  goHome() {
    this._router.navigate(['/']);
  }
}

