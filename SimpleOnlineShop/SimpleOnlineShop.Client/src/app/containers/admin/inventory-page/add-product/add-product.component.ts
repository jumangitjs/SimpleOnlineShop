import {Component, OnInit, Inject} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {InventoryService} from '../../../../core/services/inventory.service';
import {MdDialogRef, MD_DIALOG_DATA} from '@angular/material';
import {Inventory} from '../../../../core/models/inventory';
import {InventoryProduct} from '../../../../core/models/inventory-product';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  inventoryProductForm: FormGroup;

  constructor(private fb: FormBuilder,
              private service: InventoryService,
              public dialogRef: MdDialogRef<AddProductComponent>,
              @Inject(MD_DIALOG_DATA) private data: Inventory) { }

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
      this.service.addInventoryProduct(this.data.id, this.inventoryProductForm.value as InventoryProduct);
      this.dialogRef.close();
    }
  }

}
