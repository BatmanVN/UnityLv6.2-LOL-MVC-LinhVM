using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearManager : Singleton<SpearManager>
{
    [SerializeField] private List<SpearController> spearMan;

    public List<SpearController> SpearMan { get => spearMan; }

    private void Start()
    {
        foreach (Transform child in transform)
        {
            SpearController solider = child.GetComponent<SpearController>();
            SpearMan.Add(solider);
        }
    }
    public void CheckWin()
    {
        for (int i = 0; i < spearMan.Count; i++)
        {
            if (spearMan[i].CharacterHealth.dead)
            {
                if (spearMan[i] != null)
                {
                    spearMan.Remove(spearMan[i]);
                }
            }
        }
        if (spearMan == null)
        {
            UiManager.Instance.UiGames[2].SetActive(true);
        }
    }
    private void Update()
    {
        CheckWin();
    }
}
