using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector2 bounds;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mousePosition.x > ((11 * Screen.width) / 24) && transform.position.x < bounds.x)
        {
            transform.position += new Vector3(speed * Time.deltaTime,0,0);
            //SelectionObj.intialPos += new Vector3(speed * Time.deltaTime,0,0);
        }
        else if(Input.mousePosition.x < ((1 * Screen.width) / 24) && transform.position.x > -bounds.x)
        {
            transform.position += new Vector3(-speed * Time.deltaTime,0,0);
            //SelectionObj.intialPos += new Vector3(-speed * Time.deltaTime,0,0);
        }
        if(Input.mousePosition.y > ((7 * Screen.height) / 16) && transform.position.z < bounds.y)
        {
            transform.position += new Vector3(0,0,speed * Time.deltaTime);
            //SelectionObj.intialPos += new Vector3(0,0,speed * Time.deltaTime);
        }
        else if(Input.mousePosition.y <  ((1 * Screen.height) / 16) && transform.position.z > -bounds.y)
        {
            transform.position += new Vector3(0,0,-speed * Time.deltaTime);
            //SelectionObj.intialPos += new Vector3(0,0,-speed * Time.deltaTime);
        }
    }
}

