using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject CanvaOption;

    public void Play(GameObject canvaInGame)
    {
        canvaInGame.SetActive(true);
        CanvaOption.SetActive(false);
    }
}
