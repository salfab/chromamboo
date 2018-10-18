import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'notification-trigger',
  templateUrl: './notification-trigger.component.html',
  styleUrls: ['./notification-trigger.component.scss']
})

export class NotificationTriggerComponent implements OnInit {

  constructor() {

  }

  @Input() item: FormGroup = null;
  @Input() trigger: any = null;

  ngOnInit() {

  }
}
