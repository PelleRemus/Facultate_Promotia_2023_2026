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
  )

  constructor() { }

  getPersonalDetails(): Observable<PersonalDetails> {
    return of(this.#personalDetails);
  }
}
