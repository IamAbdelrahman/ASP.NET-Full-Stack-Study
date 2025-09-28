import { Component } from '@angular/core';
import { Footer } from './components/footer/footer';
import { Product } from "./components/product/product";
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from "./components/navbar/navbar.component";
// import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [Footer, FormsModule, NavbarComponent, Product],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
// This App class acts as the root component of the Angular application.
// It is decorated with @Component to define its metadata, including the selector
export class App {
  protected title = 'Demo';
}
