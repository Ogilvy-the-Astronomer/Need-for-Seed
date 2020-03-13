using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour {
    public Node start;
    public Node end;
    public float speed;
    float num;
    public bool connected;
    bool doConnect;

    [SerializeField]
    Sprite[] root;

    [SerializeField]
    List<AudioClip> sounds;

    bool first;

    float colour;
    // Start is called before the first frame update
    void Start() {
        if (FindObjectsOfType<Connector>().Length == 1) first = true;
        GetComponent<AudioSource>().PlayOneShot(sounds[Random.Range(0, 2)]);
    }

    // Update is called once per frame
    void Update() {
        if (num < 5) {
            num += speed;
        }
        else if (num >= 5 && connected) {
            GetComponent<SpriteRenderer>().color = new Color(Mathf.Sin(colour), 1 , Mathf.Sin(colour));
            end.GetComponent<SpriteRenderer>().color = new Color(Mathf.Sin(colour), 1, Mathf.Sin(colour));
            if(first) start.GetComponent<SpriteRenderer>().color = new Color(Mathf.Sin(colour), 1, Mathf.Sin(colour));
            colour += 0.03f;
            doConnect = true;
        }
        GetComponent<SpriteRenderer>().sprite = root[Mathf.RoundToInt(num)];
        if (doConnect) DoConnect();
    }

    void DoConnect() {
        Connector[] roots = FindObjectsOfType<Connector>();
        for (int i = 0; i < roots.Length; i++) {
            if (roots[i].end == start) roots[i].connected = true;
        }
    }
}
