import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  authors = [];
  deleteAuthorId: any;

  constructor(private _httpService: HttpService) { }
  
  ngOnInit() {
    this.getAuthorsFromService();
  
  }
  getAuthorsFromService(){
    let observable = this._httpService.getAuthors();
    observable.subscribe(data => {
      console.log("got our authors in home", data) 
     
       
      this.authors = data['authors'];
      
    })
  }
  destroyAuthor(author) {
    let observable = this._httpService.delete(author);
    observable.subscribe(data => {
      console.log(data);
    });
    
  };
    

}
