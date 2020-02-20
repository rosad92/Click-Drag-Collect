using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDrag : MonoBehaviour{

    public bool drag = false;
    // Update is called once per frame
    void Update(){
        if (drag) {
            Vector3 mousePos2D = Input.mousePosition;
            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
            Vector3 pos = this.transform.position;
            pos.x = mousePos3D.x;
            pos.y = mousePos3D.y;
            this.transform.position = pos;
            if (Input.GetMouseButtonUp(0)) {
                drag = false;
            }
        }   

    }

    private void OnMouseDown() {
        drag = true;
    }
}
