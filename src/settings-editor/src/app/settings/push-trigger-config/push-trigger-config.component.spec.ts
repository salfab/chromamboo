import { NO_ERRORS_SCHEMA } from "@angular/core";
import { PushTriggerConfigComponent } from "./push-trigger-config.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("PushTriggerConfigComponent", () => {

  let fixture: ComponentFixture<PushTriggerConfigComponent>;
  let component: PushTriggerConfigComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [PushTriggerConfigComponent]
    });

    fixture = TestBed.createComponent(PushTriggerConfigComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
