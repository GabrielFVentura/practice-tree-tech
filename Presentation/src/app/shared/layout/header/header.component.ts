import {Component, OnInit} from '@angular/core';
import {MenuItem} from 'primeng/api';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
  color: any;
  constructor() {
  }

  items: MenuItem[];

  ngOnInit(): void {
    this.items = [
      {
        label: 'Equipamentos',
        routerLink: 'equipamento/lista',
        style: {'margin-left': '35px'}
      },
      {
        label: 'Alarmes',
        routerLink: 'alarme/lista',
        style: {'margin-left': '35px'}
      }
    ];
  }
}
