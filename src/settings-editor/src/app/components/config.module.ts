import { ChromambooSettingsComponent } from './chromamboo-settings/chromamboo-settings.component';
// tslint:disable-next-line:max-line-length
import { AtlassianCiNotificationProviderComponent } from './atlassian-ci-notification-provider/atlassian-ci-notification-provider.component';
import { BlyncPresentationProviderComponent } from './blync-presentation-provider/blync-presentation-provider.component';
import { RazerPresentationKeysProviderComponent } from './razer-presentation-keys-provider/razer-presentation-keys-provider.component';
import { RazerPresentationGitProviderComponent } from './razer-presentation-git-provider/razer-presentation-git-provider.component';
import { PresentationSelectorComponent } from './presentation-selector/presentation-selector.component';
import { PushTriggerConfigComponent } from './push-trigger-config/push-trigger-config.component';
import { BrowserModule } from '@angular/platform-browser';
import { NotificationConfigComponent } from './notification-config/notification-config.component';
import { NgModule } from '@angular/core';
import { NotificationTriggerComponent } from './notification-trigger/notification-trigger.component';
import { PollingTriggerConfigComponent } from './polling-trigger-config/polling-trigger-config.component';
import { NotificationProviderSelectorComponent } from './notification-provider-selector/notification-provider-selector.component';
import { GitNotificationProviderComponent } from './git-notification-provider/git-notification-provider.component';
import { PullRequestProviderComponent } from './pull-request-provider/pull-request-provider.component';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ChromambooSettingsComponent,
    NotificationConfigComponent,
    NotificationTriggerComponent,
    PollingTriggerConfigComponent,
    PushTriggerConfigComponent,
    PresentationSelectorComponent,
    RazerPresentationKeysProviderComponent,
    RazerPresentationGitProviderComponent,
    BlyncPresentationProviderComponent,
    NotificationProviderSelectorComponent,
    GitNotificationProviderComponent,
    PullRequestProviderComponent,
    AtlassianCiNotificationProviderComponent],
  imports: [BrowserModule, FormsModule, ReactiveFormsModule],
  exports: [ChromambooSettingsComponent]

})
export class ConfigModule { }
