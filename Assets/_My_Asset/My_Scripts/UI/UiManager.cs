using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : Singleton<UiManager>
{
    [SerializeField] private List<GameObject> uiGames;

    public List<GameObject> UiGames { get => uiGames;}

    private void Start()
    {
        foreach (Transform child in transform)
        {
            UiGames.Add(child.gameObject);
        }
        Time.timeScale = 0;
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        UiGames[0].SetActive(false);
    }
    public void Restart(string nameScene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(nameScene);
    }
}
