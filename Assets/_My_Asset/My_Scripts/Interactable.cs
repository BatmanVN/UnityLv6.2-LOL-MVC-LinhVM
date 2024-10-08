using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    public void Onfocus(Transform playerTransform);
    public void OnDeFocus();
}
