using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flockingMind : MonoBehaviour
{
    public float flockSpeed = 0.5f;
    float flockRotation = 3.0f;
    Vector3 headingAverage;
    Vector3 positionAverage;
    float neighbourDistance = 1.5f;
    bool strafing = false;
    // Start is called before the first frame update
    void Start()
    {
        flockSpeed = Random.Range(0.5f, 1);
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) >= FlockingMain.areaSize)
        {
            strafing = true;

        }
        else
            strafing = false;

        if (strafing)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), flockSpeed * Time.deltaTime);
            flockSpeed = Random.Range(0.5f, 1);
        }
        else

        
        if (Random.Range(0, 5) < 1)
            confirmRules();
        transform.Translate(0, 0, Time.deltaTime * flockSpeed);

    }

    void confirmRules()
    {
        GameObject[] ffr;
        ffr = FlockingMain.fishGroup;

        Vector3 fcentre = Vector3.zero;
        Vector3 favoid = Vector3.zero;
        float fspeed = 0.1f;

        Vector3 targetPos = FlockingMain.targetPos;
        float dist;
        int gSize = 0;
        foreach (GameObject go in ffr)
        {
            dist = Vector3.Distance(go.transform.position, this.transform.position);
            if (dist <= neighbourDistance)
            {
                fcentre += go.transform.position;
                gSize++;

                if (dist < 1.0f)
                {
                    favoid = favoid + (this.transform.position - go.transform.position);
                }
                flockingMind otherGroup = go.GetComponent<flockingMind>();
                fspeed = fspeed + otherGroup.flockSpeed;


            }

            
        }
    if (gSize > 0)
	{
            fcentre = fcentre / gSize + (targetPos - this.transform.position);
            flockSpeed = fspeed / gSize;
            Vector3 direction = (fcentre + favoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), flockRotation * Time.deltaTime);
           
	}
    }
}
