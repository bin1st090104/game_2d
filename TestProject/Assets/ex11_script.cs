using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex11_script : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layerMask;
    public Color[] color;
    private int curColor = 0;
    private Renderer objectRenderer;
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.Log("Fail");
        }
        else
        {
            Debug.Log("Succeed");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            //Debug.Log("--   " + mousePosition.x + "   " + mousePosition.y + "   " + mousePosition.z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //GameObject go = GameObject.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));
            //go.transform.position = worldPosition;

            //Debug.Log("++   " + worldPosition.x + "   " + worldPosition.y + "   " + worldPosition.z);
            if(Physics.Raycast(worldPosition,new Vector3(0, 0, 1), layerMask.value))
            {
                Debug.Log("hit");
                //Material. = Color[curColor^=1];
                objectRenderer.material.color = color[curColor ^= 1];
            }
            else
            {
                Debug.Log("not hit");
            }
        }
    }
}
