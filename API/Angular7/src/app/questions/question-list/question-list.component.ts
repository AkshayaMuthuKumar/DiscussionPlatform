import { Component, OnInit } from '@angular/core';
import { QuestionService } from 'src/app/shared/question.service';
import { Question } from 'src/app/shared/question.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent implements OnInit {

  constructor(private service :QuestionService,
    private toastr:ToastrService) { }

  ngOnInit() {
    this.service. refreshList();
  }
  populateForm(dp:Question){
    this.service.formData=Object.assign({},dp);
  }
  onDelete(Id:number){
    if(confirm('Are you sure to delete this record?')){
    this.service.deleteQuestion(Id).subscribe(res=>{
      this.service.refreshList();
      this.toastr.warning('Deleted successfully','DP.Register');
    });
  }
}

}
