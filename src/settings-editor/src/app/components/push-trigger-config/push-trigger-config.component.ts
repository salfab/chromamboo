import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'push-trigger-config',
  templateUrl: './push-trigger-config.component.html',
  styleUrls: ['./push-trigger-config.component.scss']
})

export class PushTriggerConfigComponent implements OnInit {

  constructor() {

  }

  @Input() trigger: any = null;
  ngOnInit() {

  }
}
