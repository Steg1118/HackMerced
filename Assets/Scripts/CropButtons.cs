using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CropButtons : MonoBehaviour
{
    public static GameObject tileWorkedOn;
    public GameObject[] CropPrefabs;
    public TextMeshProUGUI InfoPanel;

    public void PlantCrop(string crop)
    {
        if(tileWorkedOn.transform.GetComponent<Tile>().CropHere == null)
        {
            switch(crop)
        {
            case "Corn":
                GameManager.MoneyHave -= 120;
                GameManager.CropsPlanted.Add(0);
                tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(CropPrefabs[0], tileWorkedOn.transform.position + new Vector3(0,0.01f,0), CropPrefabs[0].transform.rotation);
                GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 0;
                break;
            case "Wheat":
                GameManager.MoneyHave -= 80;
                GameManager.CropsPlanted.Add(1);
                tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(CropPrefabs[1], tileWorkedOn.transform.position + new Vector3(0,0.01f,0), CropPrefabs[1].transform.rotation);
                GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 1;
                break;
            case "Beet":
                GameManager.MoneyHave -= 95;
                GameManager.CropsPlanted.Add(2);
                tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(CropPrefabs[2], tileWorkedOn.transform.position + new Vector3(0,0.01f,0), CropPrefabs[2].transform.rotation);
                GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 2;
                break;
            case "Barley":
                GameManager.MoneyHave -= 90;
                GameManager.CropsPlanted.Add(3);
                tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(CropPrefabs[3], tileWorkedOn.transform.position + new Vector3(0,0.01f,0), CropPrefabs[3].transform.rotation);
                GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 3;
                break;
            case "Spinach":
                GameManager.MoneyHave -= 95;
                GameManager.CropsPlanted.Add(4);
                tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(CropPrefabs[4], tileWorkedOn.transform.position + new Vector3(0,0.01f,0), CropPrefabs[4].transform.rotation);
                GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 4;
                break;
            case "Onion":
                GameManager.MoneyHave -= 95;
                GameManager.CropsPlanted.Add(5);
                tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(CropPrefabs[5], tileWorkedOn.transform.position + new Vector3(0,0.01f,0), CropPrefabs[5].transform.rotation);
                GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 5;
                break;
            case "Rice":
                GameManager.MoneyHave -= 110;
                GameManager.CropsPlanted.Add(6);
                tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(CropPrefabs[6], tileWorkedOn.transform.position + new Vector3(0,0.01f,0), CropPrefabs[6].transform.rotation);
                GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 6;
                break;
            case "Green Bean":
                GameManager.MoneyHave -= 95;
                GameManager.CropsPlanted.Add(7);
                tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(CropPrefabs[7], tileWorkedOn.transform.position + new Vector3(0,0.01f,0), CropPrefabs[7].transform.rotation);
                GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 7;
                break;
            case "Garlic":
                GameManager.MoneyHave -= 100;
                GameManager.CropsPlanted.Add(8);
                tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(CropPrefabs[8], tileWorkedOn.transform.position + new Vector3(0,0.01f,0), CropPrefabs[8].transform.rotation);
                GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 8;
                break;
        }
            Tile.tileOptionUI.SetActive(false);
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
            case "Wheat":
                GameManager.MoneyHave += 80;
                GameManager.CropsPlanted.Remove(1);
                break;
            case "Beet":
                GameManager.MoneyHave += 95;
                GameManager.CropsPlanted.Remove(2);
                break;
            case "Barley":
                GameManager.MoneyHave += 90;
                GameManager.CropsPlanted.Remove(3);
                break;
            case "Spinach":
                GameManager.MoneyHave += 95;
                GameManager.CropsPlanted.Remove(4);
                break;
            case "Onion":
                GameManager.MoneyHave += 95;
                GameManager.CropsPlanted.Remove(5);
                break;
            case "Rice":
                GameManager.MoneyHave += 110;
                GameManager.CropsPlanted.Remove(6);
                break;
            case "Green Bean":
                GameManager.MoneyHave += 95;
                GameManager.CropsPlanted.Remove(7);
                break;
            case "Garlic":
                GameManager.MoneyHave += 100;
                GameManager.CropsPlanted.Remove(8);
                break;
        }
        GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = -1;
        Destroy(tileWorkedOn.GetComponent<Tile>().CropHere);
        tileWorkedOn.GetComponent<Tile>().CropHere = null;
        Tile.TileSellUI.SetActive(false);
    }

    public void InfoTile()
    {
        tileWorkedOn.GetComponent<Tile>().DisplayInfo(InfoPanel);
    }
}
