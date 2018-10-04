import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'notification-provider-selector',
  templateUrl: './notification-provider-selector.component.html',
  styleUrls: ['./notification-provider-selector.component.scss']
})

export class NotificationProviderSelectorComponent implements OnInit {

  constructor() {

  }
  @Input() notificationProvider: any = null;
  ngOnInit() {

  }
}
