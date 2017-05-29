import {Order} from './order';

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  address: string;
  email: string;
  contactNo: string;
  orders: Order[];
  grandTotal: number;
}
