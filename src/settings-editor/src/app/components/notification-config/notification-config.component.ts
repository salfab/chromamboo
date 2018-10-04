import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'notification-config',
  templateUrl: './notification-config.component.html',
  styleUrls: ['./notification-config.component.scss']
})


export class NotificationConfigComponent implements OnInit {
  constructor() {
  }
  @Input() notification: any = null;

  ngOnInit() {

  }
}
