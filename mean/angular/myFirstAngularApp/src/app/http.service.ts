import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from 'selenium-webdriver/http';

@Injectable()
export class HttpService {

  constructor(private _http: HttpClient) {
    this.getTasks();
   }
   getTasks(){
    // our http response is an Observable, store it in a variable
       let tempObservable = this._http.get('/tasks');
    // subscribe to the Observable and provide the code we would like to do with our data from the response
       tempObservable.subscribe(data => console.log("Got our tasks!", data));
    }
}


