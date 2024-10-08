using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1_mobile : BaseSkill
{
    [SerializeField] private VariableJoystick skillJoy;
    public bool isClick;
    public bool castSkill;
    private void Start()
    {
        Skill.enabled = false;
        skillCone.enabled = false;
    }
    private void Update()
    {
        if (isClick)
            RotateIndicator();
    }
    public void ClickSkill()
    {
        if (!IsSkillCD)
        {
            isClick = true;
            CastSkill();
        }
    }
    public void DeClick()
    {
        isClick = false;
        castSkill = true;
        DeCastSkill();
    }
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
        float hInput = skillJoy.Horizontal;
        float vInput = skillJoy.Vertical;
        Vector3 direction = new Vector3(hInput, 0f, vInput);
        direction = Camera.main.transform.TransformDirection(direction);
        direction.y = 0f;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotate = Quaternion.LookRotation(direction);
            targetRotate.eulerAngles = new Vector3(0f, targetRotate.eulerAngles.y, 0f);
            Skill.transform.rotation = Quaternion.Slerp(Skill.transform.rotation, targetRotate, 5 * Time.deltaTime);
        }
    }
    public override void SkillInput()
    {

    }
}
