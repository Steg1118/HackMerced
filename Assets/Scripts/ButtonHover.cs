using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool IsThisHovered = false;
    public static List<GameObject> Objs = new List<GameObject>();
    // Start is called before the first frame update
    // public static void Update()
    // {
    //     Tile.HoveredAButton = false;
    //     foreach(GameObject a in Objs)
    //     {
    //         if(a.GetComponent<ButtonHover>().IsThisHovered )
    //         {
    //             Tile.HoveredAButton = true;
    //         }
    //     }
    // }

    void Awake()
    {
        Objs.Add(this.gameObject);
    }

    void OnEnable()
    {
        Objs.Add(this.gameObject);
    }

    // Update is called once per frame
    public void OnPointerEnter(PointerEventData eventData)
    {
        IsThisHovered = true;
    }
    

    public void OnPointerExit(PointerEventData eventData)
    {
        IsThisHovered = false;
        Tile.HoveredAButton = false;
        foreach(GameObject a in Objs)
        {
            Debug.Log(a.GetComponent<ButtonHover>().IsThisHovered);
            if(a.GetComponent<ButtonHover>().IsThisHovered)
            {
                Tile.HoveredAButton = true;
                Debug.Log(Tile.HoveredAButton);
            }
        }
    }
}
