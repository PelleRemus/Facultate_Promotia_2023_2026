import { Injectable } from '@angular/core';
import { Skill } from '../models/skill';
import { SkillLevels } from '../models/skillLevels';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SkillsService {
  #skills: Skill[] = [
    new Skill(1, "Backend", ".NET", SkillLevels.Proficient),
    new Skill(2, "Frontend", "Angular", SkillLevels.Competent),
    new Skill(3, "Tools", "Visual Studio Code", SkillLevels.Competent),
  ];

  constructor() { }

  getSkillList(): Observable<Skill[]> {
    return of(this.#skills);
  }
}
