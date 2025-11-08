import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Birthday } from './components/birthday/birthday';
// import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [FormsModule, Birthday, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
// This App class acts as the root component of the Angular application.
// It is decorated with @Component to define its metadata, including the selector
export class App {
  protected title = 'Demo';
}
