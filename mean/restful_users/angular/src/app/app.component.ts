import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  // title = 'app';
  tasks = [];
  newTask: any;
  updatedTask: any;
  deleteTaskId: any;

  constructor(private _httpService: HttpService){}
  ngOnInit(){
    // this.getTasksFromService();
    this.newTask = { title: "", description: "" }
    
  }
  getTasksFromService(){
    let observable = this._httpService.getTasks();
    observable.subscribe(data => {
      console.log("got our tasks", data) 
      
       
      this.tasks = data['tasks'];
      
    })
  }
  getTasksFromClick() {
    let observable = this._httpService.onButtonClick();
    observable.subscribe(data => {
      console.log("Got our tasks!", data)
      this.tasks = data['tasks'];
      console.log(this.tasks);

    });
  }
  onSubmit(newTask){
    
    // Code to send off the form data (this.newTask) to the Service
    let observable = this._httpService.addTask(this.newTask);
      observable.subscribe(data => {
      console.log("Got our tasks!", data);
    // ...
    // Reset this.newTask to a new, clean object.
    this.newTask = {title: "", description: ""};
    })
  }
  //edit
  clicked =false;
 
  onEditTask(task){
    this.clicked=true;
    console.log("edit is clicked")
    this.updatedTask = { _id: task._id, title: task.title, description: task.description };
  }
  onSubmitEdit(){
    let observable = this._httpService.editedTask(this.updatedTask);
      observable.subscribe(data => {
      console.log("Got our tasks!", data);
  
    console.log(this.updatedTask)
    
    });
  };

  

  destroyTask(task) {
    let observable = this._httpService.delete(task);
    observable.subscribe(data => {
      console.log(data);
    });
    
  };
}
