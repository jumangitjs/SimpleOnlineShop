import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { Store } from '@ngrx/store';

import { environment } from '../../../environments/environment';
import { Inventory } from '../models/inventory';
import { Observable } from 'rxjs/Observable';
import { InventoryProduct } from '../models/inventory-product';

//noinspection TsLint
@Injectable()
export class InventoryService {

  headers = new Headers({ 'Content-Type': 'application/json' });
  options = new RequestOptions({ headers: this.headers });

  //add access token for authentication use later on......

  constructor(private http: Http) { }

  findAll(): Observable<Inventory[]> {
    return this.http.get(environment.resourceServer + 'inventory', this.options)
      .map(r => r.json());
  }

  find(id: number): Observable<Inventory> {
    return this.http.get(environment.resourceServer + `inventory/${id}`, this.options)
      .map(r => r.json());
  }

  create(inventory: Inventory): Observable<Inventory> {
    return this.http.post(environment.resourceServer + 'inventory/', inventory, this.options)
      .map(res => res.text() ? res.json() : {});
      // .subscribe(res => console.log(res));
  }

  delete_(id: number): Observable<Inventory> {
    return this.http.delete(environment.resourceServer + `inventory/${id}`, this.options)
      .map(res => res.text() ? res.json() : {});
  }

  addInventoryProduct(id: number, inventoryProduct: InventoryProduct): Observable<Inventory> {
    return this.http.put(environment.resourceServer + `inventory/${id}/product`, inventoryProduct, this.options)
      .map(res => res.text() ? res.json() : {});
      // .subscribe(res => console.log(res));
  }

  deleteInventoryProduct(id: number, productId: number): Observable<Inventory> {
    return this.http.delete(environment.resourceServer + `inventory/${id}/product/${productId}`, this.options)
      .map(res => res.text() ? res.json() : {});
  }
}
