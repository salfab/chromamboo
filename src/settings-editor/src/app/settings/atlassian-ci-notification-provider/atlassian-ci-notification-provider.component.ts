import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';
import { Store } from '@ngrx/store';

@Component({
  selector: 'atlassian-ci-notification-provider',
  templateUrl: './atlassian-ci-notification-provider.component.html',
  styleUrls: ['./atlassian-ci-notification-provider.component.scss']
})

export class AtlassianCiNotificationProviderComponent implements OnInit {

  constructor(private fb: FormBuilder) {

  }

  @Input() notification: any = null;
  @Input() item: FormGroup = null;

  ngOnInit() {
    this.item.addControl('planKey', this.fb.control(this.notification.planKey));
    this.item.addControl('username', this.fb.control(this.notification.username));
    this.item.addControl('bitbucketSettings', this.fb.group({
      apiBaseUrl: this.fb.control(this.notification.bitbucketSettings.apiBaseUrl),
      username: this.fb.control(this.notification.bitbucketSettings.username),
      password: this.fb.control(this.notification.bitbucketSettings.password),
      projectKey: this.fb.control(this.notification.bitbucketSettings.projectKey),
      repoSlug: this.fb.control(this.notification.bitbucketSettings.repoSlug)
    }));
    this.item.addControl('bambooSettings', this.fb.group({
      apiBaseUrl: this.fb.control(this.notification.bambooSettings.apiBaseUrl),
      username: this.fb.control(this.notification.bambooSettings.username),
      password: this.fb.control(this.notification.bambooSettings.password)
    }));
  }
}
