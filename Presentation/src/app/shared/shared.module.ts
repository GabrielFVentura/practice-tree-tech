// angular
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

// primeng
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { RadioButtonModule } from 'primeng/radiobutton';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NumeroSeriePipe } from './utils/numero-serie.pipe';


@NgModule({
  exports: [
    // angular
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    // primeng
    CalendarModule,
    DropdownModule,
    TableModule,
    DialogModule,
    RadioButtonModule,
    // fontawesome
    FontAwesomeModule,
    NumeroSeriePipe
  ],
  declarations: [NumeroSeriePipe]
})

export class SharedModule { }
