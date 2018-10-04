import { NO_ERRORS_SCHEMA } from "@angular/core";
import { RazerPresentationProviderComponent } from "./razer-presentation-provider.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("RazerPresentationProviderComponent", () => {

  let fixture: ComponentFixture<RazerPresentationProviderComponent>;
  let component: RazerPresentationProviderComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [RazerPresentationProviderComponent]
    });

    fixture = TestBed.createComponent(RazerPresentationProviderComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
