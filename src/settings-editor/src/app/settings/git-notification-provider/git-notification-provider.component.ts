import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'git-notification-provider',
  templateUrl: './git-notification-provider.component.html',
  styleUrls: ['./git-notification-provider.component.scss']
})

export class GitNotificationProviderComponent implements OnInit {

  constructor(private fb: FormBuilder) {

  }

  @Input() notification: any = null;
  @Input() item: FormGroup = null;

  ngOnInit() {
    this.item.addControl('repositoryPath', this.fb.control(this.notification.repositoryPath));
  }
}
