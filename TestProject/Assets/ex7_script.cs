using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex7_script : MonoBehaviour
{
    private Vector3[] points = new Vector3[3];

    // Start is called before the first frame update
    private Vector3 RandomVector3()
    {
        return new Vector3(Random.Range(-10f, 10f), 0f, 0f);
    }

    private Vector3 Destination;

    void Start()
    {
        for(int i = 0; i < 3; ++i)
        {
            points[i] = RandomVector3();
        }
        Destination = points[Random.Range(0, 3)];
    }

    // Update is called once per frame
    void Update()
    {
        while (Vector3.Distance(transform.position, Destination) < 1e-6)
        {
            Destination = points[Random.Range(0, 3)];
        }
        transform.position = Vector3.MoveTowards(transform.position, Destination, 8f * Time.deltaTime);
    }
}
