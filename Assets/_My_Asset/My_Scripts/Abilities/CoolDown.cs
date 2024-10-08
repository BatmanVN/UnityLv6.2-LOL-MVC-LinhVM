using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoolDown : MonoBehaviour
{
    [SerializeField] private BaseSkill skill;
    [SerializeField] private float skillCooldown;
    [SerializeField] private float _currentSkillCD;
    public UnityEvent onCoolDown;
    public UnityEvent onDeCoolDown;
    public float SkillCooldown { get => skillCooldown; }
    public float CurrentSkillCooldown
    {
        get => _currentSkillCD;
        set
        {
            _currentSkillCD = value;
            if (skill.IsSkillCD && CurrentSkillCooldown > 0)
            {
                onCoolDown?.Invoke();
            }
            if (CurrentSkillCooldown <= 0)
            {
                onDeCoolDown?.Invoke();
                skill.IsSkillCD = false;
            }
        }
    }
    public void UseSkill() => CurrentSkillCooldown -= Time.deltaTime;
    public void ResetCoolDown() => CurrentSkillCooldown = skillCooldown;
    private void Start()
    {
        ResetCoolDown();
    }
    private void Update()
    {
        if (skill.IsSkillCD)
            UseSkill();
    }
}
