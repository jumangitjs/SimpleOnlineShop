import {Component, OnInit, Inject} from '@angular/core';

import * as fromRoot from '../../../core/store/reducers/index';
import * as actionInventory from '../../../core/store/actions/inventory';
import {Store} from '@ngrx/store';
import {User} from '../../../core/models/user';
import {Observable} from 'rxjs/Observable';
import {Inventory} from '../../../core/models/inventory';

@Component({
  selector: 'app-add-order',
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css']
})
export class AddOrderComponent implements OnInit {

  user$: Observable<User>;
  inventories$: Observable<Inventory[]>;

  constructor(private store: Store<fromRoot.State>) { }

  ngOnInit() {
    this.store.dispatch(new actionInventory.InventoriesLoadAction());
    this.user$ = this.store.select(fromRoot.user);
    this.inventories$ = this.store.select(fromRoot.inventories);
  }

  add() {
    alert('arf');
  }

}
