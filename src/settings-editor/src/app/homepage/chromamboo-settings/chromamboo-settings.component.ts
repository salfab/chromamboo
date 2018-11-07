import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray } from '@angular/forms';
import { Store, select } from '@ngrx/store';

@Component({
  selector: 'chromamboo-settings',
  templateUrl: './chromamboo-settings.component.html',
  styleUrls: ['./chromamboo-settings.component.scss']
})

export class ChromambooSettingsComponent implements OnInit {
  rootFormGroup: FormGroup;


  private _selectedNotification: number
  ;
  public get selectedNotification(): number {
    return this._selectedNotification;
  }
  public set selectedNotification(v: number) {
    this._selectedNotification = v;
  }

  constructor(private fb: FormBuilder, private store: Store<any>) {
  }
  @Input() config: any = null;

public get notifications(): FormArray {
  return <FormArray>this.rootFormGroup.get('notifications');
}


  ngOnInit() {
    this.rootFormGroup = this.fb.group({
      notifications: this.fb.array(this.buildNotifications(this.config.notifications))
    });

    this.store.pipe(select('homepage')).subscribe(
      app => this._selectedNotification = app.selectedNotification
    );
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

  selectedNotificationChanged (value: number) {
    console.log('dispatch');
    this.store.dispatch({
      type: 'selected_notification_changed',
      payload: value
    });
    console.log('end dispatch');
  }
  save ($event: Event) {
    console.log(this.rootFormGroup.value);
  }
}
