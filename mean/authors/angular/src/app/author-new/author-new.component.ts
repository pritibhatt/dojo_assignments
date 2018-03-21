import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-author-new',
  templateUrl: './author-new.component.html',
  styleUrls: ['./author-new.component.css']
})
export class AuthorNewComponent implements OnInit {
  newAuthor: any;
  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    this.newAuthor = { name: "" }

  }
  onSubmit(newAuthor){
    
    // Code to send off the form data (this.newTask) to the Service
    let observable = this._httpService.addAuthor(this.newAuthor);
      observable.subscribe(data => {
      console.log("Got our authors!", data);
    // ...
    // Reset this.newTask to a new, clean object.
    this.newAuthor = {name: ""};
    })
  }
}
