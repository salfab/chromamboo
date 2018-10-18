import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'push-trigger-config',
  templateUrl: './push-trigger-config.component.html',
  styleUrls: ['./push-trigger-config.component.scss']
})

export class PushTriggerConfigComponent implements OnInit {

  constructor() {

  }

  @Input() item: FormGroup = null;
  @Input() trigger: any = null;
  ngOnInit() {

  }
}
