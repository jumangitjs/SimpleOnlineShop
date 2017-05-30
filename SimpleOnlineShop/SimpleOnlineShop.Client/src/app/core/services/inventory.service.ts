import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Store } from '@ngrx/store';

import { environment } from '../../../environments/environment';
import { Inventory } from '../models/inventory';
import { Observable } from 'rxjs/Observable';

//noinspection TsLint
@Injectable()
export class InventoryService {

  //add access token for authentication use later on......

  constructor(private http: Http) { }

  findAll(): Observable<Inventory[]> {
    return this.http.get(environment.resourceServer + 'inventory').map(r => r.json());
  }

  find(id: number): Observable<Inventory> {
    return this.http.get(environment.resourceServer + 'inventory/' + id).map(r => r.json());
  }

  create(inventory: Inventory) {
    this.http.post(environment.resourceServer + 'inventory', {inventory});
  }

  delete(id: number) {
    this.http.delete(environment.resourceServer + 'inventory/' + id);
  }
}
