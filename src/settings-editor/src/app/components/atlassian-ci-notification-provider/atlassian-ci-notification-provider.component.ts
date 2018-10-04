import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'atlassian-ci-notification-provider',
  templateUrl: './atlassian-ci-notification-provider.component.html',
  styleUrls: ['./atlassian-ci-notification-provider.component.scss']
})

export class AtlassianCiNotificationProviderComponent implements OnInit {

  constructor() {

  }

  @Input() notificationProvider: any = null;
  ngOnInit() {

  }
}
