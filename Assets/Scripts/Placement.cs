using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour {
     void OnTriggerEnter(Collider other) {
        if(this.GetComponent<Renderer>().material.color.r == 1){
            Color c = other.GetComponent<Renderer>().material.color;
            this.GetComponent<Renderer>().material.color = c;
        }

    }
    void OnTriggerExit(Collider other) {
        if (this.GetComponent<Renderer>().material.color != other.GetComponent<Renderer>().material.color) {
            return;
        }
        
        Color c = this.GetComponent<Renderer>().material.color;
        c.a = 1;
        c.r = 1;
        c.g = 1;
        c.b = 1;
        this.GetComponent<Renderer>().material.color = c;
    }
}

