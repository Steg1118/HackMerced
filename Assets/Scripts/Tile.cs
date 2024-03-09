using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public static GameObject tileOptionUI;
    private GameObject CropHere;
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(CropHere == null)
                TileOptions();
            else
                SellTile();
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

    private void SellTile()
    {
        //switch(CropHere.tag)
        CropHere = null;
    }

    private void TileOptions()
    {
        tileOptionUI.SetActive(true);
        //float distanceFromCamera = 8f;
        Vector3 mousePos = Input.mousePosition + new Vector3(50, -15, 0);
        tileOptionUI.transform.position = mousePos;
        //mousePos.z = distanceFromCamera;
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log("Works.");    
    }
}
