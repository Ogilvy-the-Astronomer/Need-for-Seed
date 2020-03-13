using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrients : MonoBehaviour {
    public bool connected;
    public float amount;
    float startAmount;

    Connector temp = null;
    ResourceManager rm;
    // Start is called before the first frame update
    void Start() {
        startAmount = amount;
        rm = FindObjectOfType<ResourceManager>();
    }

    // Update is called once per frame
    void Update() {
        if (connected && amount > 0.05f) {
            if (rm.currentNutrients < rm.maxNutrients) {
                rm.currentNutrients += amount * 0.05f * Time.deltaTime;
            }
            amount -= amount * 0.05f * Time.deltaTime;
            float size = amount / startAmount / 3.0f;
            transform.localScale = new Vector3(size, size, size);
            GetComponent<AudioSource>().volume = 20.0f / Vector3.Distance(transform.position, Camera.main.transform.position);
        }
        else if (connected) {
            FindObjectOfType<ResourceManager>().currentNutrients += Time.deltaTime/100.0f;
        }
    }

    void OnTriggerEnter(Collider cols) {
        if (cols.gameObject.GetComponent<Node>()) {
            connected = true;
            cols.gameObject.GetComponent<Node>().connected = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
