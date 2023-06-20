using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex9_script : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float time = 1;
    [SerializeField] private Vector3 cur = new Vector3(15f, 0f, 15f);
    [SerializeField] private Vector3 tar = new Vector3(30f, 0f, 15f);

    private float speed;
    private float curtime;

    void Start()
    {
        speed = Vector3.Distance(cur, tar) / time;
        transform.position = cur;
        curtime = Time.time;
    }
    private bool flag = true;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, tar, speed * Time.deltaTime);
        if (flag && Mathf.Abs(Time.time - time) <= 1e-2)
        {
            if (Vector3.Distance(transform.position, tar) <= 1e-6)
            {
                //Debug.Log("Success");
            }
            else
            {
                //Debug.Log("Fail");
            }
            flag = false;
        }
    }
}
