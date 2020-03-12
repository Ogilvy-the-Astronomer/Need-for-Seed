using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Node partner;

    [SerializeField]
    GameObject connector;


    public GameObject root;
    public bool connected;
    bool doConnect;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (partner && !root) {
            //float angle = Vector2.Angle(transform.position, partner.transform.position);
            Vector2 angle = (transform.position - partner.transform.position);
            float length = Vector2.Distance(transform.position, partner.transform.position) / 2.0f;
            Vector2 pos = (transform.position + partner.transform.position) / 2.0f;
            root = Instantiate(connector, pos, Quaternion.identity);
            partner.root = root;
            root.transform.localScale = new Vector2(length / 20.0f, length / 20.0f);
            root.transform.forward = angle;
            int mod = 1;
            if (transform.position.x > partner.transform.position.x) mod = -1;
            root.transform.eulerAngles = new Vector3(0, 0, (Mathf.Abs(root.transform.eulerAngles.x) * mod) + 0.0f);
            root.transform.localScale = new Vector3(root.transform.localScale.x * mod, root.transform.localScale.y, 0);
            if (transform.position.y > partner.transform.position.y) {
                root.GetComponent<Connector>().start = this;
                root.GetComponent<Connector>().end = partner;
                root.transform.parent = transform;
            }
            else {
                root.GetComponent<Connector>().start = partner;
                root.GetComponent<Connector>().end = this;
                root.transform.localScale = new Vector3(-root.transform.localScale.x, root.transform.localScale.y, 0);
                root.transform.parent = partner.transform;
            }
        }
        if (!doConnect && connected) {
            doConnect = true;
            root.GetComponent<Connector>().connected = true;
        }
    }
}
