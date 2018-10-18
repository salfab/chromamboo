import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray } from '@angular/forms';

@Component({
  selector: 'chromamboo-settings',
  templateUrl: './chromamboo-settings.component.html',
  styleUrls: ['./chromamboo-settings.component.scss']
})

export class ChromambooSettingsComponent implements OnInit {
  rootFormGroup: FormGroup;

  constructor(private fb: FormBuilder) {
  }
  @Input() config: any = null;

public get notifications(): FormArray {
  return <FormArray>this.rootFormGroup.get('notifications');
}


  ngOnInit() {
    this.rootFormGroup = this.fb.group({
      notifications: this.fb.array(this.buildNotifications(this.config.notifications))
    });
  }
  buildNotifications(notifications: any[]): FormGroup[] {
    const groups: FormGroup[] = [];
    for (const notification of notifications) {
      const group = this.fb.group({
      });
      groups.push(group);
    }

    return groups;
  }

  save ($event: Event) {
    console.log(this.rootFormGroup.value);
  }
}
