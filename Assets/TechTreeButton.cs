using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TechTreeButton : MonoBehaviour
{
  public TextMeshProUGUI CostGO;
  public float cost;
  public int NoOfRebuys;
  public bool isOutOfStock = false;
  void Start()
  {
    
  }

  void Update()
  {
    CostGO.text = cost.ToString();
    if (isOutOfStock == true)
    {
      gameObject.SetActive(false);
    }
  }


  void OnMouseEnter()
  {
    Debug.Log("overoverover");
    transform.localScale = new Vector3(1.2f,1.2f,1.2f);
  }
  

  void OnMouseExit()
  {
    Debug.Log("exitexitexit");
    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); ;
  }
}
