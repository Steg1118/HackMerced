using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject tileOptionUI;
    private GameObject CropHere;
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TileOptions();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            tileOptionUI.SetActive(false);
        }
    }

    private void TileOptions()
    {
        tileOptionUI.SetActive(true);
        //float distanceFromCamera = 8f;
        Vector3 mousePos = Input.mousePosition;
        tileOptionUI.transform.position = mousePos;
        //mousePos.z = distanceFromCamera;
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log("Works.");    
    }
}
