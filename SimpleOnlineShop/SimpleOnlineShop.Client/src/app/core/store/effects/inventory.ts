import { Injectable } from '@angular/core';
import { Actions, Effect } from '@ngrx/effects';
import { InventoryService } from '../../services/inventory.service';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/mergeMap';

import * as inventory from '../actions/inventory';
import { of } from 'rxjs/observable/of';
import { Inventory } from '../../models/inventory';
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class InventoryEffects {
  // inventories
  @Effect()
  loadInventories$: Observable<Action> = this.actions$
    .ofType(inventory.LOAD_INVENTORIES)
    .startWith(new inventory.InventoriesLoadAction())
    .switchMap(() =>
      this.service.findAll()
        .map((res: Inventory[]) => new inventory.InventoriesLoadSuccessAction(res))
        .catch(error => of(new inventory.InventoriesLoadFailureAction(error)))
    );

  @Effect()
  loadInventory$: Observable<Action> = this.actions$
    .ofType(inventory.LOAD_INVENTORY)
    .map((action: inventory.InventoryLoadAction) => action.payload)
    .switchMap(id =>
      this.service.find(id)
        .map(res => new inventory.InventoryLoadSuccessAction(res))
        .catch(error => of(new inventory.InventoryLoadFailureAction(error)))
    );

  @Effect()
  addInventory$ = this.actions$
    .ofType(inventory.ADD_INVENTORY)
    .map((action: inventory.InventoryAddAction) => action.payload)
    .mergeMap(invent =>
      this.service.create(invent)
        .map(res => new inventory.InventoryAddSuccessAction(invent))
        .catch(err => of(new inventory.InventoryAddFailureAction(err)))
    );

  @Effect()
  deleteInventory$ = this.actions$
    .ofType(inventory.DELETE_INVENTORY)
    .map((action: inventory.InventoryDeleteAction) => action.payload)
    .mergeMap(id =>
      this.service.delete_(id)
        .map(res => new inventory.InventoryDeleteSuccessAction(res.id))
        .catch(err => of(new inventory.InventoryDeleteFailureAction(err)))
    );

  @Effect()
  addProduct$ = this.actions$
    .ofType(inventory.ADD_INVENTORY_PRODUCT_TO_INVENTORY)
    .map((action: inventory.InventoryAddInventoryProductAction) => action.payload)
    .mergeMap(payload =>
      this.service.addInventoryProduct(payload.id, payload.product)
        .map(res => new inventory.InventoryAddInventoryProductSuccessAction({
          id: payload.id,
          product: payload.product
        }))
        .catch(err => of(new inventory.InventoryAddInventoryProductFailureAction(err)))
    );

  @Effect()
  deleteProduct$ = this.actions$
    .ofType(inventory.DELETE_INVENTORY_PRODUCT_TO_INVENTORY)
    .map((action: inventory.InventoryDeleteInventoryProductAction) => action.payload)
    .mergeMap(payload =>
      this.service.deleteInventoryProduct(payload.inventoryId, payload.productId)
        .map(res => new inventory.InventoryDeleteInventoryProductSuccessAction({
          inventoryId: payload.inventoryId,
          productId: payload.productId,
        }))
        .catch(err => of(new inventory.InventoryDeleteInventoryProductFailureAction(err)))
    );

  constructor(private actions$: Actions,
              private service: InventoryService) { }
}
