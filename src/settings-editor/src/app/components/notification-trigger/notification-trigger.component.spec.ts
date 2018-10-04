import { NO_ERRORS_SCHEMA } from "@angular/core";
import { NotificationTriggerComponent } from "./notification-trigger.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("NotificationTriggerComponent", () => {

  let fixture: ComponentFixture<NotificationTriggerComponent>;
  let component: NotificationTriggerComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [NotificationTriggerComponent]
    });

    fixture = TestBed.createComponent(NotificationTriggerComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
