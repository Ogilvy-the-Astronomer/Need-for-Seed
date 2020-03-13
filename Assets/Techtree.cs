using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Techtree : MonoBehaviour
{
    public GameObject TechtreePicture;
    bool isTechTreeVisible = true;


    public void clickTechTreeButton()
    {
        //if(isTechTreeVisible)
        //{
        //    //Debug.Log("First statement");
        //    isTechTreeVisible = false;
        //    TechtreePicture.SetActive(false);
        //}
        //else
        //{
        //    //Debug.Log("Second statement");
        //    isTechTreeVisible = true;
        //    TechtreePicture.SetActive(true);
        //
        //}
        isTechTreeVisible = !isTechTreeVisible;
        TechtreePicture.SetActive(isTechTreeVisible);
    }
}
