import { Component, OnInit } from '@angular/core';
import { Inventory } from '../../../core/models/inventory';
import { Observable } from 'rxjs/Observable';
import { InventoryService } from '../../../core/services/inventory.service';

@Component({
  selector: 'app-inventory-page',
  templateUrl: './inventory-page.component.html',
  styleUrls: ['./inventory-page.component.css']
})
export class InventoryPageComponent implements OnInit {

  selectedInventory: Inventory;
  inventories$: Observable<Inventory[]>;

  constructor(private service: InventoryService) { }

  ngOnInit() {
    this.inventories$ = this.service.findAll();
  }
}

