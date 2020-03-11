using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour {
    public Node start;
    float currentLength;
    public float maxLength;
    public Vector3 startPos;
    public Vector3 endPos;
    public float speed;
    Vector3 posMod;
    // Start is called before the first frame update
    void Start() {
        posMod = transform.position - transform.right;
        speed = 0.003f;
    }

    // Update is called once per frame
    void Update() {
        //float posMod = Vector2.Distance(startPos, endPos) * speed / 2.0f;
        if (currentLength < maxLength) {
            currentLength += speed;
            transform.localScale = new Vector2(currentLength, 0.3f);
            //transform.position += transform.right * posMod;
            transform.position = (posMod) + (transform.forward) * (transform.localScale.x / 2.0f + maxLength / 2.0f);
        }
    }
}
