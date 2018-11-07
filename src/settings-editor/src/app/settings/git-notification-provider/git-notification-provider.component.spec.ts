import { NO_ERRORS_SCHEMA } from "@angular/core";
import { GitNotificationProviderComponent } from "./git-notification-provider.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("GitNotificationProviderComponent", () => {

  let fixture: ComponentFixture<GitNotificationProviderComponent>;
  let component: GitNotificationProviderComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [GitNotificationProviderComponent]
    });

    fixture = TestBed.createComponent(GitNotificationProviderComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
