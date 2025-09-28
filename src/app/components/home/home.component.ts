import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IStore } from '../../models/istore';
@Component({
  selector: 'app-home',
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  myStore:IStore;
  constructor()
  {
    this.myStore = 
    {
      name:"AK", 
      imageUrl:"https://images.pexels.com/photos/64613/pexels-photo-64613.jpeg?_gl=1*qrvgih*_ga*NzY4NDU3MjgyLjE3NTE3MjA2NjE.*_ga_8JE65Q40S6*czE3NTU1NTc5MzEkbzQkZzEkdDE3NTU1NTc5NDQkajQ3JGwwJGgw",
      branches:["Tanta", "Cairo", "Alex"]
    }
  }

}
