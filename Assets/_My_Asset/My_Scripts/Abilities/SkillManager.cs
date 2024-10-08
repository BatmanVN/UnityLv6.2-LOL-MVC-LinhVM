using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    [SerializeField] private List<BaseSkill> skills;

    public List<BaseSkill> Skills { get => skills;}


}
