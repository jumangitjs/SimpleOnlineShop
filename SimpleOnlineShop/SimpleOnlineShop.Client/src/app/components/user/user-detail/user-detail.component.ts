import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { User } from '../../../core/models/user';

import * as action_ from '../../../core/store/actions/user';
import * as fromRoot from '../../../core/store/reducers/index';
import { ActivatedRoute } from '@angular/router';

import '@ngrx/core/add/operator/select';
import 'rxjs/add/operator/map';

import { Location } from '@angular/common';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})

export class UserDetailComponent implements OnInit {
  user: User;
  location: Location;

  constructor(private store: Store<fromRoot.State>,
              private route: ActivatedRoute,
              private location$: Location) { this.location = location$; }

  ngOnInit() {
    this.route.params
      .select<string>('id')
      .map(id => this.store.dispatch(new action_
        .UserLoadAction(parseInt(id, 10))))
      .subscribe();

   this.store.select(fromRoot.user).subscribe(res =>  this.user = res);
  }

  goBack() {
    this.location.back();
  }

  deleteUser() {
    console.log('delete works!');
  }

}
