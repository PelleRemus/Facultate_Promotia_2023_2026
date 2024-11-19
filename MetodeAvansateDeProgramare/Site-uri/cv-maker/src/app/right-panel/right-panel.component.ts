import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonalDetails } from '../models/personal-details';
import { Skill } from '../models/skill';
import { PersonalDetailsService } from '../services/personal-details.service';
import { SkillsService } from '../services/skills.service';

@Component({
  selector: 'app-right-panel',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './right-panel.component.html',
  styleUrl: './right-panel.component.scss'
})
export class RightPanelComponent {
  personalDetails: PersonalDetails = {} as PersonalDetails;
  skills: Skill[] = [];

  constructor(
    personalDetailsService: PersonalDetailsService,
    skillsService: SkillsService
  ) {
    personalDetailsService.getPersonalDetails().subscribe(result => {
      this.personalDetails = result;
    });
    skillsService.getSkillList().subscribe(result => {
      this.skills = result;
    })
    console.log(this.personalDetails);
  }
}
