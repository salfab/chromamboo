import { NO_ERRORS_SCHEMA } from '@angular/core';
import { NotificationConfigComponent } from './notification-config.component';
import { ComponentFixture, TestBed } from '@angular/core/testing';

describe('NotificationConfigComponent', () => {

  let fixture: ComponentFixture<NotificationConfigComponent>;
  let component: NotificationConfigComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [NotificationConfigComponent]
    });

    fixture = TestBed.createComponent(NotificationConfigComponent);
    component = fixture.componentInstance;

  });

  it('should be able to create component instance', () => {
    expect(component).toBeDefined();
  });
});
