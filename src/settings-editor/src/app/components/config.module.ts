import { BlyncPresentationProviderComponent } from './blync-presentation-provider/blync-presentation-provider.component';
import { RazerPresentationProviderComponent } from './razer-presentation-provider/razer-presentation-provider.component';
import { PresentationSelectorComponent } from './presentation-selector/presentation-selector.component';
import { PushTriggerConfigComponent } from './push-trigger-config/push-trigger-config.component';
import { BrowserModule } from '@angular/platform-browser';
import { NotificationConfigComponent } from './notification-config/notification-config.component';
import { NgModule } from '@angular/core';
import { NotificationTriggerComponent } from './notification-trigger/notification-trigger.component';
import { PollingTriggerConfigComponent } from './polling-trigger-config/polling-trigger-config.component';

@NgModule({
  declarations: [
    NotificationConfigComponent,
    NotificationTriggerComponent,
    PollingTriggerConfigComponent,
    PushTriggerConfigComponent,
    PresentationSelectorComponent,
    RazerPresentationProviderComponent,
    BlyncPresentationProviderComponent],
  imports: [BrowserModule],
  exports: [NotificationConfigComponent]

})
export class ConfigModule { }
