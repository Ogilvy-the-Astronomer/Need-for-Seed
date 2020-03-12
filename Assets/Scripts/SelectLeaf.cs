using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLeaf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Select it
            Vector2 raycastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector2.zero);

            if (hit.collider != null)
            {
                // Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject == transform.GetChild(0).gameObject)
                {
                    GetComponent<LookAtMouse>().enabled = true;
                    GetComponent<LookAtSun>().enabled = false;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            // Deselect it
            GetComponent<LookAtMouse>().enabled = false;
            GetComponent<LookAtSun>().enabled = true;
        }
    }
}
