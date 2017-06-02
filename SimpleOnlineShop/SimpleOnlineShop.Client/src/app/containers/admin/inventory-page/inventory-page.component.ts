import {Component, OnInit, Input} from '@angular/core';
import { Inventory } from '../../../core/models/inventory';
import { Observable } from 'rxjs/Observable';
import { InventoryService } from '../../../core/services/inventory.service';

import { MdDialog } from '@angular/material';
import {CreateInventoryComponent} from './create-inventory/create-inventory.component';
import {DeleteInventoryComponent} from './delete-inventory/delete-inventory.component';
import {AddProductComponent} from './add-product/add-product.component';
import {InventoryProduct} from '../../../core/models/inventory-product';

@Component({
  selector: 'app-inventory-page',
  templateUrl: './inventory-page.component.html',
  styleUrls: ['./inventory-page.component.css']
})
export class InventoryPageComponent implements OnInit {

  selectedInventory: Inventory;
  @Input() selectedProduct;
  @Input() product;
  inventories$: Observable<Inventory[]>;

  constructor(private service: InventoryService,
              private dialogCreate: MdDialog,
              private dialogDelete: MdDialog,
              private dialogAddProduct: MdDialog) { }

  ngOnInit() {
    this.inventories$ = this.service.findAll();
  }
//noinspection TsLint
  createDialog() {
    this.dialogCreate.open(CreateInventoryComponent, {
      width: '400px',
      height: '300px'
    });
  }

  deleteDialog() {
    this.dialogDelete.open(DeleteInventoryComponent, {
      width: '400px',
      height: '150px',
      data: this.selectedInventory
    });
  }

  addProductDialog() {
    this.dialogAddProduct.open(AddProductComponent, {
      width: '400px',
      height: '450px',
      data: this.selectedInventory
    });
  }

  deleteProductDialog(productId: number) {
    this.service.deleteInventoryProduct(this.selectedInventory.id, productId);
  }
}
