import { Component, OnInit } from '@angular/core';
import { QuestionService } from 'src/app/shared/question.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  constructor(private service :  QuestionService,
    private toastr:ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }
resetForm(form?:NgForm){
  if(form!=null)
  form.resetForm();
  this.service.formData={
    Id : null,
    question:''
  }
}
onSubmit(form:NgForm){
  if(form.value.Id==null)
this.insertRecord(form);
else
this.updateRecord(form);

}
insertRecord(form:NgForm){
this.service.postQuestion(form.value). subscribe(res => {
  this.toastr.success('Inserted Successfully','DP.Register');
  this.resetForm(form);
  this.service.refreshList();
});
}
updateRecord(form:NgForm){
  this.service.putQuestion(form.value). subscribe(res => {
    this.toastr.info('Updated Successfully','DP.Register');
    this.resetForm(form);
    this.service.refreshList();

  });
  }

}
