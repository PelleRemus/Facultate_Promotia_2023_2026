import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Skill } from '../models/skill';
import { SkillLevels } from '../models/skillLevels';
import { SkillsService } from '../services/skills.service';

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [ CommonModule, FormsModule ],
  templateUrl: './skills.component.html',
  styleUrl: './skills.component.scss'
})
export class SkillsComponent {
  skills: Skill[] = [];
  skillLevels: string[] = [];
  currentSkill: Skill = {} as Skill;
  isCreate = false;
  isEdit = false;

  get CurrentSkillLevel() {
    return SkillLevels[this.currentSkill.skillLevel];
  }

  constructor(skillsService: SkillsService) {
    skillsService.getSkillList().subscribe(result => {
      this.skills = result;
    })

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

  toggleEdit(skill: Skill) {
    this.isEdit = !this.isEdit;
    this.currentSkill = { ...skill };
  }

  closeForm() {
    this.isCreate = false;
    this.isEdit = false;
  }

  onSubmit(form: any) {
    if (form.valid) {
      if (this.isCreate) {
        this.skills.push(this.currentSkill);
        this.toggleCreate();
      } else {
        let skill = this.skills.filter(s => s.id == this.currentSkill.id)[0];
        let index = this.skills.indexOf(skill);
        this.skills[index] = this.currentSkill;
        this.toggleEdit(this.currentSkill);
      }
    }
  }
}
