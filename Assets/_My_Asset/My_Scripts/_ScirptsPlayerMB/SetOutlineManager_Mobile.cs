using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SetOutlineManager_Mobile : MonoBehaviour
{
    [SerializeField] protected PlayerController_Mobile player;
    [SerializeField] protected LayerMask target;
    [SerializeField] private Transform targetObj;
    private Outline targetOutLine;
    private void Update()
    {
        SetHighlight();
    }
    public void SetHighlight()
    {
        if (targetObj != null)
        {
            targetOutLine.enabled = false;
            targetObj = null;
        }
        targetObj = player.Target;
        if (targetObj != null && player.Target != null)
        {
            if (targetObj.CompareTag(ConstString.spearMan))
            {
                targetOutLine = targetObj.GetComponent<Outline>();
                targetOutLine.enabled = true;
            }
            else
                targetObj = null;
        }
    }
    public void SelectTarget()
    {
        if (targetObj != null && targetObj.CompareTag(ConstString.spearMan))
        {
            if (player.Target.GetComponent<Outline>() != null)
                player.Target.GetComponent<Outline>().enabled = false;
            player.Target = targetObj;
            if (player.Target.GetComponent<Outline>() != null)
                player.Target.GetComponent<Outline>().enabled = true;

            targetOutLine.enabled = true;
            targetObj = null;
        }
    }
    public void DeSelectTarget()
    {
        if (player.Target != null)
        {
            player.Target.GetComponent<Outline>().enabled = false;
            player.Target = null;
            targetObj = null;
        }
    }
}
