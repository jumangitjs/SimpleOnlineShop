import * as fromInventory from '../actions/inventory';
import {Inventory} from '../../models/inventory';

export interface State {
  loading: boolean;
  loaded: boolean;
  inventory: Inventory;
}

export const initialState: State = {
  loading: false,
  loaded: false,
  inventory: null
};

export function reducer(state = initialState, action: fromInventory.Actions) {
  switch (action.type) {
    case fromInventory.LOAD_INVENTORY:
      return Object.assign({}, state, {
        loading: true
      });

    case fromInventory.LOAD_INVENTORY_SUCCESS:
      return {
        loading: false,
        loaded: true,
        inventory: action.payload
      };

    case fromInventory.LOAD_INVENTORY_FAILURE:
      return Object.assign({}, state, {
        loading: false
      });

    case fromInventory.ADD_INVENTORY_SUCCESS:
      return Object.assign({}, state, {
        inventory: action.payload
      });

    case fromInventory.DELETE_INVENTORY_SUCCESS:
      return Object.assign({}, state, {
        inventory: action.payload
      });

    case fromInventory.MODIFY_INVENTORY_SUCCESS:
      return Object.assign({}, state, {
        inventory: action.payload
      });

    case fromInventory.ADD_INVENTORY_PRODUCT_TO_INVENTORY_SUCCESS:
      return Object.assign({}, state, {
        inventory: action.payload
      });

    case fromInventory.DELETE_INVENTORY_PRODUCT_TO_INVENTORY_SUCCESS:
      return Object.assign({}, state, {
        inventory: action.payload
      });

    default:
      return state;
  }
}

export const loading = (state: State) => state.loading;
export const loaded = (state: State) => state.loaded;
export const inventory = (state: State) => state.inventory;
