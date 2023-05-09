using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandomTransform : MonoBehaviour
{
    public GameObject cubePrefab;
    public int maxVel, minVel;
    public int maxCubes, minCubes;
    private int changeVelocity;
    private int actualFrameCount;
    private List<GameObject> cubes = new List<GameObject>();
    // Update is called once per frame

    private void Start()
    {
        int nCubes = Random.Range(minCubes, maxCubes);
        for (int i = 0; i < nCubes; i++)
        {
            var _cube = Instantiate(cubePrefab, this.transform);
            cubes.Add(_cube);
        }
        changeVelocity = Random.Range(minVel, maxVel);
        actualFrameCount = changeVelocity - 1;
    }

    void Update()
    {
        actualFrameCount++;
        if (actualFrameCount == changeVelocity)
        {
            foreach (var _cube in cubes)
            {
                _cube.transform.localScale = new Vector3(Random.Range(0, 2f), Random.Range(0, 2f), Random.Range(0, 2f));
                _cube.transform.rotation = Quaternion.Euler(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f));
            }
        }
        if (actualFrameCount == changeVelocity)
            actualFrameCount = 0;
    }
}
