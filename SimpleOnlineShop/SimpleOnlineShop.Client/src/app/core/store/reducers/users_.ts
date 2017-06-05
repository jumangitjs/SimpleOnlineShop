import * as fromUsers from '../actions/user';
import { User } from '../../models/user';

export interface State {
  loading: boolean;
  loaded: boolean;
  users: User[];
}

export const initialState: State = {
  loading: false,
  loaded: false,
  users: []
};

export function reducer(state = initialState, action: fromUsers.Actions) {
  switch (action.type) {
    case fromUsers.LOAD_USERS:
      return Object.assign({}, state, {
        loading: true
      });
    case fromUsers.LOAD_USERS_SUCCESS:
      return {
        loading: false,
        loaded: true,
        users: action.payload
      };
    case fromUsers.LOAD_USERS_FAILURE:
      return Object.assign({}, state, {
        loading: false
      });

    default:
      return state;
  }
}

export const loading = (state: State) => state.loading;
export const loaded = (state: State) => state.loaded;
export const users = (state: State) => state.users;
