using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrients : MonoBehaviour {
    public bool connected;
    public float amount;

    Connector temp = null;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (connected && amount > 0) {
            FindObjectOfType<ResourceManager>().currentNutrients += amount * 0.05f * Time.deltaTime;
            amount -= amount * 0.05f * Time.deltaTime;
        }
        else if (connected) {
            FindObjectOfType<ResourceManager>().currentNutrients += Time.deltaTime/100.0f;
        }
    }

    void OnTriggerEnter(Collider cols) {
        if (cols.gameObject.GetComponent<Node>()) {
            connected = true;
            cols.gameObject.GetComponent<Node>().connected = true;
        }
    }
}
