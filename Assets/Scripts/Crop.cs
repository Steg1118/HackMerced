using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public float minusN_Nitrogen;
    public float minusP_Phosphorus;
    public float minusK_Potassium;
    public int growTime;
    public float highTemp;
    public float lowTemp;
    public float highHum;
    public float lowHum;
    //Tile tilescript;
    // Start is called before the first frame update
    void Start()
    {
        //tilescript = FindObjectOfType<Tile>();
        // switch(gameObject.tag)
        // {
        //     case("Corn"):
        //         GameManager.CropsPlanted.Add(0);
        //         break;
        // }
    }

    void OnDestroy()
    {
        //switch
    }

    // void OnMouseOver()
    // {
    //     if(Input.GetMouseButtonDown(0) && !TileSellUI.activeSelf && CropHere != null)
    //     {
    //         SellOpt();
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
