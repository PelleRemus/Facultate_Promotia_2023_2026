import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PersonalDetails } from '../models/personal-details';
import { PersonalDetailsService } from '../services/personal-details.service';

@Component({
  selector: 'app-personal-details',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './personal-details.component.html',
  styleUrl: './personal-details.component.scss'
})
export class PersonalDetailsComponent {
  @ViewChild("newImage") newImage: any; 
  file: File = {} as File;
  personalDetails: PersonalDetails = {} as PersonalDetails;
  formDetails: PersonalDetails = {} as PersonalDetails;
  isEdit: boolean = false;

  constructor(personalDetailsService: PersonalDetailsService) {
    personalDetailsService.getPersonalDetails().subscribe(result => {
      this.personalDetails = result;
    })
  }

  imageChanged($event: any) {
    this.file = $event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(this.file);
    reader.onload = () => {
      this.formDetails.imageUrl = reader.result?.toString() ?? "";
    };
  }

  toggleEdit(): void {
    this.isEdit = !this.isEdit;
    this.formDetails = { ...this.personalDetails };
  }

  onSubmit(form: any): void {
    if (form.valid) {
      this.personalDetails = { ...this.formDetails };
      this.toggleEdit();
    }
  }
}
