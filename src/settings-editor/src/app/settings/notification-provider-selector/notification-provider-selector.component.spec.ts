import { NO_ERRORS_SCHEMA } from "@angular/core";
import { NotificationProviderSelectorComponent } from "./notification-provider-selector.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("NotificationProviderSelectorComponent", () => {

  let fixture: ComponentFixture<NotificationProviderSelectorComponent>;
  let component: NotificationProviderSelectorComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [NotificationProviderSelectorComponent]
    });

    fixture = TestBed.createComponent(NotificationProviderSelectorComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
