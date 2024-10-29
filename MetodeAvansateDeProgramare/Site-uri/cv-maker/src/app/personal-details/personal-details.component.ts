import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PersonalDetails } from '../models/personal-details';

@Component({
  selector: 'app-personal-details',
  standalone: true,
  imports: [CommonModule, FormsModule],
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
  isEdit: boolean = false;

  toggleEdit(): void {
    this.isEdit = !this.isEdit;
  }

  onSubmit(form: any): void {
    if(form.valid){
      this.toggleEdit();
    }
  }
}
