using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public static void LoadGameLevel()
    {
        SceneManager.LoadScene(1);
    }
    public static void LoadResults()
    {
        SceneManager.LoadScene(2);
    }
}
