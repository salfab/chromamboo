import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'trigger-selector',
  templateUrl: './trigger-selector.component.html',
  styleUrls: ['./trigger-selector.component.scss']
})

export class TriggerSelectorComponent implements OnInit {

  constructor() {

  }

  @Input() item: FormGroup = null;
  @Input() trigger: any = null;

  ngOnInit() {

  }
}
