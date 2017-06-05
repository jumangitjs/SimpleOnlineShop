import { NgModule, Provider } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { RouterStoreModule } from '@ngrx/router-store';
import { InventoryService } from './services/inventory.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    InventoryService
  ],
  declarations: []
})

export class CoreModule { }
