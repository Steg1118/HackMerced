using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CropButtons : MonoBehaviour
{
    public static GameObject tileWorkedOn;
    public GameObject CornPrefab;
    public GameObject WheatPrefab;
    public GameObject BeetPrefab;
    public GameObject BarleyPrefab;
    public GameObject SpinachPrefab;
    public GameObject OnionPrefab;
    //public GameObject Prefab;
    public TextMeshProUGUI InfoPanel;
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
        }
    }

    public void Wheat()
    {
        if(tileWorkedOn.transform.GetComponent<Tile>().CropHere == null)
        {
            GameManager.CropsPlanted.Add(1);
            GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 1;
            GameManager.MoneyHave -= 80;
            Tile.tileOptionUI.SetActive(false);
            tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(WheatPrefab, tileWorkedOn.transform.position + new Vector3(0,0.01f,0), transform.rotation);
        }
    }

    public void Beet()
    {
        if(tileWorkedOn.transform.GetComponent<Tile>().CropHere == null)
        {
            GameManager.CropsPlanted.Add(2);
            GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 2;
            GameManager.MoneyHave -= 95;
            Tile.tileOptionUI.SetActive(false);
            tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(BeetPrefab, tileWorkedOn.transform.position + new Vector3(0,0.01f,0), transform.rotation);
        }
    }


    public void Barley()
    {
        if(tileWorkedOn.transform.GetComponent<Tile>().CropHere == null)
        {
            GameManager.CropsPlanted.Add(3);
            GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 3;
            GameManager.MoneyHave -= 90;
            Tile.tileOptionUI.SetActive(false);
            tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(BarleyPrefab, tileWorkedOn.transform.position + new Vector3(0,0.01f,0), transform.rotation);
        }
    }

    public void Spinach()
    {
        if(tileWorkedOn.transform.GetComponent<Tile>().CropHere == null)
        {
            GameManager.CropsPlanted.Add(4);
            GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 4;
            GameManager.MoneyHave -= 95;
            Tile.tileOptionUI.SetActive(false);
            tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(SpinachPrefab, tileWorkedOn.transform.position + new Vector3(0,0.01f,0), transform.rotation);
        }
    }

    public void Onion()
    {
        if(tileWorkedOn.transform.GetComponent<Tile>().CropHere == null)
        {
            GameManager.CropsPlanted.Add(5);
            GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = 5;
            GameManager.MoneyHave -= 95;
            Tile.tileOptionUI.SetActive(false);
            tileWorkedOn.transform.GetComponent<Tile>().CropHere = Instantiate(OnionPrefab, tileWorkedOn.transform.position + new Vector3(0,0.01f,0), transform.rotation);
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
        }
        GameManager.CropBoard[tileWorkedOn.GetComponent<Tile>().row, tileWorkedOn.GetComponent<Tile>().collumn] = -1;
        Destroy(tileWorkedOn.GetComponent<Tile>().CropHere);
        tileWorkedOn.GetComponent<Tile>().CropHere = null;
        Tile.TileSellUI.SetActive(false);
    }

    public void InfoTile()
    {
        // switch(tileWorkedOn.GetComponent<Tile>().CropHere.tag)
        // {
        //     case "Corn":
        //         break;
        //     default:
        //         break;
        // }
        tileWorkedOn.GetComponent<Tile>().DisplayInfo(InfoPanel);
    }
}
