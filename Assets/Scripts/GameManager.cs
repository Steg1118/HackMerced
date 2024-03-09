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
    public static List<int> CropsPlanted = new List<int>(); // 0 = corn
    public static int[,] CropBoard = new int[8, 8]; //0 = corn
    public static GameObject[,] Board = new GameObject[8,8]; 
    public static int MonoScore;
    public GameObject ScoreScreen;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI WhyScoreText;
    //private double chainLvl = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Board = GameObject.FindGameObjectsWithTag("Tile");
        theHumitiy = Mathf.Round((int) (10 * Random.Range(65, 95))) / 10f;
        TempartureF = Mathf.Round((int) (10 * Random.Range(40, 95))) / 10f;
        TempartureC = Mathf.Round((TempartureF - 32) * 50/9) / 10;
        theSeason = (int) Random.Range(1, 5);
        MoneyHave = 1000;
        Tile.tileOptionUI = GameObject.Find("TileOptUI");
        Tile.tileOptionUI.SetActive(false);
        Tile.TileSellUI = GameObject.Find("TileSellUI");
        Tile.TileSellUI.SetActive(false);
        ScoreScreen.SetActive(false);
        for(int r = 0; r < 8; r++)
        {
            for(int c = 0; c < 8; c++)//276 combinations checked
            {
                CropBoard[r, c] = -1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Money.text = "Money: " + MoneyHave;
        switch(theSeason)
        {
            case 1:
                Season.text = "Season: Spring";
                break;
            case 2:
                Season.text = "Season: Summer";
                break;
            case 3:
                Season.text = "Season: Fall";
                break;
            case 4:
                Season.text = "Season: Winter";
                break;
        }
        Humity.text = "Humidity: " + theHumitiy; //low = 70 med = 80  high = 90
        TempCnF.text = "Temp: " + TempartureC + "*C " + TempartureF + "*F";
    }

    public void PlayGameButton()
    {
        StartCoroutine(Transition());
        CalculateScore();
        MakeMonoScore();
    }

    private void CalculateScore()
    {
        int numCorn = 0;
        foreach(int a in CropsPlanted)
        {
            if(a == 0)
            {
                numCorn++;
            }
            else if(a == 1)
            {

            }
        }

        switch(theSeason)
        {
            case 1://destroy non spring crops

                break;
            case 2://destroy non summer crops
                numCorn = 0;
                break;
            case 3://destroy non fall crops
                numCorn = 0;
                break;
            case 4://destroy non winter crops
                numCorn = 0;
                break; 
        }

        if(TempartureF > 95 - 18)
        {
            if(theHumitiy > 85)
            {
                MoneyHave += 180 * numCorn;
            }
            else if(theHumitiy > 75)
            {
                MoneyHave += 180 * numCorn;
            }
            else
            {
                MoneyHave += 60 * numCorn;
            }
        }
        else if(TempartureF > 95 - 36)
        {
            if(theHumitiy > 85)
            {
                MoneyHave += 180 * numCorn;
            }
            else if(theHumitiy > 75)
            {
                MoneyHave += 180 * numCorn;
            }
            else
            {
                MoneyHave += 60 * numCorn;
            }
        }
        else
        {
            if(theHumitiy > 85)
            {
                MoneyHave += 60 * numCorn;
            }
            else if(theHumitiy > 75)
            {
                MoneyHave += 60 * numCorn;
            }
            else
            {
                MoneyHave += 10 * numCorn;
            }
        }
    }

    private void MakeMonoScore()
    {
        MonoScore = 0;
        int preScore = 0;
        for(int r = 0; r < 8; r++)
        {
            for(int c = 0; c < 8; c++)//276 combinations checked
            {
                preScore = MonoScore;
                if(CropBoard[r,c] != -1)
                {
                if(r+1 < 8 && CropBoard[r,c] == CropBoard[r+1,c])
                {
                    MonoScore++;
                }
                if(r-1 > 0 && CropBoard[r,c] == CropBoard[r-1,c])
                {
                    MonoScore++;
                }
                if(c+1 < 8 && CropBoard[r,c] == CropBoard[r,c+1])
                {
                    MonoScore++;
                }
                if(c-1 > 0 && CropBoard[r,c] == CropBoard[r,c-1])
                {
                    MonoScore++;
                }
                }
                //Debug.Log(Board[r, c]);
                Board[r, c].GetComponent<Tile>().soilQuality -= (int)(MonoScore - preScore);
                if(Board[r, c].GetComponent<Tile>().soilQuality <= 0)
                {
                    Destroy(Board[r, c]);
                }
                else
                {
                    // Destroy(Board[r, c].GetComponent<Tile>().CropHere);
                    //Board[r, c].GetComponent<Tile>().CropHere = null;
                }
            }
        }
        for(int r = 0; r < 8; r++)
        {
            for(int c = 0; c < 8; c++)//276 combinations checked
            {
                Board[r, c].GetComponent<Tile>().OldCropHere = Board[r, c].GetComponent<Tile>().CropHere;
                Destroy(Board[r, c].GetComponent<Tile>().CropHere);
                Board[r, c].GetComponent<Tile>().CropHere = null;
                CropBoard[r, c] = -1;
            }
        }
    }

    private IEnumerator Transition()
    {
        ScoreScreen.SetActive(true);
        ScoreScreen.GetComponent<Image>().color = new Color(ScoreScreen.GetComponent<Image>().color.r, ScoreScreen.GetComponent<Image>().color.b, ScoreScreen.GetComponent<Image>().color.g, 0);
        yield return new WaitForSeconds(0.01f);
        WhyScoreText.text = "You have planted " + 0 + " Corn.";
        ScoreText.text = "Current Money: " + MoneyHave;
        //Tranistion to next day
        for(int i = 0; i < 100; i++)
        {
            ScoreScreen.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        theHumitiy = Mathf.Round((int) (10 * Random.Range(65, 95))) / 10f;
        TempartureF = Mathf.Round((int) (10 * Random.Range(40, 95))) / 10f;
        TempartureC = Mathf.Round((TempartureF - 32) * 50/9) / 10;
        theSeason++;
        if(theSeason > 4)
        {
            theSeason = 1;
        }

        yield return new WaitUntil(() => Input.anyKeyDown);

        ScoreScreen.SetActive(false);
    }
}
