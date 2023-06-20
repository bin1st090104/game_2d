using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exercise1 : MonoBehaviour
{
    // Start is called before the first frame update
    //void Back()
    //{
    //    Vector3 transRevVector = new Vector3(-13f, -15f, -17f);
    //    transform.Translate(transVector);
    //}
    //void Work()
    //{
    //    while (true)
    //    {
    //        Vector3 transVector = new Vector3(13f, 15f, 17f);
    //        transform.Translate(transVector);
    //        Invo
    //    }
    //}
    void Start()
    {
        Time.fixedDeltaTime = 1;
    }


    // Update is called once per frame
    float speed = 0.05f;
    Vector3 mid = Vector3.Lerp(new Vector3(0f, 0f, 0f), new Vector3(20f, 0f, 0f), 0.5f);
    void Update()
    {
       // Debug.Log(1e-1);
        if(Mathf.Abs(Vector3.Distance(new Vector3(0f,0f,0f),transform.position)+Vector3.Distance(transform.position,mid)-Vector3.Distance(new Vector3(0f, 0f, 0f), mid)) < 1e-6)
        {
            speed += 0.05f;
        }
        else
        {
            speed -= 0.05f;
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(20f, 0f, 0f), speed * Time.deltaTime);
        //Debug.Log("" + speed + transform.position.x + ' ' + transform.position.y + ' ' + transform.position.z);    
        return;
    }
    void FixedUpdate()
    {
    
    }
}
