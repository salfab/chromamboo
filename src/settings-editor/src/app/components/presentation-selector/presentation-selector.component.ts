import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'presentation-selector',
  templateUrl: './presentation-selector.component.html',
  styleUrls: ['./presentation-selector.component.scss']
})

export class PresentationSelectorComponent implements OnInit {

  constructor() {

  }

  @Input() presentationProvider: any = null;

  ngOnInit() {

  }
}
