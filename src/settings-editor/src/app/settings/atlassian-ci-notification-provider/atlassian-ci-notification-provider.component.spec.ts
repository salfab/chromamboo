import { NO_ERRORS_SCHEMA } from "@angular/core";
import { AtlassianCiNotificationProviderComponent } from "./atlassian-ci-notification-provider.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("AtlassianCiNotificationProviderComponent", () => {

  let fixture: ComponentFixture<AtlassianCiNotificationProviderComponent>;
  let component: AtlassianCiNotificationProviderComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [AtlassianCiNotificationProviderComponent]
    });

    fixture = TestBed.createComponent(AtlassianCiNotificationProviderComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
