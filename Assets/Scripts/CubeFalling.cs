using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFalling : MonoBehaviour{

    void OnTriggerEnter(Collider other) {
        if(this.tag == other.tag) {
            Destroy(this.gameObject);
            ClickDragCollect.cubesCollected++;
        }
    }

    void Update() {
       if(this.transform.position.y <(-4)) {
            Destroy(this.gameObject);
        }
    }
}
