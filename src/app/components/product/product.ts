import { Component } from '@angular/core';
import { IProduct } from '../../models/iproduct';
import { ICategory } from '../../models/icategory';
import { CommonModule } from '@angular/common';
import {FormsModule} from '@angular/forms';
@Component({
  selector: 'app-product',
  imports: [CommonModule, FormsModule],
  templateUrl: './product.html',
  styleUrl: './product.css'
})
export class Product {
  products: IProduct[];
  categories: ICategory[];
  selectedCatId: number = 0;
  totalProducts: number = 0;
  isSpecial: boolean = true;
  currentStyles: Record<string, string> = {};
  setCurrentStyles() {
    // CSS styles: set per current state of component properties
    this.currentStyles = {
      'font-style': this.isSpecial ? 'italic' : 'normal',
      'font-weight': this.isSpecial ? 'bold' : 'normal',
    };
  }
  constructor() {
    this.products = [
      {id:100, name:"Mobile", price:1000, imageUrl:"img.jpg", quantity:4, isSpecial: true, catId: 1},
      {id:100, name:"Tablet", price:2000, imageUrl:"img.jpg", quantity:6, isSpecial: false, catId: 2},
      {id:100, name:"Laptop", price:3000, imageUrl:"img.jpg", quantity:8, isSpecial: true, catId: 3},
      {id:100, name:"Mobile", price:1000, imageUrl:"img.jpg", quantity:4, isSpecial: false, catId: 1},
      {id:100, name:"Tablet", price:2000, imageUrl:"img.jpg", quantity:0, isSpecial: true, catId: 2},
      {id:100, name:"Laptop", price:3000, imageUrl:"img.jpg", quantity:8, isSpecial: false, catId: 3}
    ],
    this.categories = [
      {id:1, name:"Mobile"},
      {id:2, name:"Tablet"},
      {id:3, name:"Laptop"}
    ]
  }

  ngOnInit(): void {
    this.setCurrentStyles();
  }
  Buy(input:string, product:IProduct):void {
    this.totalProducts += +input * product.price;
    product.quantity -= +input;
  }
}
