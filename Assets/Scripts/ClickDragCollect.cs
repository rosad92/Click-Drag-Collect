using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragCollect : MonoBehaviour{
    [Header("Set in Inspector")]
    public GameObject rCubePrefab;
    public GameObject bCubePrefab;
    public GameObject yCubePrefab;
    public GameObject pCubePrefab;
    public float cubeDist;
    public int cubeNum;
    public Vector3 cubeCenter;
    void Awake() {
        Invoke("dropCubes", 2f);
    }

    void dropCubes() {
        GameObject rCube = Instantiate<GameObject>(rCubePrefab);
        rCube.transform.position = new Vector3(1, 6, 0);
        GameObject bCube = Instantiate<GameObject>(bCubePrefab);
        bCube.transform.position = new Vector3(-1, 6, 0);
        GameObject yCube = Instantiate<GameObject>(yCubePrefab);
        yCube.transform.position = new Vector3(3, 6, 0);
        GameObject pCube = Instantiate<GameObject>(pCubePrefab);
        pCube.transform.position = new Vector3(-3, 6, 0);


        /* for (int i = 0; i<cubeNum; i++) {


            GameObject cube = Instantiate<GameObject>(rCubePrefab);
            Vector3 cubePos = Vector3.zero;
            cubePos.y = 6;
            cubePos.x = ((i+1) / 2) * cubeDist;
            if(i%2 == 1) {
                cubePos.x = -cubePos.x;
            }
            cube.transform.position = cubePos;
        }*/



    }
}
