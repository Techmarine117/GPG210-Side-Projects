using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingMain : MonoBehaviour
{
    public GameObject Fish;
    public static int areaSize =40;
    static int fishAmount = 50;
    public static GameObject[] fishGroup = new GameObject[fishAmount];
    public static Vector3 targetPos = Vector3.zero;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < fishAmount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-areaSize, areaSize),
                                      Random.Range(-areaSize, areaSize),
                                      Random.Range(-areaSize, areaSize));
            fishGroup[i] = (GameObject)Instantiate(Fish, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 8000)< 50)
        {
            targetPos = new Vector3(Random.Range(-areaSize, areaSize),
                                      Random.Range(-areaSize, areaSize),
                                      Random.Range(-areaSize, areaSize));
            target.transform.position = targetPos;
        }
    }
}
