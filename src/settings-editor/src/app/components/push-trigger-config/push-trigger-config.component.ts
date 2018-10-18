import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'push-trigger-config',
  templateUrl: './push-trigger-config.component.html',
  styleUrls: ['./push-trigger-config.component.scss']
})

export class PushTriggerConfigComponent implements OnInit {

  constructor(private fb: FormBuilder) {

  }

  @Input() item: FormGroup = null;
  @Input() trigger: any = null;
  ngOnInit() {
    this.item.addControl('message', this.fb.control(this.trigger.message));
    this.item.addControl('url', this.fb.control(this.trigger.url));
  }
}
