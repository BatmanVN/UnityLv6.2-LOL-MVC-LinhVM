using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SetOutlineManager : MonoBehaviour
{
    [SerializeField] protected PlayerController player;
    [SerializeField] protected LayerMask target;
    private Transform targetObj;
    private Outline targetOutLine;
    private RaycastHit hit;
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out hit, target))
        {
            targetObj = hit.transform;
            if (targetObj.CompareTag(ConstString.spearMan) && targetObj != player.Target)
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
            player.Target = hit.transform;
            if (player.Target.GetComponent<Outline>() != null)
                player.Target.GetComponent<Outline>().enabled = true;

            targetOutLine.enabled = true;
            targetObj = null;
        }
    }
    public void DeSelectTarget()
    {
        player.Target.GetComponent<Outline>().enabled = false;
        player.Target = null;
    }
}
