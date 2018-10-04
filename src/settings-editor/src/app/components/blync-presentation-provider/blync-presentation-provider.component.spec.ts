import { NO_ERRORS_SCHEMA } from "@angular/core";
import { BlyncPresentationProviderComponent } from "./blync-presentation-provider.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("BlyncPresentationProviderComponent", () => {

  let fixture: ComponentFixture<BlyncPresentationProviderComponent>;
  let component: BlyncPresentationProviderComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [BlyncPresentationProviderComponent]
    });

    fixture = TestBed.createComponent(BlyncPresentationProviderComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
