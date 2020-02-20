using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDragCollect : MonoBehaviour{
    [Header("Set in Inspector")]
    public GameObject rCubePrefab;
    public GameObject bCubePrefab;
    public GameObject yCubePrefab;
    public GameObject pCubePrefab;
    public GameObject placementPrefab;

    public GameObject rDragCubePrefab;
    public GameObject bDragCubePrefab;
    public GameObject pDragCubePrefab;
    public GameObject yDragCubePrefab;

    public Text UI;

    public float cubeDist;
    public int cubeNum;

    public static int cubesCollected = 0;
    public int phases = 1;
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

      List<GameObject> dragCubes = new List<GameObject>();
        dragCubes.Add(rDragCubePrefab);
        dragCubes.Add(bDragCubePrefab);
        dragCubes.Add(yDragCubePrefab);
        dragCubes.Add(pDragCubePrefab);

        // place them to drop in a random order
        for (int i = 0; i < cubeNum; i++) {
            int randCube = Random.Range(0, cubes.Count);
            GameObject cube = Instantiate<GameObject>(cubes[randCube]);
            Vector3 cubePos = Vector3.zero;
            cubePos.y = 6;
            cubePos.x = i * cubeDist;
            cube.transform.position = cubePos;
            cubes.RemoveAt(randCube);
            GameObject dragCube = Instantiate<GameObject>(dragCubes[randCube]);
            /*  Vector3 dragCubePos = cubePos;
              dragCubePos.y = -6;
              dragCube.transform.position = dragCubePos;*/
            dragCubes.RemoveAt(randCube);

        }
    }
    void Update() {
        if(cubesCollected >= cubeNum) {
            NewLevel();
            cubesCollected = 0;
        }
    }

    void NewLevel() {
        GameObject [] cubes = GameObject.FindGameObjectsWithTag("Red");
        foreach(GameObject temp in cubes) { Destroy(temp); }
        GameObject[] cubes1 = GameObject.FindGameObjectsWithTag("Blue");
        foreach (GameObject temp in cubes1) { Destroy(temp); }
        GameObject[] cubes2 = GameObject.FindGameObjectsWithTag("Yellow");
        foreach (GameObject temp in cubes2) { Destroy(temp); }
        GameObject[] cubes3 = GameObject.FindGameObjectsWithTag("Purple");
        foreach (GameObject temp in cubes3) { Destroy(temp); }

        GameObject[] placement = GameObject.FindGameObjectsWithTag("Placement");
        if (cubeNum < 4) {
            cubeNum++;
            foreach (GameObject temp in placement) {
                Destroy(temp);
            }
            createPlacement();
        } else {
            foreach (GameObject temp in placement) {
                Color c = temp.GetComponent<Renderer>().material.color;
                c.a = 1;
                c.r = 1;
                c.g = 1;
                c.b = 1;
                temp.GetComponent<Renderer>().material.color = c;
            }
        }
        UI.text = "Phases Cleared: " + phases;
        phases++;


        Invoke("dropCubes", 1f);
    }
}
