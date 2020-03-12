using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour {
    public Node start;
    public Node end;
    public float speed;
    float num;

    [SerializeField]
    Sprite[] root;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (num < 5) {
            num += speed;
        }
        GetComponent<SpriteRenderer>().sprite = root[Mathf.RoundToInt(num)];
    }
}
