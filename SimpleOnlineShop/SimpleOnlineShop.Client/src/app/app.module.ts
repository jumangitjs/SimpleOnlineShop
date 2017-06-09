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
import { HomePageComponent } from './containers/admin/home-page/home-page.component';
import { LoginPageComponent } from './containers/login-page/login-page.component';

import { routes } from './routing/routing.module';
import { environment } from '../environments/environment';
import { reducer } from './core/store/reducers';
import { CoreModule } from './core/core.module';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';

import 'hammerjs';
import { InventoryService } from './core/services/inventory.service';
import { CreateInventoryComponent } from './components/inventory/create-inventory/create-inventory.component';
import { DeleteInventoryComponent } from './components/inventory/delete-inventory/delete-inventory.component';
import { AddProductComponent } from './components/inventory/add-product/add-product.component';
import { StoreModule } from '@ngrx/store';
import { InventoryEffects } from './core/store/effects/inventory';
import { EffectsModule } from '@ngrx/effects';
import { RouterStoreModule } from '@ngrx/router-store';
import { UserEffects } from './core/store/effects/user';
import { UserService } from './core/services/user.service';
import { UserDetailComponent } from './components/user/user-detail/user-detail.component';
import { DeleteUserComponent } from './components/user/delete-user/delete-user.component';
import { CreateUserComponent } from './components/user/create-user/create-user.component';
import { AddOrderComponent } from './components/user/add-order/add-order.component';
import {FlexLayoutModule} from '@angular/flex-layout';

const devModules = environment.production ? [] : [
  StoreDevtoolsModule.instrumentOnlyWithExtension(),
  MaterialModule,
];

@NgModule({
  declarations: [
    AppComponent,
    UserPageComponent,
    InventoryPageComponent,
    HomePageComponent,
    LoginPageComponent,
    CreateInventoryComponent,
    DeleteInventoryComponent,
    AddProductComponent,
    UserDetailComponent,
    DeleteUserComponent,
    CreateUserComponent,
    AddOrderComponent
  ],

  imports: [
    BrowserAnimationsModule,
    NoopAnimationsModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    FlexLayoutModule,
    // CoreModule,
    RouterModule.forRoot(routes),
    StoreModule.provideStore(reducer), // for now only, transfer to core module later
    EffectsModule.run(InventoryEffects),
    EffectsModule.run(UserEffects),
    RouterStoreModule.connectRouter(),
    ...devModules,
    //
  ],

  providers: [ InventoryService, UserService ],

  entryComponents: [
    CreateInventoryComponent,
    DeleteInventoryComponent,
    AddProductComponent,
    DeleteUserComponent,
    CreateUserComponent,
    AddOrderComponent,
    AddOrderComponent
  ],

  bootstrap: [ AppComponent ]
})

export class AppModule { }
