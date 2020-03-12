using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour {
    [SerializeField]
    GameObject Node;

    [SerializeField]
    GameObject parentNode;


    GameObject selectedObject;
    public int tech;

    [SerializeField]
    int maxLength;

    [SerializeField]
    int minLength;

    [SerializeField]
    ResourceManager rm;
    // Start is called before the first frame update
    void Start() {
        rm = FindObjectOfType<ResourceManager>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (!parentNode) {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
                    if (hit.transform.GetComponent<Node>() && !hit.transform.GetComponent<Node>().connected) parentNode = hit.transform.gameObject;
                }
            }
            else if (parentNode) {
                RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
                for (int i = 0; i < hits.Length; i++) {
                    if (hits[i].transform.GetComponent<Ground>()) {
                        RaycastHit hit = hits[i];
                        if (hit.transform.GetComponent<Ground>().hardness <= tech) {
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            if (Vector2.Distance(pos, parentNode.transform.position) < maxLength && Vector2.Distance(pos, parentNode.transform.position) > minLength) {
                                if (pos.y < parentNode.transform.position.y && rm.currentSunlight >= 20 && !parentNode.GetComponent<Node>().connected) {
                                    rm.currentSunlight -= 20;
                                    GameObject childNode = Instantiate(Node, (Vector3)pos - Vector3.forward, Quaternion.identity) as GameObject;
                                    childNode.transform.parent = parentNode.transform;
                                    childNode.GetComponent<Node>().partner = parentNode.GetComponent<Node>();
                                    parentNode.GetComponent<Node>().partner = childNode.GetComponent<Node>();
                                    parentNode = null;
                                    childNode = null;
                                }
                            }
                        }
                        i = hits.Length + 1;
                    }
                }
            }
        }
    }
}
