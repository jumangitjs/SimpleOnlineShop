import * as fromUser from '../actions/user';
import { User } from '../../models/user';

export interface State {
  loading: boolean;
  loaded: boolean;
  user: User;
}

export const initialState: State = {
  loading: false,
  loaded: false,
  user: null
};

export function reducer(state = initialState, action: fromUser.Actions) {
  switch (action.type) {

    case fromUser.LOAD_USER:
      return Object.assign({}, state, {
        loading: true
      });

    case fromUser.LOAD_USER_SUCCESS:
      return {
        loading: false,
        loaded: true,
        user: action.payload
      };

    case fromUser.LOAD_USER_FAILURE:
      return Object.assign({}, state, {
        loading: false
      });

    case fromUser.ADD_USER_SUCCESS:
      return Object.assign({}, state, {
        user: action.payload
      });

    case fromUser.DELETE_USER_SUCCESS:
      return Object.assign({}, state, {
        user: action.payload
      });

    case fromUser.MODIFY_USER_SUCCESS:
      return Object.assign({}, state, {
        user: action.payload
      });

    default:
      return state;
  }
}

export const loading = (state: State) => state.loading;
export const loaded = (state: State) => state.loaded;
export const user = (state: State) => state.user;
