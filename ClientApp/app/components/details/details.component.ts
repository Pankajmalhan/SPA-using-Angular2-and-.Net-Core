import { Component } from '@angular/core';
import { EmployeeServcies } from '../../Services/services';
import { Response } from '@angular/http';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'employee-detail',
    templateUrl: './details.component.html'
})
export class DetailsComponent {
    private EmpId: number;
    public EmployeeDetails = {};
    public constructor(private empService: EmployeeServcies, private activatedRoute: ActivatedRoute) {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.EmpId = params['id'];
        });

        this.empService.getEmployeeDetails(this.EmpId)
            .subscribe((data: Response) => (this.EmployeeDetails["employeeName"] = data.json().employeeName,
                this.EmployeeDetails["Designation"] = data.json().designation,
                this.EmployeeDetails["ProjectName"] = data.json().projectName,
                this.EmployeeDetails["Skills"] = data.json().skills,
                this.EmployeeDetails["StartDate"] = data.json().startDate,
                this.EmployeeDetails["EndDate"] = data.json().endDate
                ));
       
    }

 }

