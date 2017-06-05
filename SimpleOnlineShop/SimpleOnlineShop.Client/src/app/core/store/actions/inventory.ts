import { Action } from '@ngrx/store';
import {Inventory} from '../../models/Inventory';
import {InventoryProduct} from '../../models/inventory-product';

export const LOAD_INVENTORY = '[Inventory] Load Inventory';

export class InventoryLoadAction implements Action {
  readonly type = LOAD_INVENTORY;

  constructor(public payload: number) { }
}

export const LOAD_INVENTORY_SUCCESS = '[Action] Load Inventory Success';

export class InventoryLoadSuccessAction implements Action {
  readonly type = LOAD_INVENTORY_SUCCESS;

  constructor(public payload: Inventory) { }
}

export const LOAD_INVENTORY_FAILURE = '[Action] Load Inventory Failure';

export class InventoryLoadFailureAction implements Action {
  readonly type = LOAD_INVENTORY_FAILURE;

  constructor(public payload: any) { }
}

export const ADD_INVENTORY = '[Inventory] Add Inventory';

export class InventoryAddAction implements Action {
  readonly type = ADD_INVENTORY;

  constructor(public payload: Inventory) { }
}

export const ADD_INVENTORY_SUCCESS = '[Inventory] Add Inventory Success';

export class InventoryAddSuccessAction implements Action {
  readonly type = ADD_INVENTORY_SUCCESS;

  constructor(public payload: Inventory) { }
}

export const ADD_INVENTORY_FAILURE = '[Inventory] Add Inventory Failure';

export class InventoryAddFailureAction implements Action {
  readonly type = ADD_INVENTORY_FAILURE;

  constructor(public payload: any) { }
}

export const DELETE_INVENTORY = '[Inventory] Delete Inventory';

export class InventoryDeleteAction implements Action {
  readonly type = DELETE_INVENTORY;

  constructor(public payload: number) { }
}

export const DELETE_INVENTORY_SUCCESS = '[Inventory] Delete Inventory Success';

export class InventoryDeleteSuccessAction implements Action {
  readonly type = DELETE_INVENTORY_SUCCESS;

  constructor(public payload: number) { }
}

export const DELETE_INVENTORY_FAILURE = '[Inventory] Delete Inventory Failure';

export class InventoryDeleteFailureAction implements Action {
  readonly type = DELETE_INVENTORY_FAILURE;

  constructor(public payload: any) { }
}

export const MODIFY_INVENTORY = '[Inventory] Modify Inventory';

export class InventoryModifyAction implements Action {
  readonly type = MODIFY_INVENTORY;

  constructor(public payload: Inventory) { }
}

export const MODIFY_INVENTORY_SUCCESS = '[Inventory] Modify Inventory Success';

export class InventoryModifySuccessAction implements Action {
  readonly type = MODIFY_INVENTORY_SUCCESS;

  constructor(public payload: Inventory) { }
}

export const MODIFY_INVENTORY_FAILURE = '[Inventory] Modify Inventory Failure';

export class InventoryModifyFailureAction implements Action {
  readonly type = MODIFY_INVENTORY_FAILURE;

  constructor(public payload: any) { }
}

export const ADD_INVENTORY_PRODUCT_TO_INVENTORY = '[Inventory] Add Inventory Product to Inventory';

export class InventoryAddInventoryProductAction implements Action {
    readonly type = ADD_INVENTORY_PRODUCT_TO_INVENTORY;

    constructor(public payload: {product: InventoryProduct, id: number}) { }
}

export const ADD_INVENTORY_PRODUCT_TO_INVENTORY_SUCCESS = '[Inventory] Add Inventory Product to Inventory Success';

export class InventoryAddInventoryProductSuccessAction implements Action {
  readonly type = ADD_INVENTORY_PRODUCT_TO_INVENTORY_SUCCESS;

  constructor(public payload: any) { }
}

export const ADD_INVENTORY_PRODUCT_TO_INVENTORY_FAILURE = '[Inventory] Add Inventory Product to Inventory Failure';

export class InventoryAddInventoryProductFailureAction implements Action {
  readonly type = ADD_INVENTORY_PRODUCT_TO_INVENTORY_FAILURE;

  constructor(public payload: any) { }
}

export const LOAD_INVENTORIES = '[Inventory] Load Inventories';

export class InventoriesLoadAction implements Action {
  readonly type = LOAD_INVENTORIES;
}

export const LOAD_INVENTORIES_SUCCESS = '[Inventory] Load Inventories Success';

export class InventoriesLoadSuccessAction implements Action {
  readonly type = LOAD_INVENTORIES_SUCCESS;

  constructor(public payload: Inventory[]) { }
}

export const LOAD_INVENTORIES_FAILURE = '[Inventory] Load Inventories Failure';

export class InventoriesLoadFailureAction implements Action {
  readonly type = LOAD_INVENTORIES_FAILURE;

  constructor(public payload: any) { }
}

export type Actions
  = InventoryLoadAction
  | InventoryLoadSuccessAction
  | InventoryLoadFailureAction
  | InventoryAddAction
  | InventoryAddSuccessAction
  | InventoryAddFailureAction
  | InventoryDeleteAction
  | InventoryDeleteSuccessAction
  | InventoryDeleteFailureAction
  | InventoryModifyAction
  | InventoryModifySuccessAction
  | InventoryModifyFailureAction
  | InventoryAddInventoryProductAction
  | InventoryAddInventoryProductSuccessAction
  | InventoryAddInventoryProductFailureAction
  | InventoriesLoadAction
  | InventoriesLoadSuccessAction
  | InventoriesLoadFailureAction;
