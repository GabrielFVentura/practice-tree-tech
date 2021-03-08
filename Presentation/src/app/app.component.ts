import {Component, OnInit} from '@angular/core';
import {TreeTechService} from './services/treetech-service';
import {environment} from '../environments/environment';
import {NgxSpinnerService} from 'ngx-spinner';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [
    TreeTechService
  ]
})
export class AppComponent implements OnInit {
  title = 'Treetech System';
  color = '#33333';

  constructor() {}

  ngOnInit(): void {

  }
}
