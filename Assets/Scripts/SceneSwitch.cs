using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SceneChanged(string NameOfScene)
    {
        SceneManager.LoadScene(NameOfScene);
    }

    public void GameObjectActive(GameObject gameObject)
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
