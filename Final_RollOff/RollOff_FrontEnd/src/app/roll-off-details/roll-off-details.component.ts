import { Component } from '@angular/core';
import { RollOffService } from '../shared/roll-off.service';

@Component({
  selector: 'app-roll-off-details',
  templateUrl: './roll-off-details.component.html',
  styleUrls: ['./roll-off-details.component.css']
})
export class RollOffDetailsComponent {
  newdata:any=[];
  page: number = 1;
  count: number = 0;
  tableSize: number = 7;
  tableSizes: any = [10];
  constructor(private apiservice:RollOffService){ // apiservice is the object of service.
    //let userdetails=this.apiservice.getAPI().subscribe(data=>console.log(data));
    //this.apiservice.getAPI().subscribe(data=>console.log(data));
    //console.log(userdetails);
  }
  ngOnInit(){
  this.apiservice.getAPI().subscribe(res=>{this.newdata=res;})
 
  }
  onTableDataChange(event: any) {
    this.page = event;
    this.apiservice.getAPI().subscribe(res=>{this.newdata=res;})
  }
  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.apiservice.getAPI().subscribe(res=>{this.newdata=res;})
  }

  SearchText='';
}
