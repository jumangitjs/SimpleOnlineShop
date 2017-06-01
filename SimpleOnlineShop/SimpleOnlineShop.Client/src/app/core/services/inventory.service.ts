import { Injectable } from '@angular/core';
import {Http, RequestOptions, Headers} from '@angular/http';
import { Store } from '@ngrx/store';

import { environment } from '../../../environments/environment';
import { Inventory } from '../models/inventory';
import { Observable } from 'rxjs/Observable';

//noinspection TsLint
@Injectable()
export class InventoryService {

  headers = new Headers({ 'Content-Type': 'application/json' });
  options = new RequestOptions({ headers: this.headers });

  //add access token for authentication use later on......

  constructor(private http: Http) { }

  findAll(): Observable<Inventory[]> {
    return this.http.get(environment.resourceServer + 'inventory').map(r => r.json());
  }

  find(id: number): Observable<Inventory> {
    return this.http.get(environment.resourceServer + 'inventory/' + id).map(r => r.json());
  }

  create(inventory: Inventory) {
    this.http.post(environment.resourceServer + 'inventory/', inventory, this.options).subscribe(res => console.log(res));
  }

  delete(id: number) {
    this.http.delete(environment.resourceServer + 'inventory/' + id).subscribe(res => console.log(res));
  }
}
