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


  private _selectedNotification: any;
  public get selectedNotification(): any {
    return this._selectedNotification;
  }
  public set selectedNotification(v: any) {
    this._selectedNotification = v;
  }

  private _selectedNotificationIndex: number;

  constructor(private fb: FormBuilder, private store: Store<any>) {
  }
  @Input() config: any = null;

public get notification(): FormArray {
  return <FormArray>this.rootFormGroup.get('notification');
}
  ngOnInit() {
    this.rootFormGroup = this.fb.group({
      notification: this.fb.group({})
    });

    this.store.pipe(select('homepage')).subscribe(
      app => {
        this._selectedNotification = app.selectedNotification;
        this._selectedNotificationIndex = app.selectedNotificationIndex;
      }
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

  selectedNotificationChanged (value: any) {
    this.store.dispatch({
      type: 'selected_notification_index_changed',
      payload: value
    });
  }
  save ($event: Event) {
    console.log(this.rootFormGroup.value);
  }
}
