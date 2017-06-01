import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {InventoryService} from '../../../../core/services/inventory.service';
import {Inventory} from '../../../../core/models/inventory';
import {MdDialogRef} from '@angular/material';

@Component({
  selector: 'app-create-inventory',
  templateUrl: './create-inventory.component.html',
  styleUrls: ['./create-inventory.component.css']
})

export class CreateInventoryComponent implements OnInit {

  inventoryCreateForm: FormGroup;

  constructor(private fb: FormBuilder,
              private service: InventoryService,
              public dialogRef: MdDialogRef<CreateInventoryComponent>) { }

  ngOnInit() {
    this.inventoryCreateForm = this.fb.group({
      name: ['', Validators.compose([Validators.required, Validators.minLength(3)])],
      description: ['', Validators.compose([Validators.required, Validators.maxLength(140)])]
    });
  }

  onSubmit() {
    if (this.inventoryCreateForm.valid) {
      this.service.create(this.inventoryCreateForm.value as Inventory);
      this.dialogRef.close();
    }
  }
}
