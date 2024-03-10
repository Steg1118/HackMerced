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
    public static List<int> CropsPlanted = new List<int>(); // 0 = corn, 1 = wheat, 2 = beet, 3 = barley, 4 = Spinach, 5 = Onion, 6 = Rice, 7 = Green Bean, 8 = Garlic 
    public static int[,] CropBoard = new int[8, 8]; //0 = corn
    public static GameObject[,] Board = new GameObject[8,8]; 
    public static int MonoScore;
    public GameObject ScoreScreen;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI WhyScoreText;
    int numCorn;
    int numWheat;
    int numBeet;
    int numBarley;
    int numSpinach;
    int numOnion;
    int numRice;
    int numGreen;
    int numGarlic;
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
        TempCnF.text = "Temp: " + TempartureC + "°C " + TempartureF + "°F";
    }

    public void PlayGameButton()
    {
        if(MoneyHave >= 0)
        {
            StartCoroutine(Transition());
            CalculateScore();
            MakeMonoScore();
        }
    }

    private void CalculateScore()
    {
        numCorn = 0;
        numWheat = 0;
        numBeet = 0;
        numBarley = 0;
        numSpinach = 0;
        numOnion = 0;
        numRice = 0;
        numGreen = 0;
        numGarlic = 0;

        for(int r = 0; r < 8; r++)
        {
        for(int c = 0; c < 8; c++)
        {
            int a = CropBoard[r, c];
            if(a == 0)
            {
                numCorn++;
            }
            else if(a == 1)
            {
                numWheat++;
            }
            else if(a == 2)
            {
                numBeet++;
            }
            else if(a == 3)
            {
                numBarley++;
            }
            else if(a == 4)
            {
                numSpinach++;
            }
            else if(a == 5)
            {
                numOnion++;
            }
            else if(a == 6)
            {
                numRice++;
            }
            else if(a == 7)
            {
                numGreen++;
            }
            else if(a == 8)
            {
                numGarlic++;
            }
            //CropsPlanted.Remove(a);
        }
        }


        switch(theSeason)
        {
            case 1://destroy non spring crops
                numOnion = 0;
                numGreen = 0;
                numGarlic = 0;
                break;
            case 2://destroy non summer crops
                numCorn = 0;
                numWheat = 0;
                numBarley = 0;
                numOnion = 0;
                numRice = 0;
                numGarlic = 0;
                break;
            case 3://destroy non fall crops
                numCorn = 0;
                numBeet = 0;
                numSpinach = 0;
                numRice = 0;
                numGreen = 0;
                break;
            case 4://destroy non winter crops
                numCorn = 0;
                numWheat = 0;
                numBeet = 0;
                numBarley = 0;
                numGreen = 0;
                numRice = 0;
                numGarlic = 0;
                break; 
        }

        if(TempartureF > 95 - 18)
        {
            if(theHumitiy > 85)
            {
                MoneyHave += 180 * numCorn;
                MoneyHave += 10 * numWheat;
                MoneyHave += 10 * numBeet;
                MoneyHave += 10 * numBarley;
                MoneyHave += 10 * numSpinach;
                MoneyHave += 0 * numOnion;
                MoneyHave += 160 * numRice;
                MoneyHave += 10 * numGreen;
                MoneyHave += 0 * numGarlic;
            }
            else if(theHumitiy > 75)
            {
                MoneyHave += 180 * numCorn;
                MoneyHave += 46 * numWheat;
                MoneyHave += 46 * numBeet;
                MoneyHave += 43 * numBarley;
                MoneyHave += 46 * numSpinach;
                MoneyHave += 10 * numOnion;
                MoneyHave += 53 * numRice;
                MoneyHave += 46 * numGreen;
                MoneyHave += 10 * numGarlic;
            }
            else
            {
                MoneyHave += 60 * numCorn;
                MoneyHave += 46 * numWheat;
                MoneyHave += 46 * numBeet;
                MoneyHave += 43 * numBarley;
                MoneyHave += 10 * numSpinach;
                MoneyHave += 0 * numOnion;
                MoneyHave += 53 * numRice;
                MoneyHave += 10 * numGreen;
                MoneyHave += 0 * numGarlic;
            }
        }
        else if(TempartureF > 95 - 36)
        {
            if(theHumitiy > 85)
            {
                MoneyHave += 180 * numCorn;
                MoneyHave += 140 * numWheat;
                MoneyHave += 46 * numBeet;
                MoneyHave += 43 * numBarley;
                MoneyHave += 46 * numSpinach;
                MoneyHave += 10 * numOnion;
                MoneyHave += 160 * numRice;
                MoneyHave += 46 * numGreen;
                MoneyHave += 10 * numGarlic;
            }
            else if(theHumitiy > 75)
            {
                MoneyHave += 180 * numCorn;
                MoneyHave += 140 * numWheat;
                MoneyHave += 140 * numBeet;
                MoneyHave += 130 * numBarley;
                MoneyHave += 140 * numSpinach;
                MoneyHave += 43 * numOnion;
                MoneyHave += 53 * numRice;
                MoneyHave += 140 * numGreen;
                MoneyHave += 50 * numGarlic;
            }
            else
            {
                MoneyHave += 60 * numCorn;
                MoneyHave += 140 * numWheat;
                MoneyHave += 140 * numBeet;
                MoneyHave += 130 * numBarley;
                MoneyHave += 46 * numSpinach;
                MoneyHave += 10 * numOnion;
                MoneyHave += 53 * numRice;
                MoneyHave += 46 * numGreen;
                MoneyHave += 10 * numGarlic;
            }
        }
        else
        {
            if(theHumitiy > 85)
            {
                MoneyHave += 60 * numCorn;
                MoneyHave += 140 * numWheat;
                MoneyHave += 46 * numBeet;
                MoneyHave += 43 * numBarley;
                MoneyHave += 46 * numSpinach;
                MoneyHave += 43 * numOnion;
                MoneyHave += 53 * numRice;
                MoneyHave += 10 * numGreen;
                MoneyHave += 50 * numGarlic;
            }
            else if(theHumitiy > 75)
            {
                MoneyHave += 60 * numCorn;
                MoneyHave += 140 * numWheat;
                MoneyHave += 140 * numBeet;
                MoneyHave += 130 * numBarley;
                MoneyHave += 140 * numSpinach;
                MoneyHave += 130 * numOnion;
                MoneyHave += 10 * numRice;
                MoneyHave += 46 * numGreen;
                MoneyHave += 150 * numGarlic;
            }
            else
            {
                MoneyHave += 10 * numCorn;
                MoneyHave += 140 * numWheat;
                MoneyHave += 140 * numBeet;
                MoneyHave += 130 * numBarley;
                MoneyHave += 46 * numSpinach;
                MoneyHave += 43 * numOnion;
                MoneyHave += 10 * numRice;
                MoneyHave += 10 * numGreen;
                MoneyHave += 50 * numGarlic;
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
                if(r-1 >= 0 && CropBoard[r,c] == CropBoard[r-1,c])
                {
                    MonoScore++;
                }
                if(c+1 < 8 && CropBoard[r,c] == CropBoard[r,c+1])
                {
                    MonoScore++;
                }
                if(c-1 >= 0 && CropBoard[r,c] == CropBoard[r,c-1])
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
                if(Board[r, c] != null)
                {
                    Board[r, c].GetComponent<Tile>().OldCropHere = Board[r, c].GetComponent<Tile>().CropHere;
                    Destroy(Board[r, c].GetComponent<Tile>().CropHere);
                    Board[r, c].GetComponent<Tile>().CropHere = null;
                    CropBoard[r, c] = -1;
                }
            }
        }
    }

    private IEnumerator Transition()
    {
        ScoreScreen.SetActive(true);
        ScoreScreen.GetComponent<Image>().color = new Color(ScoreScreen.GetComponent<Image>().color.r, ScoreScreen.GetComponent<Image>().color.b, ScoreScreen.GetComponent<Image>().color.g, 0);
        yield return new WaitForSeconds(0.01f);
        WhyScoreText.text = "You have harvested: " + numCorn + " Corn,\n";
        WhyScoreText.text += "You have harvested: " + numWheat + " Wheat,\n";
        WhyScoreText.text += "You have harvested: " + numBeet + " Beet,\n";
        WhyScoreText.text += "You have harvested: " + numBarley + " Barley,\n";
        WhyScoreText.text += "You have harvested: " + numSpinach + " Spinach,\n";
        WhyScoreText.text += "You have harvested: " + numOnion + " Onion,\n";
        WhyScoreText.text += "You have harvested: " + numGreen + " Green Beans,\n";
        WhyScoreText.text += "You have harvested: " + numGarlic + " Garlic.\n";
        /*
        int numCorn;
    int numWheat;
    int numBeet;
    int numBarley;
    int numSpinach;
    int numOnion;
    int numRice;
    int numGreen;
    int numGarlic;
        */
        ScoreText.text = "Current Money: " + MoneyHave;
        //Tranistion to next day
        for(int i = 0; i < 100; i+=2)
        {
            ScoreScreen.GetComponent<Image>().color += new Color(0, 0, 0, 0.02f);
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
        for(int i = 0; i < 100; i+=2)
        {
            ScoreScreen.GetComponent<Image>().color -= new Color(0, 0, 0, 0.02f);
            yield return new WaitForSeconds(0.01f);
        }
        ScoreScreen.SetActive(false);
    }
}
