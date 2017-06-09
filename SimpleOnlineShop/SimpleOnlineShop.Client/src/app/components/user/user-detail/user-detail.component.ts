import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { User } from '../../../core/models/user';

import * as action_ from '../../../core/store/actions/user';
import * as fromRoot from '../../../core/store/reducers/index';
import { ActivatedRoute } from '@angular/router';

import '@ngrx/core/add/operator/select';
import 'rxjs/add/operator/map';

import { Location } from '@angular/common';
import {Observable} from 'rxjs/Observable';
import {MdDialog} from '@angular/material';
import {DeleteUserComponent} from '../delete-user/delete-user.component';
import {AddOrderComponent} from '../add-order/add-order.component';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})

export class UserDetailComponent implements OnInit {
  location: Location;
  loading$: Observable<boolean>;
  user$: Observable<User>;

  constructor(private store: Store<fromRoot.State>,
              private route: ActivatedRoute,
              private location$: Location,
              private mdDelete: MdDialog,
              private mdOrder: MdDialog) { this.location = location$; }

  ngOnInit() {
    this.route.params
      .select<string>('id')
      .map(id => this.store.dispatch(new action_
        .UserLoadAction(parseInt(id, 10))))
      .subscribe();

    this.loading$ = this.store.select(fromRoot.isUserLoading);
    this.user$ = this.store.select(fromRoot.user);
  }

  goBack() {
    this.location.back();
  }

  deleteUser() {
    console.log('delete works!');
    this.mdDelete.open(DeleteUserComponent, {
      width: '400px',
      height: '150px',
    });
    this.mdDelete.afterAllClosed
      .debounceTime(200)
      .subscribe(() => {
        this.store.dispatch(new action_.UsersLoadAction());
        this.goBack();
      });
  }
  addOrder() {
    this.mdDelete.open(AddOrderComponent, {
      width: '400px',
      height: '500px',
    });
  }
}
