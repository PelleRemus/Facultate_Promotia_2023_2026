import { SkillLevels } from "./skillLevels";

export class Skill {
    skill: string;
    subSkills: string;
    skillLevel: SkillLevels;

    constructor(skill: string, subSkill: string, skillLevel: SkillLevels) {
        this.skill = skill;
        this.subSkills = subSkill;
        this.skillLevel = skillLevel;
    }
}