import { SettingsModule } from './settings/settings.module';
import { ConfigModule } from './components/config.module';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoreModule} from '@ngrx/store';
import { reducer } from './settings/state/settings.reducer';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ConfigModule,
    StoreModule.forRoot({reducer}),
    SettingsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
