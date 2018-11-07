import { NO_ERRORS_SCHEMA } from "@angular/core";
import { PollingTriggerConfigComponent } from "./polling-trigger-config.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("PollingTriggerConfigComponent", () => {

  let fixture: ComponentFixture<PollingTriggerConfigComponent>;
  let component: PollingTriggerConfigComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [PollingTriggerConfigComponent]
    });

    fixture = TestBed.createComponent(PollingTriggerConfigComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
