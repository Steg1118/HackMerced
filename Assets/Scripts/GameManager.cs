using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TempCnF;
    public TextMeshProUGUI Season;
    public TextMeshProUGUI Humity;
    public TextMeshProUGUI Money;
    public static int MoneyHave;
    public static float TempartureC;
    public static float TempartureF;
    public static float theHumitiy;
    public static int theSeason; // 0 = spring, 1 = summer, 2 = fall, 3 = winter
    // Start is called before the first frame update
    void Start()
    {
        theHumitiy = Mathf.Round((int) (10 * Random.Range(65, 95))) / 10f;
        TempartureF = Mathf.Round((int) (10 * Random.Range(65, 95))) / 10f;
        TempartureC = Mathf.Round((TempartureF - 32) * 50/9) / 10;
        theSeason = (int) Random.Range(1, 4);
        MoneyHave = 5000;
    }

    // Update is called once per frame
    void Update()
    {
        Money.text = "Money: " + MoneyHave;
        Season.text = "Season: " + theSeason;
        Humity.text = "Humidity: " + theHumitiy; //low = 70 med = 80  high = 90
        TempCnF.text = "Temp: " + TempartureC + "*C " + TempartureF + "*F";
    }

    public void PlayGameButton()
    {
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        //Tranistion to next day
        yield return new WaitForSeconds(0.01f);
    }
}
