import * as fromInventories from '../actions/inventory';
import { Inventory } from '../../models/inventory';

export interface State {
  loading: boolean;
  loaded: boolean;
  inventories: Inventory[];
}

export const initialState: State = {
  loading: false,
  loaded: false,
  inventories: []
};

export function reducer(state = initialState, action: fromInventories.Actions) {
  switch (action.type) {
    case fromInventories.LOAD_INVENTORIES:
      return Object.assign({}, state, {
        loading: true
      });
    case fromInventories.LOAD_INVENTORIES_SUCCESS:
      return {
        loading: false,
        loaded: true,
        inventories: action.payload
      };
    case fromInventories.LOAD_INVENTORIES_FAILURE:
      return Object.assign({}, state, {
        loading: false
      });

    default:
      return state;
  }
}

export const loading = (state: State) => state.loading;
export const loaded = (state: State) => state.loaded;
export const inventories = (state: State) => state.inventories;
