import { Action } from '@ngrx/store';
import {User} from '../../models/user';

export const LOAD_USER = '[User] Load User';

export class UserLoadAction implements Action {
  readonly type = LOAD_USER;
}

export const LOAD_USER_SUCCESS = '[Action] Load User Success';

export class UserLoadSuccessAction implements Action {
  readonly type = LOAD_USER_SUCCESS;

  constructor(public payload: User) { }
}

export const LOAD_USER_FAILURE = '[Action] Load User Failure';

export class UserLoadFailureAction implements Action {
  readonly type = LOAD_USER_FAILURE;

  constructor(public payload: any) { }
}

export const ADD_USER = '[User] Add User';

export class UserAddAction implements Action {
  readonly type = ADD_USER;

  constructor(public payload: User) { }
}

export const ADD_USER_SUCCESS = '[User] Add User Success';

export class UserAddSuccessAction implements Action {
  readonly type = ADD_USER_SUCCESS;

  constructor(public payload: User) { }
}

export const ADD_USER_FAILURE = '[User] Add User Failure';

export class UserAddFailureAction implements Action {
  readonly type = ADD_USER_FAILURE;

  constructor(public payload: any) { }
}

export const DELETE_USER = '[User] Delete User';

export class UserDeleteAction implements Action {
  readonly type = DELETE_USER;

  constructor(public payload: User) { }
}

export const DELETE_USER_SUCCESS = '[User] Delete User Success';

export class UserDeleteSuccessAction implements Action {
  readonly type = DELETE_USER_SUCCESS;

  constructor(public payload: User) { }
}

export const DELETE_USER_FAILURE = '[User] Delete User Failure';

export class UserDeleteFailureAction implements Action {
  readonly type = DELETE_USER_FAILURE;

  constructor(public payload: any) { }
}

export const MODIFY_USER = '[User] Modify User';

export class UserModifyAction implements Action {
  readonly type = MODIFY_USER;

  constructor(public payload: User) { }
}

export const MODIFY_USER_SUCCESS = '[User] Modify User Success';

export class UserModifySuccessAction implements Action {
  readonly type = MODIFY_USER_SUCCESS;

  constructor(public payload: User) { }
}

export const MODIFY_USER_FAILURE = '[User] Modify User Failure';

export class UserModifyFailureAction implements Action {
  readonly type = MODIFY_USER_FAILURE;

  constructor(public payload: any) { }
}

export const LOAD_USERS = '[User] Load Users';

export class UsersLoadAction implements Action {
  readonly type = LOAD_USERS;
}

export const LOAD_USERS_SUCCESS = '[User] Load Users Success';

export class UsersLoadSuccessAction implements Action {
  readonly type = LOAD_USERS_SUCCESS;

  constructor(public payload: User[]) { }
}

export const LOAD_USERS_FAILURE = '[User] Load Users Failure';

export class UsersLoadFailureAction implements Action {
  readonly type = LOAD_USERS_FAILURE;

  constructor(public payload: any) { }
}

export type Actions
  = UserLoadAction
  | UserLoadSuccessAction
  | UserLoadFailureAction
  | UserAddAction
  | UserAddSuccessAction
  | UserAddFailureAction
  | UserDeleteAction
  | UserDeleteSuccessAction
  | UserDeleteFailureAction
  | UserModifyAction
  | UserModifySuccessAction
  | UserModifyFailureAction
  | UsersLoadAction
  | UsersLoadSuccessAction
  | UsersLoadFailureAction;
