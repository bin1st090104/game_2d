using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Time.fixedDeltaTime = 3;
    }

    // Update is called once per frame
    [SerializeField] private float t = 0;
    void Update()
    {
        t += 2 * Time.deltaTime; 
        transform.position = new Vector3(15 * Mathf.Sin(t / 2), transform.position.y, 6 * t);
    }
    private void FixedUpdate()
    {
        //transform.Translate(5f, 5f, 5f);
    }
}
