import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'chromamboo-settings',
  templateUrl: './chromamboo-settings.component.html',
  styleUrls: ['./chromamboo-settings.component.scss']
})

export class ChromambooSettingsComponent implements OnInit {

  constructor() {

  }
  @Input() config: any = null;
  ngOnInit() {

  }
}
