using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex10_script : MonoBehaviour
{
    [SerializeField] private Vector3 cur;
    [SerializeField] private Vector3 tar;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float Eps = (float)1e-6;

    private int dir;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = cur;
       
    }

    private float time = 0;
    bool flag = true;
    int tmp = 1;
    IEnumerator Solve()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, cur) <= Eps)
            {
                dir = 0;
            }
            else
            if (Vector3.Distance(transform.position, tar) <= Eps)
            {
                dir = 1;
            }
            if (dir == 0)
            { 
                transform.position = Vector3.MoveTowards(transform.position, tar, speed * Time.deltaTime);
                time = Time.time;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, cur, speed * Time.deltaTime);
                time = Time.time;
            }
            if (Vector3.Distance(transform.position, cur) <= Eps || Vector3.Distance(transform.position, tar) <= Eps)
            {
                int tmp = Random.Range(1, 3);
                //Debug.Log("tmp = " + tmp);
                yield return new WaitForSeconds(tmp);
            }
            yield return null;
        }   
    }
    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            flag = false;
            StartCoroutine(Solve());
        }
        if (Time.time >= tmp)
        {
            //Debug.Log("" + transform.position.x + ' ' + Time.time + ' ' + tmp);
            ++tmp;
        }
    }
}
