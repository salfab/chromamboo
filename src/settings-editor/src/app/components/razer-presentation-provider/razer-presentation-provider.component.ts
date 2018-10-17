import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'razer-presentation-provider',
  templateUrl: './razer-presentation-provider.component.html',
  styleUrls: ['./razer-presentation-provider.component.scss']
})

export class RazerPresentationProviderComponent implements OnInit {

  constructor(private fb: FormBuilder) {

  }
  @Input() presentation: any = null;
  @Input() item: FormGroup = null;
  ngOnInit() {
    this.item.addControl('keys', this.fb.control(this.presentation.keys));
  }
}
