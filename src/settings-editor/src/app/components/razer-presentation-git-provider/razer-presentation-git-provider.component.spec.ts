import { NO_ERRORS_SCHEMA } from "@angular/core";
import { RazerPresentationGitProviderComponent } from "./razer-presentation-git-provider.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("RazerPresentationGitProviderComponent", () => {

  let fixture: ComponentFixture<RazerPresentationGitProviderComponent>;
  let component: RazerPresentationGitProviderComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [RazerPresentationGitProviderComponent]
    });

    fixture = TestBed.createComponent(RazerPresentationGitProviderComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
