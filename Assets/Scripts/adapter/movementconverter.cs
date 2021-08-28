using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementconverter : MonoBehaviour
{
    private Controller controller;
    private void Start()
    {
        controller = gameObject.GetComponent<Controller>();  
    }
    public void conversionService(string message)
    {
       
        float x = 0;
        float z = 0;
        if (message[0] == 'W')
        {
            z++;
        }
        if (message[1] == 'S')
        {
            z--;
        }
        if (message[2] == 'A')
        {
            x--;
        }
        if (message[3] == 'D')
        {
            x++;
        }
        controller.direction = new Vector3(x, 0, z);

        //Dir *= Time.deltaTime;
        //controller.x = Dir.x;
        //controller.y = Dir.y;
        //controller.z = Dir.z;


    }
}
