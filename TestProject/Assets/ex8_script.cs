using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex8_script : MonoBehaviour
{
    public Vector3[] points = new Vector3[3];
    public Vector3 center;
    public float radius;
    Vector3 RandomVector3()
    {
        return new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
    }

    //Vector3 mul()

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; ++i)
        {
            points[i] = RandomVector3();
            center += points[i];
        }
        //Debug.Log("x=" + center.x);
        center /= 3;
        radius = Vector3.Distance(center, points[0]);
        //Debug.Log("x=" + center.x);
        for (int i = 0; i < 3; ++i)
        {
            //Debug.Log("x=" + points[i].x);
            //Debug.Log(Vector3.Distance(center, points[i]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
