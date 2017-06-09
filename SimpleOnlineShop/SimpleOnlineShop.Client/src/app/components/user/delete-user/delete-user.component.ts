import { Component, OnInit } from '@angular/core';
import { MdDialogRef } from '@angular/material';
import {Store} from '@ngrx/store';

import * as fromRoot from '../../../core/store/reducers/index';
import * as action_ from '../../../core/store/actions/user';
import {Observable} from 'rxjs/Observable';
import {User} from '../../../core/models/user';

@Component({
  selector: 'app-delete-user',
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.css']
})
export class DeleteUserComponent implements OnInit {

  user$: Observable<User>;

  constructor(private dialogRef: MdDialogRef<DeleteUserComponent>,
              private store: Store<fromRoot.State>) { }

  ngOnInit() {
    this.user$ = this.store.select(fromRoot.user);
  }

  onSubmit() {
    this.user$.subscribe(user => {
      this.store.dispatch(new action_.UserDeleteAction(user.id));
    });
    this.dialogRef.close();
  }
}
