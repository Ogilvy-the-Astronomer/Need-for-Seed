using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour {
    [SerializeField]
    GameObject Node;

    GameObject parentNode;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) && !parentNode) {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            parentNode = Instantiate(Node, pos, Quaternion.identity) as GameObject;

        }
        else if (Input.GetMouseButtonDown(0) && parentNode) {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject childNode = Instantiate(Node, pos, Quaternion.identity) as GameObject;
            childNode.GetComponent<Node>().partner = parentNode.GetComponent<Node>();
            parentNode.GetComponent<Node>().partner = childNode.GetComponent<Node>();
            parentNode = null;
        }

    }
}
