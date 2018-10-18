import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'pull-request-provider',
  templateUrl: './pull-request-provider.component.html',
  styleUrls: ['./pull-request-provider.component.scss']
})

export class PullRequestProviderComponent implements OnInit {

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
  }
}
