using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public float minusN_Nitrogen;
    public float minusP_Phosphorus;
    public float minusK_Potassium;
    Tile tilescript;
    // Start is called before the first frame update
    void Start()
    {
        tilescript = FindObjectOfType<Tile>();
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
    public void removeNPKValues()
    {
        tilescript.N_NitrogenValue -= minusN_Nitrogen;
        tilescript.K_PotassiumValue -= minusK_Potassium;
        tilescript.P_PhosphorusValue -= minusP_Phosphorus;
    }
}
