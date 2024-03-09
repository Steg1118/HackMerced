using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public static GameObject tileOptionUI;
    public static GameObject TileSellUI;
    public GameObject CropHere;
    //add soil stats
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && !tileOptionUI.activeSelf && !TileSellUI.activeSelf && CropHere == null)
        {
            TileOptions();
        }
        else if(Input.GetMouseButtonDown(0) && !TileSellUI.activeSelf && !tileOptionUI.activeSelf && CropHere != null)
        {
            SellOpt();
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

    private void SellOpt()
    {
        TileSellUI.SetActive(true);
        Vector3 mousePos = Input.mousePosition + new Vector3(50, -15, 0);
        TileSellUI.transform.position = mousePos;
        CropButtons.tileWorkedOn = gameObject;
    }

    private void TileOptions()
    {
        tileOptionUI.SetActive(true);
        Vector3 mousePos = Input.mousePosition + new Vector3(50, -15, 0);
        tileOptionUI.transform.position = mousePos;
        CropButtons.tileWorkedOn = gameObject;

    }

    public void DisplayInfo()
    {

    }
}
