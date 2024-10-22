import { Component } from '@angular/core';
import { PersonalDetails } from '../models/personal-details'

@Component({
  selector: 'app-personal-details',
  standalone: true,
  imports: [],
  templateUrl: './personal-details.component.html',
  styleUrl: './personal-details.component.scss'
})
export class PersonalDetailsComponent {
  personalDetails: PersonalDetails = new PersonalDetails(
    "John Doe",
    "Software Developer",
    "john.doe@gmail.com",
    "",
    "Oradea, Romania",
  )
}
