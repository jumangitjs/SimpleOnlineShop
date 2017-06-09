import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import { environment } from '../../../environments/environment';
import { User } from '../models/user';
import { InventoryProduct } from '../models/inventory-product';
import { OrderForm } from 'app/core/models/order-form';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class UserService {

  headers = new Headers({ 'Content-Type': 'application/json' });
  options = new RequestOptions({ headers: this.headers });

  constructor(private http: Http) { }

  findAll(): Observable<User[]> {
    return this.http.get(environment.resourceServer + 'customer', this.options)
      .map(res => res.json());
  }

  find(id: number): Observable<User> {
    return this.http.get(environment.resourceServer + `customer/${id}`, this.options)
      .map(res => res.json());
  }

  create(user: User): Observable<User> {
    return this.http.post(environment.resourceServer + 'customer', user, this.options)
      .map(res => res.text() ? res.json() : {});
  }

  delete(id: number): Observable<User> {
    return this.http.delete(environment.resourceServer + `customer/${id}`, this.options)
      .map(res => res.text() ? res.json() : {});
  }

  changeEmail(id: number, email: string): Observable<User> {
    return this.http.put(environment.resourceServer + `customer/${id}/email`, {email: email}, this.options)
      .map(res => res.text() ? res.json() : {});
  }

  changeContactNo(id: number, contactNo: string): Observable<User> {
    return this.http.put(environment.resourceServer + `customer/${id}/contactNo`, {contactNo: contactNo}, this.options)
      .map(res => res.text() ? res.json() : {});
  }

  addOrder(orderForm: OrderForm): Observable<User> {
    return this.http.put(environment.resourceServer + `customer/${orderForm.userId}/order`, orderForm, this.options)
      .map(res => res.text() ? res.json() : {});
  }

  deleteOrder(id: number, orderId: number): Observable<User> {
    return this.http.delete(environment.resourceServer + `customer/${id}/order/${orderId}`, this.options)
      .map(res => res.text() ? res.json() : {});
  }

  checkout(id: number): Observable<User> {
    return this.http.put(environment.resourceServer + `customer/${id}/checkout`, this.options)
      .map(res => res.text() ? res.json() : {});
  }
}
