export class Skill {
    skill: string;
    subSkills: string;
    skillLevel: "Beginner" | "Amateur" | "Competent" | "Proficient" | "Expert";

    constructor(skill: string, subSkill: string,
        skillLevel: "Beginner" | "Amateur" | "Competent" | "Proficient" | "Expert"
    ) {
        this.skill = skill;
        this.subSkills = subSkill;
        this.skillLevel = skillLevel;
    }
}