import { NO_ERRORS_SCHEMA } from "@angular/core";
import { ChromambooSettingsComponent } from "./chromamboo-settings.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("ChromambooSettingsComponent", () => {

  let fixture: ComponentFixture<ChromambooSettingsComponent>;
  let component: ChromambooSettingsComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [ChromambooSettingsComponent]
    });

    fixture = TestBed.createComponent(ChromambooSettingsComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
