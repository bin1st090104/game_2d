using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_4_direct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0.1f;
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = 0;
        float moveZ = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(moveX, moveY, moveZ) * speed);
    }
}
