using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Techtree : MonoBehaviour
{
    public GameObject TechtreePicture;
    bool isTechTreeVisible = true;
    void clickTechTreeButton()
    {
        if(isTechTreeVisible)
        {
            isTechTreeVisible = true;
            TechtreePicture.SetActive(true);
        }
        else
        {
            isTechTreeVisible = false;
            TechtreePicture.SetActive(false);
        }
    }
}
