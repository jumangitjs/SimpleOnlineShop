import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '@angular/material';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import { AppComponent } from './app.component';
import { UserPageComponent } from './containers/admin/user-page/user-page.component';
import { InventoryPageComponent } from './containers/admin/inventory-page/inventory-page.component';
import { OrderPageComponent } from './containers/admin/order-page/order-page.component';
import { HomePageComponent } from './containers/admin/home-page/home-page.component';
import { LoginPageComponent } from './containers/login-page/login-page.component';

import { routes } from './routing/routing.module';
import { environment } from '../environments/environment';
import {CoreModule} from './core/core.module';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';

import 'hammerjs';
import { InventoryService } from './core/services/inventory.service';

const devModules = environment.production ? [] : [
  StoreDevtoolsModule.instrumentOnlyWithExtension(),
  MaterialModule
];

@NgModule({
  declarations: [
    AppComponent,
    UserPageComponent,
    InventoryPageComponent,
    OrderPageComponent,
    HomePageComponent,
    LoginPageComponent
  ],
  imports: [
    // CoreModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(routes),
    ...devModules
  ],
  providers: [ InventoryService ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
