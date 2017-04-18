import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { DetailsComponent } from './components/details/details.component';
import { newEmployeeComponent } from './components/newEmployee/newEmployee.component';
import { editEmployeeComponent } from './components/editEmployee/editEmployee.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmployeeServcies } from './Services/services';
import { filterSearch } from './pipes/search';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        DetailsComponent,
        newEmployeeComponent,
        editEmployeeComponent,
        filterSearch
    ],

    providers: [EmployeeServcies],
    imports: [
        FormsModule,
        ReactiveFormsModule,
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'details/:id', component: DetailsComponent },
            { path: 'new', component: newEmployeeComponent },
            { path: 'edit/:id', component: editEmployeeComponent },
            { path: '**', redirectTo: 'home' }
        ])

    ]
})
export class AppModule {
}
