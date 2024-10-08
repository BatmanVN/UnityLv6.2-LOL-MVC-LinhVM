using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : BaseSkill
{
    public override void CastSkill()
    {
        Skill.enabled = true;
        skillCone.enabled = true;
    }
    public override void DeCastSkill()
    {
        Skill.enabled = false;
        skillCone.enabled = false;
    }
    public override void RotateIndicator()
    {
        if (Skill.enabled)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
            Quaternion kickSkill = Quaternion.LookRotation(position - player.position);
            kickSkill.eulerAngles = new Vector3(0, kickSkill.eulerAngles.y, kickSkill.eulerAngles.z);
            Skill.transform.rotation = Quaternion.Slerp(kickSkill, Skill.transform.rotation, 0);
        }
    }
    public override void SkillInput()
    {
        if (!IsSkillCD)
        {
            IsSkillCD = true;
        }
        Skill.enabled = false;
        skillCone.enabled = false;
    }
    private void Start()
    {
        Skill.enabled = false;
        skillCone.enabled = false;
    }
    private void Update()
    {
        RotateIndicator();
    }
}