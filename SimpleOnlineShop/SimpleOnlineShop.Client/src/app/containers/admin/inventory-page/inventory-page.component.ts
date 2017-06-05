import {Component, OnInit, Input, ChangeDetectionStrategy} from '@angular/core';
import { Inventory } from '../../../core/models/inventory';
import { Observable } from 'rxjs/Observable';
import { InventoryService } from '../../../core/services/inventory.service';

import { MdDialog } from '@angular/material';
import {CreateInventoryComponent} from './create-inventory/create-inventory.component';
import {DeleteInventoryComponent} from './delete-inventory/delete-inventory.component';
import {AddProductComponent} from './add-product/add-product.component';
import {Store} from '@ngrx/store';

import * as fromRoot from '../../../core/store/reducers/index';
import * as action_ from '../../../core/store/actions/inventory';
import delay from 'delay';

@Component({
  selector: 'app-inventory-page',
  templateUrl: './inventory-page.component.html',
  styleUrls: ['./inventory-page.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class InventoryPageComponent implements OnInit {

  selectedInventory: Inventory;
  inventories$: Observable<Inventory[]>;

  constructor(private service: InventoryService,
              private dialogCreate: MdDialog,
              private dialogDelete: MdDialog,
              private dialogAddProduct: MdDialog,
              private store: Store<fromRoot.State>) {
  }

  ngOnInit() {
    this.store.dispatch(new action_.InventoriesLoadAction());
    this.inventories$ = this.store.select(fromRoot.inventories);
  }
//noinspection TsLint
  createDialog() {
    this.dialogCreate.open(CreateInventoryComponent, {
      width: '400px',
      height: '300px'
    });
    this.dialogCreate.afterAllClosed
      .debounceTime(200)
      .subscribe(result =>
        this.store.dispatch(new action_.InventoriesLoadAction())
    );
  }

  deleteDialog() {
    this.dialogDelete.open(DeleteInventoryComponent, {
      width: '400px',
      height: '150px',
      data: this.selectedInventory
    });
    this.dialogDelete.afterAllClosed
      .debounceTime(200)
      .subscribe(result =>
        this.store.dispatch(new action_.InventoriesLoadAction())
    );
  }

  addProductDialog() {
    this.dialogAddProduct.open(AddProductComponent, {
      width: '400px',
      height: '455px',
      data: this.selectedInventory
    });
  }

  deleteProductDialog(productId: number) {
    this.service.deleteInventoryProduct(this.selectedInventory.id, productId);
    delay(200, {}).then(
      this.store.dispatch(new action_.InventoriesLoadAction())
    );
  }
}
