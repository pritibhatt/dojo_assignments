import { Component, OnInit } from '@angular/core';


import { HttpService } from '../http.service';
import { ActivatedRoute, Params, Router } from '@angular/router';
@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  updatedAuthor: any;
  
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
  let observable = this._httpService.editedAuthor(urlId);
  observable.subscribe(data => {
    console.log("Got our edited authors!", data);
    this.updatedAuthor=data;
  })
  }
  onSubmitEdit(){
    console.log(this.updatedAuthor);
    let observable = this._httpService.editedAuthorId(this.updatedAuthor);
    observable.subscribe(data => {
    console.log("updated our authors!", data);
    
    console.log(this.updatedAuthor)
    this.updatedAuthor = {name: ""};
    this.goHome();
   });

  }
  goHome() {
    this._router.navigate(['/']);
  }
 

  
  
}
