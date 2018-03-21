
import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-add-new',
  templateUrl: './add-new.component.html',
  styleUrls: ['./add-new.component.css']
})
export class AddNewComponent implements OnInit {
  newProduct: any;
  constructor(private _httpService: HttpService, private _router: Router) { }

  ngOnInit() {
    this.newProduct = { name: "", qty: "", description: "" }

  }
  onSubmitReview(newProduct){
    
    // Code to send off the form data (this.newTask) to the Service
    let observable = this._httpService.addReview(this.newProduct);
      observable.subscribe(data => {
      console.log("Added new product!", data);
    // ...
    // Reset this.newTask to a new, clean object.
    this.newProduct = {name: "", qty: "", description: ""};

    this.goHome();
  });

 }
 goHome() {
   this._router.navigate(['reviews/:id']);
 }
  }
