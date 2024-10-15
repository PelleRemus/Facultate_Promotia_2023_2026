import { Component } from '@angular/core';

@Component({
  selector: 'app-personal-details',
  standalone: true,
  imports: [],
  templateUrl: './personal-details.component.html',
  styleUrl: './personal-details.component.scss'
})
export class PersonalDetailsComponent {
  email: string = "john.doe@gmail.com";
}
