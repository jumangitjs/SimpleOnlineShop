import { Component, OnInit, Inject } from '@angular/core';
import { Inventory } from '../../../core/models/inventory';
import { MdDialogRef, MD_DIALOG_DATA } from '@angular/material';
import { Store } from '@ngrx/store';

import * as fromRoot from '../../../core/store/reducers/index';
import * as action_ from '../../../core/store/actions/inventory';

@Component({
  selector: 'app-delete-inventory',
  templateUrl: './delete-inventory.component.html',
  styleUrls: ['./delete-inventory.component.css']
})
export class DeleteInventoryComponent implements OnInit {

  constructor(private dialogRef: MdDialogRef<DeleteInventoryComponent>,
              @Inject(MD_DIALOG_DATA) private data: Inventory,
              private store: Store<fromRoot.State>) { }

  ngOnInit() {
  }

  onSubmit() {
    this.store.dispatch(new action_.InventoryDeleteAction(this.data.id));
    this.dialogRef.close();
  }
}
