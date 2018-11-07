import { NO_ERRORS_SCHEMA } from '@angular/core';
import { PullRequestNotificationProviderComponent } from './pull-request-notification-provider.component';
import { ComponentFixture, TestBed } from '@angular/core/testing';

describe('PullRequestProviderComponent', () => {

  let fixture: ComponentFixture<PullRequestNotificationProviderComponent>;
  let component: PullRequestNotificationProviderComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [PullRequestNotificationProviderComponent]
    });

    fixture = TestBed.createComponent(PullRequestNotificationProviderComponent);
    component = fixture.componentInstance;

  });

  it('should be able to create component instance', () => {
    expect(component).toBeDefined();
  });

});
