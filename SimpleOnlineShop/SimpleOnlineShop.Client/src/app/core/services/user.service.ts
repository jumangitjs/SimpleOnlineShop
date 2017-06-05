import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import { environment } from '../../../environments/environment';
import { User } from '../models/user';
import { InventoryProduct } from '../models/inventory-product';
import { OrderForm } from 'app/core/models/order-form';

@Injectable()
export class UserService {

  headers = new Headers({ 'Content-Type': 'application/json' });
  options = new RequestOptions({ headers: this.headers });

  constructor(private http: Http) { }

  findAll() {
    this.http.get(environment.resourceServer + 'customer', this.options)
      .map(res => res.json());
  }

  find(id: number) {
    this.http.get(environment.resourceServer + `customer/${id}`, this.options)
      .map(res => res.json());
  }

  create(user: User) {
    this.http.post(environment.resourceServer + 'customer', user, this.options)
      .map(res => res.json());
  }

  delete(id: number) {
    this.http.delete(environment.resourceServer + `customer/${id}`, this.options)
      .map(res => res.json());
  }

  changeEmail(id: number, email: string) {
    this.http.put(environment.resourceServer + `customer/${id}/email`, email, this.options)
      .map(res => res.json());
  }

  changeContactNo(id: number, contactNo: string) {
    this.http.put(environment.resourceServer + `customer/${id}/contactNo`, contactNo, this.options)
      .map(res => res.json());
  }

  addOrder(id: number, orderForm: OrderForm) {
    this.http.put(environment.resourceServer + `customer/${id}/order`, orderForm, this.options)
      .map(res => res.json());
  }

  deleteOrder(id: number, orderId: number) {
    this.http.delete(environment.resourceServer + `customer/${id}/order/${orderId}`, this.options)
      .map(res => res.json());
  }

  checkout(id: number) {
    this.http.put(environment.resourceServer + `customer/${id}/checkout`, null, this.options)
      .map(res => res.json());
  }
}
