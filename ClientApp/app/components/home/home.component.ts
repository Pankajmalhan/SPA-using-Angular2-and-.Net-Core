import { Component,Pipe } from '@angular/core';
import { EmployeeServcies } from '../../Services/services';
import { Response } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    public EmployeeList = [];
    public constructor(private empService: EmployeeServcies) {
        this.empService.getEmployeeList()
            .subscribe(
            (data: Response) => (this.EmployeeList = data.json())
            );

    }

    deleteEmployee(empId: number) {
      

        var status = confirm("Are You want to delete this employee ?");
        if (status == true) {
            this.empService.removeEmployeeDetails(empId)
                .subscribe((data: Response) => (alert("Employee Deleted Successfully")));

            //Get new list of employee
            this.empService.getEmployeeList()
                .subscribe(
                (data: Response) => (this.EmployeeList = data.json())
                );
        }

    }
}
