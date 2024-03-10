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
    public GameObject ImageCrop;
    public float N_NitrogenValue;
    public float P_PhosphorusValue;
    public float K_PotassiumValue;
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
        ImageCrop = GameObject.Find("CropImage");
        GameManager.Board[row, collumn] = this.gameObject;
        Debug.Log(GameManager.Board[row, collumn]);
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
        //ImageCrop
        if(CropHere != null)
        {
            temp = "Crop here: " + CropHere.tag + "\n";
            //ImageCrop.GetComponent<Image>().sprite = (Typeof sprite)CropHere.GetComponent<Renderer>().material;
            ImageCrop.GetComponent<Image>().material = CropHere.GetComponent<Renderer>().material;
        }
        else
        {
            temp = "Crop here: None\n";
            ImageCrop.GetComponent<Image>().sprite = null;
            ImageCrop.GetComponent<Image>().material = null;
        }
        temp += "Nitrogen: " + ((double)soilQuality / 4) + "\n";
        temp += "Phosperous: " + ((double)soilQuality / 4) + "\n";
        temp += "Potasism: " + ((double)soilQuality / 4) + "\n";
        a.text = temp;

    }
}
