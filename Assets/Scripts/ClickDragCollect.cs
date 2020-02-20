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
    void Awake() {
        createPlacement();
        Invoke("dropCubes", 2f);
    }

    void createPlacement() {
        for (int i = 0; i < cubeNum; i++) {
            GameObject cube = Instantiate<GameObject>(placementPrefab);
            Vector3 cubePos = Vector3.zero;
            cubePos.y = -4;
            cubePos.z = 0.5f;
            cubePos.x = (i * cubeDist);
            cube.transform.position = cubePos;
            print(cube.GetComponent<Renderer>().material.color.r);
        }

    }
    void dropCubes() {
        //Add all cube colors to list
        List<GameObject> cubes = new List<GameObject>();
        cubes.Add(rCubePrefab);
        cubes.Add(bCubePrefab);
        cubes.Add(yCubePrefab);
        cubes.Add(pCubePrefab);

        // place them to drop in a random order
        for (int i = 0; i< cubeNum; i++) {
            int randCube = Random.Range(0, cubes.Count);
            GameObject cube = Instantiate<GameObject>(cubes[randCube]);
            Vector3 cubePos = Vector3.zero;
            cubePos.y = 6;
            cubePos.x = i * cubeDist;
            cube.transform.position = cubePos;
            cubes.RemoveAt(randCube);
        }



    }
}
