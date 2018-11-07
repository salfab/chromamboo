import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'notification-provider-selector',
  templateUrl: './notification-provider-selector.component.html',
  styleUrls: ['./notification-provider-selector.component.scss']
})

export class NotificationProviderSelectorComponent implements OnInit {

  constructor() {

  }
  @Input() notification: any = null;
  @Input() item: FormGroup = null;
  ngOnInit() {

  }
}
