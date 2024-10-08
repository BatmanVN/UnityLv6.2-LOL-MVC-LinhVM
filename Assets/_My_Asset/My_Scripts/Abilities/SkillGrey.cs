using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGrey : MonoBehaviour
{
    [SerializeField] protected Image skillImage;
    [SerializeField] protected Text skillText;
    [SerializeField] protected CoolDown timeCD;
    public void EnalbeCooldown()
    {
        if (skillImage != null && skillText != null)
        {
            skillText.gameObject.SetActive(true);
            skillImage.gameObject.SetActive(true);
            skillText.text = Mathf.Ceil(timeCD.CurrentSkillCooldown).ToString();
            skillImage.fillAmount = timeCD.CurrentSkillCooldown / timeCD.SkillCooldown;
        }
    }
    public void DisAbleCoolDown()
    {
        if (skillImage != null && skillText != null)
        {
            skillText.gameObject.SetActive(false);
            skillImage.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        timeCD.onCoolDown.AddListener(EnalbeCooldown);
        timeCD.onDeCoolDown.AddListener(DisAbleCoolDown);
    }
}
