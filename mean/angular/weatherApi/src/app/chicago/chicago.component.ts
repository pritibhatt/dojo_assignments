import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';


@Component({
  selector: 'app-chicago',
  templateUrl: './chicago.component.html',
  styleUrls: ['./chicago.component.css']
})
export class ChicagoComponent implements OnInit {
  main = {};
  name: string;
  constructor(private _httpService: HttpService) { };
  

  ngOnInit() {
    this.getChicago();
  }
  getChicago(){
    const observable = this._httpService.getChicago();
    observable.subscribe( data => {
      this.main = data['main'];
      this.name = data['name'];
      console.log( 'Got Chicago', data );
    });
     
    }
}
