import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'polling-trigger-config',
  templateUrl: './polling-trigger-config.component.html',
  styleUrls: ['./polling-trigger-config.component.scss']
})

export class PollingTriggerConfigComponent implements OnInit {

  constructor() {

  }
  @Input() trigger: any = null;

  ngOnInit() {

  }
}
