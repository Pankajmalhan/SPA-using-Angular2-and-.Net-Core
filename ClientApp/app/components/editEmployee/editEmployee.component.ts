import { Component } from '@angular/core';
import { EmployeeServcies } from '../../Services/services';
import { Response } from '@angular/http';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
    selector: 'edit-employee',
    templateUrl: './editEmployee.component.html'
})
export class editEmployeeComponent {
    private EmpId: number;
    public EmployeeDetails = {};
    public employeeName: string;
    public ProjectList = [];
    public formData: FormGroup;

    public constructor(private empService: EmployeeServcies, private activatedRoute: ActivatedRoute) {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.EmpId = params['id'];
        });

        this.empService.getProjectList()
            .subscribe(
            (data: Response) => (this.ProjectList = data.json())
            );

        


       
       
        this.formData = new FormGroup({
            'EmployeeId': new FormControl('', [Validators.required]),
            'EmployeeName': new FormControl('', [Validators.required]),
            'Designation': new FormControl('', Validators.required),
            'Skills': new FormControl('', Validators.required),
            'Project': new FormControl(0, [Validators.required, this.customValidator])
        });

        this.empService.getEmployeeDetails(this.EmpId)
            .subscribe((data: Response) => (
                this.formData.patchValue({ EmployeeId: data.json().employeeId }),
                this.formData.patchValue({ EmployeeName: data.json().employeeName }),
                this.formData.patchValue({ Designation: data.json().designation }),
                this.formData.patchValue({ Skills: data.json().skills }),
                this.formData.patchValue({ Project: data.json().projectId })

            ));
    }

    customValidator(control: FormControl): { [s: string]: boolean } {
        if (control.value == "0") {
            return { data: true };
        }
        else {
            return null;
        }
    }

    submitData() {
        if (this.formData.valid) {
            var Obj = {
                EmployeeId: this.formData.value.EmployeeId,
                Designation: this.formData.value.Designation,
                EmployeeName: this.formData.value.EmployeeName,
                ProjectId: this.formData.value.Project,
                Skills: this.formData.value.Skills,
            };
            this.empService.editEmployeeData(Obj)
                .subscribe((data: Response) => (alert("Employee Updated Successfully")));;
            
        }

    }
}
