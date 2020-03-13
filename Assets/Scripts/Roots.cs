using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour {
    [SerializeField]
    GameObject Node;

    [SerializeField]
    Sprite[] knots = new Sprite[2];
    

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

    public float lastDepth;

    [SerializeField]
    GameObject highlight;

    // Start is called before the first frame update
    void Start() {
        rm = FindObjectOfType<ResourceManager>();
    }

    // Update is called once per frame
    void Update() {
        highlight.transform.Rotate(Vector3.forward, 1.0f);
        if (Input.GetKeyDown(KeyCode.Q)) {
            FindObjectOfType<ResourceManager>().currentNutrients += 100;
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            FindObjectOfType<ResourceManager>().currentSunlight += 100;
        }
        if (Input.GetMouseButtonDown(0)) {
            if (!parentNode) {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
                    if (hit.transform.GetComponent<Node>() && !hit.transform.GetComponent<Node>().connected) {
                        parentNode = hit.transform.gameObject;
                        highlight.transform.position = hit.transform.position - Vector3.forward;
                    }
                    else {
                        highlight.transform.position += Vector3.forward * 100.0f;
                        parentNode = null;
                    }
                }
                
            }
            else if (parentNode) {
                RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
                bool placeable = true;
                for (int i = 0; i < hits.Length; i++) {
                    if (hits[i].transform.GetComponent<Ground>()) {
                        RaycastHit hit = hits[i];
                        if (hit.transform.GetComponent<Ground>().hardness > tech) {
                            placeable = false;
                            i = hits.Length + 1;
                        }
                    }
                }
                if (placeable) {
                    Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    float dist = Vector2.Distance(pos, parentNode.transform.position);
                    if (dist < maxLength && dist > minLength) {
                        if (pos.y < parentNode.transform.position.y && rm.currentSunlight >= 20 && !parentNode.GetComponent<Node>().connected) {
                            if (pos.y < -190) {
                                Camera.main.GetComponent<CamController>().Win();
                            }
                            rm.currentSunlight -= 20;
                            GameObject childNode = Instantiate(Node, (Vector3)pos - Vector3.forward, Quaternion.identity) as GameObject;
                            childNode.GetComponent<SpriteRenderer>().sprite = knots[Random.Range(0, 2)];
                            childNode.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
                            float s = dist / 20.0f;// Random.Range(0.1f, 0.2f);
                            childNode.transform.localScale = new Vector3(s, s, s);
                            childNode.transform.parent = parentNode.transform;
                            childNode.GetComponent<Node>().partner = parentNode.GetComponent<Node>();
                            parentNode.GetComponent<Node>().partner = childNode.GetComponent<Node>();
                            parentNode = null;
                            childNode = null;
                            lastDepth = pos.y;
                            highlight.transform.position += Vector3.forward * 100.0f;
                        }
                    }
                }
            }
        }
    }
}
