using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : BaseSkill
{
    private void Start()
    {
        Skill.enabled = false;
        skillCone.enabled = false;
    }
    public override void CastSkill()
    {
        if(!IsSkillCD)
            IsSkillCD = true;
    }
    public override void DeCastSkill()
    {
        Skill.enabled = false;
        skillCone.enabled = false;
    }
    public override void RotateIndicator()
    {

    }

    public override void SkillInput()
    {

    }
}