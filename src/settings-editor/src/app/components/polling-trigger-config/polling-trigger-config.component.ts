import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'polling-trigger-config',
  templateUrl: './polling-trigger-config.component.html',
  styleUrls: ['./polling-trigger-config.component.scss']
})

export class PollingTriggerConfigComponent implements OnInit {

  constructor() {

  }
  @Input() trigger: any = null;
  @Input() item: FormGroup = null;

  ngOnInit() {

  }
}
