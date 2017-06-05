import { Injectable } from '@angular/core';
import { Actions, Effect } from '@ngrx/effects';
import { UserService } from '../../services/user.service';

import * as user from '../actions/user';

@Injectable()
export class UserEffects {

  // @Effect()
  // loadUser$ = this.action$
  //   .ofType(user.LOAD_USER)
  //   .startWith(new user.UserLoadAction())
  //   .switchMap(() => {
  //     this.service.
  //   })

  constructor(private action$: Actions,
              private service: UserService) { }
}
