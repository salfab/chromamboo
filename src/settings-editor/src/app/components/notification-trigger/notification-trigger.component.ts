import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'notification-trigger',
  templateUrl: './notification-trigger.component.html',
  styleUrls: ['./notification-trigger.component.scss']
})

export class NotificationTriggerComponent implements OnInit {

  constructor() {

  }
  @Input() trigger: any = null;

  ngOnInit() {

  }
}
