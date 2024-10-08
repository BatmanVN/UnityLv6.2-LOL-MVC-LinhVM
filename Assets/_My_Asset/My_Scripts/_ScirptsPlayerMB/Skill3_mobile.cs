using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3_mobile : BaseSkill
{

    public bool isSkill3;
    private void Start()
    {
        Skill.enabled = false;
        skillCone.enabled = false;
    }
    private void Update()
    {

    }
    public override void CastSkill()
    {
        if (!IsSkillCD)
        {
            isSkill3 = true;
        }
    }

    public override void DeCastSkill()
    {

    }

    public override void RotateIndicator()
    {

    }

    public override void SkillInput()
    {

    }
}
