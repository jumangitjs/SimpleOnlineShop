import {Component, OnInit, Input} from '@angular/core';

import { Store } from '@ngrx/store';
import { User } from '../../../core/models/user';
import { Observable } from 'rxjs/Observable';

import * as fromRoot from '../../../core/store/reducers/index';
import * as action_ from '../../../core/store/actions/user';
import delay from 'delay';
import {MdDialog} from '@angular/material';
import {CreateUserComponent} from '../../../components/user/create-user/create-user.component';
import {DeleteUserComponent} from '../../../components/user/delete-user/delete-user.component';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit {
  users$: Observable<User[]>;
  path: boolean;
  @Input() user: User;

  constructor(private store: Store<fromRoot.State>,
              private mdCreate: MdDialog,
              private mdDelete: MdDialog) { }

  ngOnInit() {
    this.store.dispatch(new action_.UsersLoadAction());
    this.users$ = this.store.select(fromRoot.users);

    this.store.select(fromRoot.routerState).subscribe(res =>
      this.path = (res.path.toString() === '/home/user'));
  }

  create() {
    this.mdCreate.open(CreateUserComponent, {
      width: '400px',
      height: '450px'
    });
  }
}
