using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFalling : MonoBehaviour{

    void OnTriggerEnter(Collider other) {
        if(this.tag == other.tag) {
            Destroy(this.gameObject);
        }
    }

    void Update() {
       if(this.transform.position.y <(-10)) {
            Destroy(this.gameObject);
        }
    }
}
