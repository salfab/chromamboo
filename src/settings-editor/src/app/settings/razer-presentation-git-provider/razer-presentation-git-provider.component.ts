import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'razer-presentation-git-provider',
  templateUrl: './razer-presentation-git-provider.component.html',
  styleUrls: ['./razer-presentation-git-provider.component.scss']
})

export class RazerPresentationGitProviderComponent implements OnInit {

  constructor(private fb: FormBuilder) {

  }
  @Input() presentation: any = null;
  @Input() item: FormGroup = null;
  ngOnInit() {
    this.item.addControl('keyUncommitted', this.fb.control(this.presentation.keyUncommitted));
    this.item.addControl('keyBehindDevelop', this.fb.control(this.presentation.keyBehindDevelop));
  }
}
