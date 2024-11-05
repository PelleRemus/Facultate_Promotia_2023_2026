import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Skill } from '../models/skill';
import { SkillLevels } from '../models/skillLevels';

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [ CommonModule, FormsModule ],
  templateUrl: './skills.component.html',
  styleUrl: './skills.component.scss'
})
export class SkillsComponent {
  skills: Skill[] = [
    new Skill("Backend", ".NET", SkillLevels.Proficient),
    new Skill("Frontend", "Angular", SkillLevels.Competent),
    new Skill("Tools", "Visual Studio Code", SkillLevels.Competent),
  ];
  skillLevels: string[] = []
  currentSkill: Skill = {} as Skill;
  isCreate = false;

  constructor() {
    Object.keys(SkillLevels).forEach(key => {
      if(!+key && +key !== 0) {
        this.skillLevels.push(key);
      }
    });
  }

  toggleCreate() {
    this.isCreate = !this.isCreate;
    this.currentSkill = {} as Skill;
  }

  onSubmit(form: any) {
    if (form.valid) {
      this.skills.push(this.currentSkill);
      this.toggleCreate();
    }
  }
}
