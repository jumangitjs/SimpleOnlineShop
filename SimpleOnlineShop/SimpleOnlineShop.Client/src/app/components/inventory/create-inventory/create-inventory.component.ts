import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Inventory} from '../../../core/models/inventory';
import {MdDialogRef} from '@angular/material';

import { Store } from '@ngrx/store';

import * as fromRoot from '../../../core/store/reducers/index';
import * as action_ from '../../../core/store/actions/inventory';

@Component({
  selector: 'app-create-inventory',
  templateUrl: './create-inventory.component.html',
  styleUrls: ['./create-inventory.component.css']
})

export class CreateInventoryComponent implements OnInit {

  inventoryCreateForm: FormGroup;

  constructor(private fb: FormBuilder,
              private dialogRef: MdDialogRef<CreateInventoryComponent>,
              private store: Store<fromRoot.State>) { }

  ngOnInit() {
    this.inventoryCreateForm = this.fb.group({
      name: ['', Validators.compose([Validators.required, Validators.minLength(3)])],
      description: ['', Validators.compose([Validators.required, Validators.maxLength(140)])]
    });
  }

  onSubmit() {
    if (this.inventoryCreateForm.valid) {
      this.store.dispatch(new action_.InventoryAddAction(this.inventoryCreateForm.value as Inventory));
      this.dialogRef.close();
    } else {
      Object.keys(this.inventoryCreateForm.controls).map((controlName) => {
        this.inventoryCreateForm.get(controlName).markAsTouched({onlySelf: true});
      });
    }
  }
}
