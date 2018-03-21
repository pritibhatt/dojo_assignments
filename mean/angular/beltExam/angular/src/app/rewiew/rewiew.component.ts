import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-rewiew',
  templateUrl: './rewiew.component.html',
  styleUrls: ['./rewiew.component.css']
})
export class RewiewComponent implements OnInit {
  newProduct: any; 
  updatedProduct: any;
  constructor(
    private _httpService: HttpService,
    private _route: ActivatedRoute,
    private _router: Router) { }
  ngOnInit() {
    let urlId = "";
    this._route.params.subscribe((params: Params) => {
       console.log(params['id'])
       urlId = params['id'];
    });
   //to access information at loading of page and store data into variable for later user other wise it will dissapear  
  let observable = this._httpService.editedProduct(urlId);
  observable.subscribe(data => {
    console.log("Got our edited authors!", data);
    this.updatedProduct=data;
   })
}

}
