import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'presentation-selector',
  templateUrl: './presentation-selector.component.html',
  styleUrls: ['./presentation-selector.component.scss']
})

export class PresentationSelectorComponent implements OnInit {

  constructor() {

  }

  @Input() notification: any = null;
  @Input() presentation: any = null;
  @Input() item: FormGroup = null;

  ngOnInit() {

  }
}
