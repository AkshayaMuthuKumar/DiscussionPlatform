import { Injectable } from '@angular/core';
import { Question } from './question.model';
import{HttpClient}from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
formData : Question;
list:Question[];
readonly rootURL="http://localhost:61559/api"
  constructor(private http:HttpClient) { }
  postQuestion(formData:Question){
    return this.http.post(this.rootURL+'/Question',formData);
  }
  refreshList(){
    this.http.get(this.rootURL+'/Question')
    .toPromise().then(res=>this.list=res as Question[]);
  }
  putQuestion(formData:Question){
    return this.http.put(this.rootURL+'/Question'+formData.Id,formData);
  }
  deleteQuestion(Id:number){
    return this.http.delete(this.rootURL+'/Question'+Id);
  }
}