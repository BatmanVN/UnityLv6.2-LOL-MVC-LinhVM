using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : MonoBehaviour, Istate<PlayerController>
{
    public void OnEnter(PlayerController player)
    {

    }

    public void OnExercute(PlayerController player)
    {
        if (player.CurrentSkill == 1 && player.isSkill)
        {
            player.CurrentSkill = 0;
            player.ChangeAnim(ConstString.kickParaname);
            player.CharacterHealth.beAttack = false;
            player.isAttack = false;
            player.isSkill = false;
        }
        if (player.CurrentSkill == 2 && player.isSkill)
        {
            player.CurrentSkill = 0;
            player.ChangeAnim(ConstString.swordParaname);
            player.isMoving = false;
            player.CharacterHealth.beAttack = false;
            player.isSkill = false;
        }
        if (player.CurrentSkill == 3 && player.isSkill)
        {
            player.ChangeAnim(ConstString.powerUpParaname);
            player.CharacterHealth.Healing(player.gameObject,player.HealAmount);
            player.CurrentSkill = 0;
            OnBonusDame(player, 10, 1);
            player.StartCoroutine(OnDeBonusDame(player, 10, 1));
            player.StartCoroutine(EnableVfx(0));
            player.StartCoroutine(DisableVfx(0, 4f));
            player.CharacterHealth.beAttack = false;
            player.isAttack = false;
            player.isSkill = false;
        }
        if (player.isMoving)
        {
            player.ChangeState(new RunState());
        }
        if (!player.isSkill && !player.isMoving)
        {
            player.ChangeState(new DefaultAttackState());
        }
        if (player.CharacterHealth.dead)
        {
            player.ChangeState(new DeathState());
        }
    }
    public IEnumerator EnableVfx(int index)
    {
        yield return new WaitForEndOfFrame();
        if (VFXManger.Instance.vfx[index] != null)
            VFXManger.Instance.vfx[index].SetActive(true);
    }
    public IEnumerator DisableVfx(int index, float time)
    {
        yield return new WaitForSeconds(time);
        if (VFXManger.Instance.vfx[index] != null)
            VFXManger.Instance.vfx[index].SetActive(false);
    }
    public void OnBonusDame(PlayerController player, float dameBonus, int vfxIndex)
    {
        player.Dame += dameBonus;
        if (VFXManger.Instance.vfx[vfxIndex] != null)
            VFXManger.Instance.vfx[vfxIndex].SetActive(true);
    }
    public IEnumerator OnDeBonusDame(PlayerController player, float dameBonus, int vfxIndex)
    {
        yield return new WaitForSeconds(10f);
        player.Dame -= dameBonus;
        if (VFXManger.Instance.vfx[vfxIndex] != null)
            VFXManger.Instance.vfx[vfxIndex].SetActive(false);
    }
    public void OnExit(PlayerController player)
    {

    }
}
