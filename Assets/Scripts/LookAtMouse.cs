using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public bool m_isRight;
    void Update()
    {
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg /*- 90.0f*/;

        //Debug.Log("x : " + dir.x);
        //Debug.Log("y : " + dir.y);
        //Debug.Log("angle before : " + angle);
        if (m_isRight)
        {
            if (angle > 0)
            {
                angle = Mathf.Clamp(angle, 20.0f, 160.0f);
                //Debug.Log("angle after: " + angle);
                transform.eulerAngles = new Vector3(0.0f, 180.0f, angle);
            }
        }
        else
        {
            if (angle < 0)
            {
                angle = Mathf.Clamp(angle, -160.0f, -20.0f);
                //Debug.Log("angle after: " + angle);
                transform.eulerAngles = new Vector3(0.0f, 180.0f, angle);
            }
        }
    }
}
