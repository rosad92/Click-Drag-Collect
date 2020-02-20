using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragCollect : MonoBehaviour{
    [Header("Set in Inspector")]
    public GameObject rCubePrefab;
    public GameObject bCubePrefab;
    public GameObject yCubePrefab;
    public GameObject pCubePrefab;
    public GameObject placementPrefab;
    public float cubeDist;
    public int cubeNum;
    public Vector3 cubeCenter;
    void Awake() {
        Invoke("dropCubes", 2f);
        for (int i = 0; i < cubeNum; i++) {
            GameObject cube = Instantiate<GameObject>(placementPrefab);
            Vector3 cubePos = Vector3.zero;
            cubePos.y = -6;
            cubePos.z = 0.5f;
            cubePos.x = ((i + 1) / 2) * cubeDist;
            if (i % 2 == 1) {
                cubePos.x = -cubePos.x;
            }
            cube.transform.position = cubePos;
        }
    }
    void dropCubes() {
        List<GameObject> cubes = new List<GameObject>();
        cubes.Add(rCubePrefab);
        cubes.Add(bCubePrefab);
        cubes.Add(yCubePrefab);
        cubes.Add(pCubePrefab);



        for (int i = 0; i< cubeNum; i++) {
            int randCube = Random.Range(0, cubes.Count);
            GameObject cube = Instantiate<GameObject>(cubes[randCube]);
            Vector3 cubePos = Vector3.zero;
            cubePos.y = 6;
            cubePos.x = ((i+1) / 2) * cubeDist;
            if(i%2 == 1) {
                cubePos.x = -cubePos.x;
            }
            cube.transform.position = cubePos;
            cubes.RemoveAt(randCube);
        }



    }
}
