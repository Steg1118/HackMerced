using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public static GameObject tileOptionPrefab;
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
        
    }

    private void TileOptions()
    {
        float distanceFromCamera = 8f;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = distanceFromCamera;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log("Works.");
        //Instansiate(tileOptionPrefab, worldPosition, transform.rotation);
    }
}
