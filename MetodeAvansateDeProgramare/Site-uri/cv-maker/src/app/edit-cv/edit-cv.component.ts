import { Component } from '@angular/core';
import { LeftPanelComponent } from '../left-panel/left-panel.component';

@Component({
  selector: 'app-edit-cv',
  standalone: true,
  imports: [LeftPanelComponent],
  templateUrl: './edit-cv.component.html',
  styleUrl: './edit-cv.component.scss'
})
export class EditCvComponent {

}
