import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'razer-presentation-keys-provider',
  templateUrl: './razer-presentation-keys-provider.component.html',
  styleUrls: ['./razer-presentation-keys-provider.component.scss']
})

export class RazerPresentationKeysProviderComponent implements OnInit {

  constructor(private fb: FormBuilder) {

  }
  @Input() presentation: any = null;
  @Input() item: FormGroup = null;
  ngOnInit() {
    this.item.addControl('keys', this.fb.control(this.presentation.keys));
  }
}
