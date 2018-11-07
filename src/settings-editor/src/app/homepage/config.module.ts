import { ChromambooSettingsComponent } from './chromamboo-settings/chromamboo-settings.component';
// tslint:disable-next-line:max-line-length
import { AtlassianCiNotificationProviderComponent } from '../settings/atlassian-ci-notification-provider/atlassian-ci-notification-provider.component';
import { BlyncPresentationProviderComponent } from '../settings//blync-presentation-provider/blync-presentation-provider.component';
// tslint:disable-next-line:max-line-length
import { RazerPresentationKeysProviderComponent } from '../settings//razer-presentation-keys-provider/razer-presentation-keys-provider.component';
// tslint:disable-next-line:max-line-length
import { RazerPresentationGitProviderComponent } from '../settings/razer-presentation-git-provider/razer-presentation-git-provider.component';
import { PresentationSelectorComponent } from '../settings/presentation-selector/presentation-selector.component';
import { PushTriggerConfigComponent } from '../settings/push-trigger-config/push-trigger-config.component';
import { BrowserModule } from '@angular/platform-browser';
import { NotificationConfigComponent } from './notification-config/notification-config.component';
import { NgModule } from '@angular/core';
import { TriggerSelectorComponent } from '../settings/trigger-selector/trigger-selector.component';
import { PollingTriggerConfigComponent } from '../settings/polling-trigger-config/polling-trigger-config.component';
import { NotificationProviderSelectorComponent } from '../settings/notification-provider-selector/notification-provider-selector.component';
import { GitNotificationProviderComponent } from '../settings/git-notification-provider/git-notification-provider.component';
// tslint:disable-next-line:max-line-length
import { PullRequestNotificationProviderComponent } from '../settings/pull-request-notification-provider/pull-request-notification-provider.component';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { reducer } from './state/homepage.reducer';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    StoreModule.forFeature('homepage', reducer)],
  declarations: [
    ChromambooSettingsComponent,
    NotificationConfigComponent,
    TriggerSelectorComponent,
    PollingTriggerConfigComponent,
    PushTriggerConfigComponent,
    PresentationSelectorComponent,
    RazerPresentationKeysProviderComponent,
    RazerPresentationGitProviderComponent,
    BlyncPresentationProviderComponent,
    NotificationProviderSelectorComponent,
    GitNotificationProviderComponent,
    PullRequestNotificationProviderComponent,
    AtlassianCiNotificationProviderComponent],
  exports: [ChromambooSettingsComponent]

})
export class ConfigModule { }
