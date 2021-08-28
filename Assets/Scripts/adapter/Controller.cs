using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Vector3 direction = new Vector3(0, 0, 0);
    private movementconverter mc;

    public void Start()
    {
        mc = gameObject.GetComponent<movementconverter>();
        //rb = GetComponent<Rigidbody>();
    }
    public void Move(string message, float speed)
    {
      
        mc.conversionService(message);
        transform.Translate(direction * Time.deltaTime * speed);

        //mc.conversionService(dir);
        //transform.Translate(x,y,z);

        
    }



}
