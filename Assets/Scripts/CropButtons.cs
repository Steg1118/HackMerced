using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropButtons : MonoBehaviour
{
    public static GameObject tileWorkedOn;
    public GameObject CornPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Corn()
    {
        if(tileWorkedOn.transform.GetComponent<Tile>().CropHere == null)
        {
            GameManager.CropsPlanted.Add(0);
            GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 0;
            GameManager.MoneyHave -= 120;
            Tile.tileOptionUI.SetActive(false);
            tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(CornPrefab, tileWorkedOn.transform.position + new Vector3(0,0.01f,0), transform.rotation);
            //Debug.Log("Works.");
        }
    }


    public void SellTile()
    {
        switch(tileWorkedOn.GetComponent<Tile>().CropHere.tag)
        {
            case "Corn":
                GameManager.MoneyHave += 120;
                GameManager.CropsPlanted.Remove(0);
                break;
        }
        GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = -1;
        Destroy(tileWorkedOn.GetComponent<Tile>().CropHere);
        tileWorkedOn.GetComponent<Tile>().CropHere = null;
        Tile.TileSellUI.SetActive(false);
    }

    public void InfoTile()
    {
        switch(tileWorkedOn.GetComponent<Tile>().CropHere.tag)
        {
            case "Corn":
                break;
            default:
                break;
        }
        tileWorkedOn.GetComponent<Tile>().DisplayInfo();
    }
}
