import { Injectable } from '@angular/core';
import { PersonalDetails } from '../models/personal-details';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonalDetailsService {
  #personalDetails: PersonalDetails = new PersonalDetails(
    "John Doe",
    "Software Developer",
    "john.doe@gmail.com",
    "",
    "Oradea, Romania",
    "data:image/jpeg;base64,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"
  )

  constructor() { }

  getPersonalDetails(): Observable<PersonalDetails> {
    return of(this.#personalDetails);
  }
}