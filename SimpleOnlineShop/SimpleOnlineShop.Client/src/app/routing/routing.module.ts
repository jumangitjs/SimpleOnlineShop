import { Routes } from '@angular/router/router';

import {HomePageComponent} from '../containers/admin/home-page/home-page.component';
import {AuthGuard} from '../core/guards/auth.guard';
import {InventoryPageComponent} from '../containers/admin/inventory-page/inventory-page.component';
import {UserPageComponent} from '../containers/admin/user-page/user-page.component';
import {LoginPageComponent} from '../containers/login-page/login-page.component';
import {UserDetailComponent} from '../components/user/user-detail/user-detail.component';

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
        path: 'user',
        component: UserPageComponent,
      },
      {
        path: 'user/:id',
        component: UserDetailComponent
      },
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
