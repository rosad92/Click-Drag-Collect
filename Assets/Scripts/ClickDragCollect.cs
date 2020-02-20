using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragCollect : MonoBehaviour{
    [Header("Set in Inspector")]
    public GameObject cubePrefab;
    void Awake() {
        GameObject cube = Instantiate<GameObject>(cubePrefab);
        cube.transform.position = new Vector3(0, 6, 0);
    }
}
