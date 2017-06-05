import { Routes } from '@angular/router/router';

import {HomePageComponent} from '../containers/admin/home-page/home-page.component';
import {AuthGuard} from '../core/guards/auth.guard';
import {InventoryPageComponent} from '../containers/admin/inventory-page/inventory-page.component';
import {UserPageComponent} from '../containers/admin/user-page/user-page.component';
import {LoginPageComponent} from '../containers/login-page/login-page.component';
import {OrderPageComponent} from '../containers/admin/order-page/order-page.component';

export const routes: Routes = [
  {
    path: 'home',
    component: HomePageComponent,
    // canActivate: [AuthGuard], add later
    children: [
      {
        path: 'inventory',
        component: InventoryPageComponent
      },
      {
        path: 'order',
        component: OrderPageComponent
      },
      {
        path: 'user',
        component: UserPageComponent
      }
    ]
  },
  {
    path: 'login',
    component: LoginPageComponent
  },
  {
    path: '**',
    redirectTo: 'home'
  }
];
