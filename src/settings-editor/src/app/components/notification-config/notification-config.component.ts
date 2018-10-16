import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray } from '@angular/forms';

@Component({
  selector: 'notification-config',
  templateUrl: './notification-config.component.html',
  styleUrls: ['./notification-config.component.scss']
})


export class NotificationConfigComponent implements OnInit {
  constructor(private fb: FormBuilder) {
  }
  @Input() notification: any = null;

  @Input() item: FormGroup = null;
  ngOnInit() {
    this.item.addControl('displayName', new FormControl(this.notification.displayName));
    const presentationFormGroups: FormGroup[] = [];
    for (const presentationGroup of this.notification.presentation) {
      presentationFormGroups.push(presentationGroup);
    }
    this.item.addControl('presentation', this.fb.array(presentationFormGroups));
  }
}
