import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'razer-presentation-provider',
  templateUrl: './razer-presentation-provider.component.html',
  styleUrls: ['./razer-presentation-provider.component.scss']
})

export class RazerPresentationProviderComponent implements OnInit {

  constructor() {

  }
  @Input() presentationProvider: any = null;
  ngOnInit() {

  }
}
