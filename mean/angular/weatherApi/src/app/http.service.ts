import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable()
export class HttpService {

  
  constructor(private _http: HttpClient ) {
    // this.getData(this.city);
    this.getChicago();
   }
   getChicago(){
    // this.city = city;
    return this._http.get(`http://api.openweathermap.org/data/2.5/weather?q=chicago&APPID=d3cb3c333cba1208ee4d25dc3cc67439`);
  }
  //  getDallas() {
  //   return this._http.get('http://api.openweathermap.org/data/2.5/weather?q=dallas&units=imperial&appid=6b34e22a9232515d101279d760ce8799')
  // }
}
