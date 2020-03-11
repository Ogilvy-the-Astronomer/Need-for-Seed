using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Node partner;

    [SerializeField]
    GameObject connector;

    public GameObject root;
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
            root = Instantiate(connector, transform.position, Quaternion.identity);
            partner.root = root;
            root.transform.localScale = new Vector2(0, 0.3f);
            root.transform.forward = angle;
            root.transform.eulerAngles = new Vector3(0, 0, root.transform.eulerAngles.x);
            Connector con = connector.GetComponent<Connector>();
            con.maxLength = length;
            con.startPos = transform.position;
            con.endPos = pos;
            con.start = this;
        }
    }
}
