import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private _http: HttpClient) { }
  addAuthor(newAuthor){
    console.log(newAuthor);
    
    return this._http.post('/authors', newAuthor)
  }
  getAuthors() {
    return this._http.get('/authors');
  }
  delete(author) {
    // console.log(/tasks/' + taskId);
    // console.log( deletetaskId);
    return this._http.delete('/authors/' + author._id);
  };
  editedAuthor(urlId){
    console.log(urlId)
    console.log("inservice")
    return this._http.get('/authors/' + urlId);
    // return this._http.put('/authors/:id', updatedAuthor);
  }
  editedAuthorId(updatedAuthor){
    console.log(updatedAuthor);
    console.log("inservice");
    return this._http.put('/authors/' + updatedAuthor.author._id, updatedAuthor.author);
  }
} 