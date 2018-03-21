import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private _http: HttpClient) {
    // this.getTasks();
    this.onButtonClick();
   }
  getTasks(){
    console.log("got here")
    // our http response is an Observable, store it in a variable
    // let tempObservable = this._http.get('/tasks');
    // subscribe to the Observable and provide the code we would like to do with our data from the response
    // tempObservable.subscribe(data => console.log("Got our tasks!", data));
    return this._http.get('/tasks');
  }
  onButtonClick() { 
    return this._http.get('/tasks');
  }
  addTask(newTask){
    console.log(newTask);
    
    return this._http.post('/tasks', newTask)
  }
  editedTask(updatedTask){
    console.log(updatedTask)
    console.log("inservice")
    return this._http.put('/tasks/' + updatedTask._id, updatedTask);
    // return this._http.put('/tasks/:id', updatedTask);
  }
  delete(task) {
    // console.log(/tasks/' + taskId);
    // console.log( deletetaskId);
    return this._http.delete('/tasks/' + task._id);
  };
 
} 

