import { NO_ERRORS_SCHEMA } from "@angular/core";
import { PresentationSelectorComponent } from "./presentation-selector.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("PresentationSelectorComponent", () => {

  let fixture: ComponentFixture<PresentationSelectorComponent>;
  let component: PresentationSelectorComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [PresentationSelectorComponent]
    });

    fixture = TestBed.createComponent(PresentationSelectorComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
