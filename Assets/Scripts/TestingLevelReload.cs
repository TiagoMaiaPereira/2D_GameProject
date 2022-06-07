using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingLevelReload : MonoBehaviour
{
    public void ReloadLevel()
    {
        SceneManager.LoadScene("TestingScene");
    }
}

