import { NO_ERRORS_SCHEMA } from "@angular/core";
import { TriggerSelectorComponent } from "./trigger-selector.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("NotificationTriggerComponent", () => {

  let fixture: ComponentFixture<TriggerSelectorComponent>;
  let component: TriggerSelectorComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [TriggerSelectorComponent]
    });

    fixture = TestBed.createComponent(TriggerSelectorComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
