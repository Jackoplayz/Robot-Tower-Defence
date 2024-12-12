using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPlanet : MonoBehaviour
{
    public GameController myGameController;
    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        myGameController = FindFirstObjectByType<GameController>();
    }

   public void LoadSceneByStar()
    {
        SceneManager.LoadScene(levelName + myGameController.ReturnStarIndex());
    }
}
