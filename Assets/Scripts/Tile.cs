using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tile : MonoBehaviour
{
    public static GameObject tileOptionUI;
    public static GameObject TileSellUI;
    public int row;
    public int collumn;
    public int soilQuality = 4;
    public GameObject CropHere;
    public GameObject OldCropHere;
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
        GameManager.Board[row, collumn] = this.gameObject;
        if(CropButtons.tileWorkedOn == null)
        {
            //set info text to null
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //set info text to null
            tileOptionUI.SetActive(false);
            TileSellUI.SetActive(false);
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

    public void DisplayInfo(TextMeshProUGUI a)
    {
        string temp; 
        //display information on this tile
        if(CropHere != null)
        {
            temp = "Crop here: ";
            switch(CropHere.tag)
            {
                case "Corn":
                temp += "Corn\n";
                    break;
                default:
                    break;
            }
        }
        else
        {
            temp = "Crop here: None\n";
        }
        temp += "Soil Quality: " + (soilQuality / 4) + "\n";
        a.text = temp;

    }
}
