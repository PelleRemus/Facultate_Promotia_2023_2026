import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Skill } from '../models/skill';

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [ CommonModule ],
  templateUrl: './skills.component.html',
  styleUrl: './skills.component.scss'
})
export class SkillsComponent {
  skills: Skill[] = [
    new Skill("Backend", ".NET", "Proficient"),
    new Skill("Frontend", "Angular", "Competent"),
    new Skill("Tools", "Visual Studio Code", "Competent"),
  ];
}
