import { SkillLevels } from "./skillLevels";

export class Skill {
    id: number
    skill: string;
    subSkills: string;
    skillLevel: SkillLevels;

    constructor(id: number, skill: string, subSkill: string, skillLevel: SkillLevels) {
        this.id = id;
        this.skill = skill;
        this.subSkills = subSkill;
        this.skillLevel = skillLevel;
    }
}