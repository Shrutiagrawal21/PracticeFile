import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RollOffService } from 'src/app/shared/roll-off.service';

@Component({
  selector: 'app-roll-off-form',
  templateUrl: './roll-off-form.component.html',
  styleUrls: ['./roll-off-form.component.css']
})
export class RollOffFormComponent implements OnInit{
  constructor(public service:RollOffService,
    private readonly route:ActivatedRoute){
  }
employeeId:string|null|undefined;
employee:any={
    globalGroupID:0 ,
    employeeNo: 0,
    name: '',
    localGrade: '',
    mainClient: '',
    email: '',
    joiningDate:new Date,
    projectCode:0 ,
    projectName: '',
    projectStartDate:new Date,
    projectEndDate: new Date,
    peopleManager: '',
    practice: '',
    pspName: '',
    newGlobalPractice: '',
    officeCity: '',
    country: ''
}

ngOnInit(): void{
  this.route.paramMap.subscribe(
    (params)=>{
      this.employeeId=params.get('id');
      if(this.employeeId){
        this.service.getId(this.employeeId)
        .subscribe(
          (successResponse)=>{
            this.employee=successResponse;
            console.log(this.employee);
          }
        );
      }
    }
  );
}
}
