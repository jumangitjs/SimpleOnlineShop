import { ActionReducer, combineReducers } from '@ngrx/store';
import { compose } from '@ngrx/core';
import { storeFreeze } from 'ngrx-store-freeze';
import { environment } from '../../../../environments/environment';

import * as fromRouter from '@ngrx/router-store';

import * as fromInventory from './inventory';
import * as fromInventories from './inventories';
import * as fromUser from './user';
import * as fromUsers from './users_';

import { createSelector } from 'reselect';

export interface State {
  router: fromRouter.RouterState;
  inventory: fromInventory.State;
  inventories: fromInventories.State;
  user: fromUser.State;
  users: fromUsers.State;
}

export const initialState: State = {
  router: fromRouter.initialState,
  inventory: fromInventory.initialState,
  inventories: fromInventories.initialState,
  user: fromUser.initialState,
  users: fromUsers.initialState
};

const reducers = {
  router: fromRouter.routerReducer,
  inventory: fromInventory.reducer,
  inventories: fromInventories.reducer,
  user: fromUser.reducer,
  users: fromUsers.reducer
};

const developmentReducer: ActionReducer<State> = compose(storeFreeze, combineReducers)(reducers);
const productionReducer: ActionReducer<State> = combineReducers(reducers);

export function reducer(state: any, action: any){
  if (environment.production) {
    return productionReducer(state, action);
  } else {
    return developmentReducer(state, action);
  }
}

export const routerState = (state: State) => state.router;
export const inventoryState = (state: State) => state.inventory;
export const inventoriesState = (state: State) => state.inventories;
export const userState = (state: State) => state.user;
export const usersState = (state: State) => state.users;

export const isInventoryLoading = createSelector(inventoryState, fromInventory.loading);
export const isInventoryLoaded = createSelector(inventoryState, fromInventory.loaded);
export const inventory = createSelector(inventoryState, fromInventory.inventory);

export const areInventoriesLoading = createSelector(inventoriesState, fromInventories.loading);
export const areInventoriesLoaded = createSelector(inventoriesState, fromInventories.loaded);
export const inventories = createSelector(inventoriesState, fromInventories.inventories);

export const isUserLoading = createSelector(userState, fromUser.loading);
export const isUserLoaded = createSelector(userState, fromUser.loaded);
export const user = createSelector(userState, fromUser.user);

export const areUsersLoading = createSelector(usersState, fromUsers.loading);
export const areUsersLoaded = createSelector(usersState, fromUsers.loaded);
export const users = createSelector(usersState, fromUsers.users);
