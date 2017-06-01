import {Component, OnInit, Inject} from '@angular/core';
import {InventoryService} from '../../../../core/services/inventory.service';
import {Inventory} from '../../../../core/models/inventory';
import {MdDialogRef, MD_DIALOG_DATA} from '@angular/material';

@Component({
  selector: 'app-delete-inventory',
  templateUrl: './delete-inventory.component.html',
  styleUrls: ['./delete-inventory.component.css']
})
export class DeleteInventoryComponent implements OnInit {

  constructor(private service: InventoryService,
              private dialogRef: MdDialogRef<DeleteInventoryComponent>,
              @Inject(MD_DIALOG_DATA) private data: Inventory) { }

  ngOnInit() {
  }

  onSubmit() {
    this.service.delete(this.data.id);
    this.dialogRef.close();
  }
}
