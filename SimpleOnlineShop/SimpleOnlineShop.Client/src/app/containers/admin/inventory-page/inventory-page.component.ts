import { Component, OnInit } from '@angular/core';
import { Inventory } from '../../../core/models/inventory';
import { Observable } from 'rxjs/Observable';
import { InventoryService } from '../../../core/services/inventory.service';

import { MdDialog } from '@angular/material';
import {CreateInventoryComponent} from './create-inventory/create-inventory.component';
import {DeleteInventoryComponent} from './delete-inventory/delete-inventory.component';

@Component({
  selector: 'app-inventory-page',
  templateUrl: './inventory-page.component.html',
  styleUrls: ['./inventory-page.component.css']
})
export class InventoryPageComponent implements OnInit {

  selectedInventory: Inventory;
  inventories$: Observable<Inventory[]>;

  constructor(private service: InventoryService,
              private dialogCreate: MdDialog,
              private dialogDelete: MdDialog) { }

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
    if (this.selectedInventory){
      this.dialogDelete.open(DeleteInventoryComponent, {
        width: '400px',
        height: '150px',
        data: this.selectedInventory
      });
    }
  }
}
