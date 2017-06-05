import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { reducer } from './core/store/reducers';
import {CoreModule} from './core/core.module';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';

import 'hammerjs';
import { InventoryService } from './core/services/inventory.service';
import {CreateInventoryComponent} from './containers/admin/inventory-page/create-inventory/create-inventory.component';
import { DeleteInventoryComponent } from './containers/admin/inventory-page/delete-inventory/delete-inventory.component';
import { AddProductComponent } from './containers/admin/inventory-page/add-product/add-product.component';
import {StoreModule} from '@ngrx/store';
import {InventoryEffects} from './core/store/effects/inventory';
import {EffectsModule} from '@ngrx/effects';

const devModules = environment.production ? [] : [
];

@NgModule({
  declarations: [
    AppComponent,
    UserPageComponent,
    InventoryPageComponent,
    OrderPageComponent,
    HomePageComponent,
    LoginPageComponent,
    CreateInventoryComponent,
    DeleteInventoryComponent,
    AddProductComponent
  ],

  imports: [
    // CoreModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    // CoreModule,
    RouterModule.forRoot(routes),
    StoreModule.provideStore(reducer), // for now only, transfer to core module later
    EffectsModule.run(InventoryEffects),
    // ...devModules,
    StoreDevtoolsModule.instrumentOnlyWithExtension(),
    MaterialModule
    //
  ],

  providers: [ InventoryService ],
  entryComponents: [
    CreateInventoryComponent,
    DeleteInventoryComponent,
    AddProductComponent ],
  bootstrap: [ AppComponent ]
})

export class AppModule { }
