import { Component } from '@angular/core';
import { EmployeeServcies } from '../../Services/services';
import { Response } from '@angular/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
    selector: 'new-employee',
    templateUrl: './newEmployee.component.html',
   
})
export class newEmployeeComponent {
    public ProjectList = [];
    public formData: FormGroup;
    public constructor(private empService: EmployeeServcies) {
        this.empService.getProjectList()
            .subscribe(
            (data: Response) => (this.ProjectList = data.json())
            );

        this.formData = new FormGroup({
            'EmployeeName': new FormControl('', [Validators.required]),
            'Designation': new FormControl('',Validators.required),
            'Skills': new FormControl('', Validators.required),
            'Project': new FormControl(0, [Validators.required, this.customValidator])    
        });

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
                Designation: this.formData.value.Designation,
                EmployeeName: this.formData.value.EmployeeName,
                ProjectId: this.formData.value.Project,
                Skills: this.formData.value.Skills,
            };
            this.empService.postData(Obj).subscribe();
            alert("Employee Inserted Successfully");
        }
        
    }


}
