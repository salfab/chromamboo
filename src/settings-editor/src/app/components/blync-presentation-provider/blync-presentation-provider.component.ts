import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'blync-presentation-provider',
  templateUrl: './blync-presentation-provider.component.html',
  styleUrls: ['./blync-presentation-provider.component.scss']
})

export class BlyncPresentationProviderComponent implements OnInit {

  constructor() {

  }
  @Input() item: FormGroup = null;
  @Input() presentation: any = null;
  ngOnInit() {
    this.item.addControl('selectedBlyncDevice', new FormControl(this.presentation.selectedBlyncDevice));
    this.item.addControl('numberOfExecutions', new FormControl(this.presentation.numberOfExecutions));
  }
}
