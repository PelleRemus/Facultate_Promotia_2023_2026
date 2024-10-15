import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LeftPanelComponent } from './left-panel/left-panel.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, LeftPanelComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'cv-maker';
}
