import {InventoryProduct} from './inventory-product';

export interface Inventory {
  id: number;
  name: string;
  description: string;
  inventoryProducts: InventoryProduct[];
}
