using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoonCycle : MonoBehaviour
{
    public List<AudioClip> sounds;
    // Publics
    public GameObject m_sunCycler;
    public GameObject m_moonCycler;
    public float m_speed;
    public bool m_isDay;
    // Privates
    private float m_amountRotated;
    // Start is called before the first frame update
    void Start()
    {
        m_moonCycler.SetActive(false);
        m_isDay = true;
        m_amountRotated = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_amountRotated += m_speed * Time.deltaTime;
        if (m_isDay)
        {
            if (m_amountRotated >= 60.0f)
            {
                m_isDay = false;
                m_amountRotated = 0.0f;
                ChangeToNight();
            }
        }
        else if (!m_isDay)
        {
            if (m_amountRotated >= 60.0f)
            {
                m_isDay = true;
                m_amountRotated = 0.0f;
                ChangeToDay();
            }
        }
    }

    void ChangeToDay()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sounds[0]);
        m_moonCycler.transform.eulerAngles = new Vector3(0.0f, 0.0f, 30.0f);
        m_moonCycler.SetActive(false);
        m_sunCycler.SetActive(true);
    }

    void ChangeToNight()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sounds[1]);
        m_sunCycler.transform.eulerAngles = new Vector3(0.0f, 0.0f, 30.0f);
        m_moonCycler.SetActive(true);
        m_sunCycler.SetActive(false);
    }
}
