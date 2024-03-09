using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch(gameObject.tag)
        {
            case("Corn"):
                GameManager.CropsPlanted.Add(0);
                break;
        }
    }

    void OnDestroy()
    {
        //switch
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
