using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamController : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField]
    float speed;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        transform.position += new Vector3(0, Input.mouseScrollDelta.y * speed, 0);
    }

    public void Retry() {
        SceneManager.LoadScene("Howred"); //main scene name here
    }

    public void Quit() {
        Application.Quit();
    }
}
