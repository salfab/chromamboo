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
      notifications: this.fb.array(this.config.notifications)
    });
  }
}
