import {Order} from './order';

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  name: string;
  address: string;
  email: string;
  contactNo: string;
  orders: Order[];
  grandTotal: number;
}
