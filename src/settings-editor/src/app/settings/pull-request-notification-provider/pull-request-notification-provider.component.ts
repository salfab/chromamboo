import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'pull-request-notification-provider',
  templateUrl: './pull-request-notification-provider.component.html',
  styleUrls: ['./pull-request-notification-provider.component.scss']
})

export class PullRequestNotificationProviderComponent implements OnInit {

  constructor(private fb: FormBuilder) {

  }

  @Input() notification: any = null;
  @Input() item: FormGroup = null;

  ngOnInit() {
    this.item.addControl('username', this.fb.control(this.notification.username));
    this.item.addControl('bitbucketSettings', this.fb.group({
      apiBaseUrl: this.fb.control(this.notification.bitbucketSettings.apiBaseUrl),
      username: this.fb.control(this.notification.bitbucketSettings.username),
      password: this.fb.control(this.notification.bitbucketSettings.password),
      projectKey: this.fb.control(this.notification.bitbucketSettings.projectKey),
      repoSlug: this.fb.control(this.notification.bitbucketSettings.repoSlug)
    }));
  }
}
