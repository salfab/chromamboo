import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'polling-trigger-config',
  templateUrl: './polling-trigger-config.component.html',
  styleUrls: ['./polling-trigger-config.component.scss']
})

export class PollingTriggerConfigComponent implements OnInit {

  constructor(private fb: FormBuilder) {

  }
  @Input() trigger: any = null;
  @Input() item: FormGroup = null;

  ngOnInit() {
    this.item.addControl('frequence', this.fb.control(this.trigger.frequence));

  }
}
