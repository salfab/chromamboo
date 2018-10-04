import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'blync-presentation-provider',
  templateUrl: './blync-presentation-provider.component.html',
  styleUrls: ['./blync-presentation-provider.component.scss']
})

export class BlyncPresentationProviderComponent implements OnInit {

  constructor() {

  }
  @Input() presentationProvider: any = null;
  ngOnInit() {

  }
}
