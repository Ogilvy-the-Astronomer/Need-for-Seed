using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtSun : MonoBehaviour
{
    // Publics
    public GameObject m_sun;
    public GameObject m_moon;
    public GameObject m_resources;
    public GameObject m_dayCycler;
    public float m_speed;
    public bool m_isRight;
    public float m_energyGainPercent = 1;
    public float m_lunarEnergyGainPercent = 0.5f;
    public bool m_lunar;
    // Privates
    private float m_angleDiff;
    private float m_energyGained;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_dayCycler.GetComponent<SunMoonCycle>().m_isDay)
        {
            Vector2 dir = Camera.main.WorldToScreenPoint(m_sun.transform.position) - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            angle = -angle;
            if (m_isRight)
            {
                m_angleDiff = Mathf.Abs(transform.eulerAngles.z - 90 - angle);
                //Debug.Log("Sun Angle: " + angle);
                //Debug.Log("Trans: " + (transform.eulerAngles.z - 90));
                //Debug.Log("Difference: " + Mathf.Abs(transform.eulerAngles.z - 90 - angle));
                if (angle < (transform.eulerAngles.z - 90))
                {
                    //Debug.Log("Trans: " + (transform.eulerAngles.z - 90));
                    transform.Rotate(new Vector3(0.0f, 0.0f, -m_speed * Time.deltaTime));
                }
                else if (angle > (transform.eulerAngles.z - 90))
                {
                    //Debug.Log("Trans: " + (transform.eulerAngles.z - 90));
                    transform.Rotate(new Vector3(0.0f, 0.0f, m_speed * Time.deltaTime));
                }
            }
            else
            {
                m_angleDiff = Mathf.Abs(transform.eulerAngles.z - 270 - angle);
                //Debug.Log("Sun Angle: " + angle);
                //Debug.Log("Trans: " + (transform.eulerAngles.z - 270));
                //Debug.Log("Difference: " + Mathf.Abs(transform.eulerAngles.z - 270 - angle));
                if (angle < (transform.eulerAngles.z - 270))
                {
                    //Debug.Log("Trans: " + (transform.eulerAngles.z - 270));
                    transform.Rotate(new Vector3(0.0f, 0.0f, -m_speed * Time.deltaTime));
                }
                else if (angle > (transform.eulerAngles.z - 270))
                {
                    //Debug.Log("Trans: " + (transform.eulerAngles.z - 270));
                    transform.Rotate(new Vector3(0.0f, 0.0f, m_speed * Time.deltaTime));
                }
            }
            m_energyGained = m_energyGainPercent / (m_angleDiff + 10);
            m_resources.GetComponent<ResourceManager>().currentSunlight += m_energyGained;
            //Debug.Log("Energy Gained: " + m_energyGained);
        }
        else if (!m_lunar)
        {
            Vector2 dir = Camera.main.WorldToScreenPoint(new Vector2(0.0f, 2.0f))- Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            angle = -angle;
            if (m_isRight)
            {
                if (angle < (transform.eulerAngles.z - 90))
                {
                    //Debug.Log("Trans: " + (transform.eulerAngles.z - 90));
                    transform.Rotate(new Vector3(0.0f, 0.0f, -m_speed * Time.deltaTime));
                }
                else if (angle > (transform.eulerAngles.z - 90))
                {
                    //Debug.Log("Trans: " + (transform.eulerAngles.z - 90));
                    transform.Rotate(new Vector3(0.0f, 0.0f, m_speed * Time.deltaTime));
                }
            }
            else
            {
                if (angle < (transform.eulerAngles.z - 270))
                {
                    //Debug.Log("Trans: " + (transform.eulerAngles.z - 270));
                    transform.Rotate(new Vector3(0.0f, 0.0f, -m_speed * Time.deltaTime));
                }
                else if (angle > (transform.eulerAngles.z - 270))
                {
                    //Debug.Log("Trans: " + (transform.eulerAngles.z - 270));
                    transform.Rotate(new Vector3(0.0f, 0.0f, m_speed * Time.deltaTime));
                }
            }
        }
        else
        {
            Vector2 dir = Camera.main.WorldToScreenPoint(m_moon.transform.position) - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            angle = -angle;
            if (m_isRight)
            {
                m_angleDiff = Mathf.Abs(transform.eulerAngles.z - 90 - angle);
                //Debug.Log("Sun Angle: " + angle);
                //Debug.Log("Trans: " + (transform.eulerAngles.z - 90));
                //Debug.Log("Difference: " + Mathf.Abs(transform.eulerAngles.z - 90 - angle));
                if (angle < (transform.eulerAngles.z - 90))
                {
                    //Debug.Log("Trans: " + (transform.eulerAngles.z - 90));
                    transform.Rotate(new Vector3(0.0f, 0.0f, -m_speed * Time.deltaTime));
                }
                else if (angle > (transform.eulerAngles.z - 90))
                {
                    //Debug.Log("Trans: " + (transform.eulerAngles.z - 90));
                    transform.Rotate(new Vector3(0.0f, 0.0f, m_speed * Time.deltaTime));
                }
            }
            else
            {
                m_angleDiff = Mathf.Abs(transform.eulerAngles.z - 270 - angle);
                //Debug.Log("Sun Angle: " + angle);
                //Debug.Log("Trans: " + (transform.eulerAngles.z - 270));
                //Debug.Log("Difference: " + Mathf.Abs(transform.eulerAngles.z - 270 - angle));
                if (angle < (transform.eulerAngles.z - 270))
                {
                    //Debug.Log("Trans: " + (transform.eulerAngles.z - 270));
                    transform.Rotate(new Vector3(0.0f, 0.0f, -m_speed * Time.deltaTime));
                }
                else if (angle > (transform.eulerAngles.z - 270))
                {
                    //Debug.Log("Trans: " + (transform.eulerAngles.z - 270));
                    transform.Rotate(new Vector3(0.0f, 0.0f, m_speed * Time.deltaTime));
                }
            }
            m_energyGained = m_lunarEnergyGainPercent / (m_angleDiff + 10);
            m_resources.GetComponent<ResourceManager>().currentSunlight += m_energyGained;
            //Debug.Log("Energy Gained: " + m_energyGained);
        }
    }
}
