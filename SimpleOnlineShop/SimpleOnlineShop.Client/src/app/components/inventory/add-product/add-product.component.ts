import {Component, OnInit, Inject} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MdDialogRef, MD_DIALOG_DATA} from '@angular/material';
import {Inventory} from '../../../core/models/inventory';
import {InventoryProduct} from '../../../core/models/inventory-product';
import {Store} from '@ngrx/store';

import * as fromRoot from '../../../core/store/reducers/index';
import * as action_ from '../../../core/store/actions/inventory';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  inventoryProductForm: FormGroup;

  constructor(private fb: FormBuilder,
              public dialogRef: MdDialogRef<AddProductComponent>,
              @Inject(MD_DIALOG_DATA) private data: Inventory,
              public store: Store<fromRoot.State>) { }

  ngOnInit() {
    this.inventoryProductForm = this.fb.group({
      uniqueId: ['', Validators.compose([Validators.required, Validators.maxLength(25)])],
      name: ['', Validators.compose([Validators.required, Validators.minLength(3)])],
      brand: ['', Validators.required],
      description: ['', Validators.compose([Validators.required, Validators.maxLength(140)])],
      price: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.inventoryProductForm.valid) {
      this.store.dispatch(new action_
        .InventoryAddInventoryProductAction({
          id: this.data.id,
          product: this.inventoryProductForm.value as InventoryProduct}
          ));
      this.dialogRef.close();
    } else {
      Object.keys(this.inventoryProductForm.controls).map((controlName) => {
        this.inventoryProductForm.get(controlName).markAsTouched({onlySelf: true});
      });
    }
  }
}
