using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSkill : MonoBehaviour
{
    [SerializeField] protected CoolDown coolDown;
    [SerializeField] protected Image skillImage;
    [SerializeField] protected Text skillText;
    [SerializeField] private bool isSkillCD;
    [SerializeField] private Canvas skill;
    [SerializeField] protected Image skillCone;
    [SerializeField] protected float maxSkillDistance;
    protected Vector3 position;
    [SerializeField] protected Transform player;
    public bool IsSkillCD 
    {
        get => isSkillCD;
        set
        {
            isSkillCD = value;
            enabled = !isSkillCD;
            coolDown.ResetCoolDown();
        }
    }

    public Canvas Skill { get => skill; set => skill = value; }

    public abstract void CastSkill();
    public abstract void SkillInput();
    public abstract void RotateIndicator();
    public abstract void DeCastSkill();
    private void Start()
    {

    }
}
