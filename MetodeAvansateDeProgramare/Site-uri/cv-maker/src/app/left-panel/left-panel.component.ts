import { Component } from '@angular/core';
import { PersonalDetailsComponent } from '../personal-details/personal-details.component';
import { ProfileComponent } from '../profile/profile.component'

@Component({
  selector: 'app-left-panel',
  standalone: true,
  imports: [
    PersonalDetailsComponent,
    ProfileComponent,
  ],
  templateUrl: './left-panel.component.html',
  styleUrl: './left-panel.component.scss'
})
export class LeftPanelComponent {

}
