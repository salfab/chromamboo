import { NO_ERRORS_SCHEMA } from "@angular/core";
import { PullRequestProviderComponent } from "./pull-request-provider.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("PullRequestProviderComponent", () => {

  let fixture: ComponentFixture<PullRequestProviderComponent>;
  let component: PullRequestProviderComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [PullRequestProviderComponent]
    });

    fixture = TestBed.createComponent(PullRequestProviderComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
