using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour {
    [SerializeField]
    GameObject Node;

    [SerializeField]
    GameObject parentNode;

    GameObject selectedObject;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (!parentNode) {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
                    if (hit.transform.GetComponent<Node>()) {
                        parentNode = hit.transform.gameObject;
                    }
                }
                else {
                    //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    //parentNode = Instantiate(Node, pos, Quaternion.identity) as GameObject;
                }
            }
            else if (parentNode) {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (pos.y < parentNode.transform.position.y) {
                    GameObject childNode = Instantiate(Node, pos, Quaternion.identity) as GameObject;
                    childNode.GetComponent<Node>().partner = parentNode.GetComponent<Node>();
                    parentNode.GetComponent<Node>().partner = childNode.GetComponent<Node>();
                    parentNode = null;
                    childNode = null;
                }
            }
        }
    }
}
