using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class GameController : MonoBehaviour
{
    public Canvas UICanvas;
    public TMP_Text timerText;
    public string timerTooltip = "Time Remaining: ";
    public Scenes SceneManager;

    public TMP_Text scoreTextBox;
    public string scoreText;

    bool timerOn = false;
    float timeLimit = 30;
    float timeLeft = 30;
    int cardAmount = 16;
    int pairsFound = 0;
    float currentScore = 0;
    float scoreMultiplier = 1;
    
    public int columnLength;
    public int rowLength;
    public float xPadding = 100;
    public float yPadding = 125;

    public float xOffset;
    public float yOffset;
    public float xScale;
    public float yScale;

    public List<GameObject> CardPrefabs = new List<GameObject>();
    List<GameObject> CardList = new List<GameObject>();
    List<GameObject> CardObjects = new List<GameObject>();
    public static List<GameObject> SelectedCards = new List<GameObject>();

    public GameObject confetti;

    void Start()
    {
        CardList.Clear();
        CardObjects.Clear();
        SelectedCards.Clear();

        currentScore = 0;
        MapPreferences();
        timerOn = true;
        //UnityEngine.Debug.Log("Total cards: " + cardAmount);
        //UnityEngine.Debug.Log("Time limit: " + timeLimit);
        InstantiateCards();
    }

    void Update()
    {
        if(timerOn == true) TickTimer();
        VerifySelection();
        scoreTextBox.text = scoreText + currentScore;
    }

    void TickTimer()
    {
        if (timeLeft <= 0f)
        {
            SceneManager.LooseGame();
        }
        timeLeft -= Time.deltaTime;
        timerText.text = timerTooltip + Mathf.RoundToInt(timeLeft) + "s";
    }

    void VerifySelection()
    {
        if (SelectedCards.Count == 2 && SelectedCards[0] != null && SelectedCards[1] != null)
        {
            if (SelectedCards[0].GetComponent<CardController>().cardNumber == SelectedCards[1].GetComponent<CardController>().cardNumber)
            {
                //UnityEngine.Debug.Log("Pair found");
                pairsFound++;
                currentScore += (10 * scoreMultiplier);
            }
            else
            {
                StartCoroutine(HideCards(SelectedCards[0], SelectedCards[1]));
            }
            SelectedCards.Clear();
        }
        if (pairsFound == (cardAmount / 2)) StartCoroutine(WinGame());
    }

    void MapPreferences()
    {
        if(GlobalSettings.GetCardAmount() == 0)
        {
            cardAmount = 48;
            rowLength = 4;
            columnLength = 12;
            xOffset = -550;
            yOffset = -275f;
            xPadding = 100;
            yPadding = 150;
            xScale = 16;
            yScale = 16;
        }
        else if(GlobalSettings.GetCardAmount() == 1)
        {
            cardAmount = 32;
            rowLength = 4;
            columnLength = 8;
            xOffset = -450;
            yOffset = -350f;
            xPadding = 125;
            yPadding = 175;
            xScale = 20;
            yScale = 20;
        }
        else if(GlobalSettings.GetCardAmount() == 2)
        {
            cardAmount = 24;
            rowLength = 3;
            columnLength = 8;
            xOffset = -525;
            yOffset = -250f;
            xPadding = 150;
            yPadding = 200;
            xScale = 25;
            yScale = 25;
        }
        else if(GlobalSettings.GetCardAmount() == 3)
        {
            cardAmount = 16;
            rowLength = 2;
            columnLength = 8;
            xOffset = -650f;
            yOffset = -200f;
            xPadding = 180;
            yPadding = 250;
            xScale = 30;
            yScale = 30;
        }
        else if(GlobalSettings.GetCardAmount() == 4)
        {
            cardAmount = 8;
            rowLength = 2;
            columnLength = 4;
            xOffset = -275f;
            yOffset = -200f;
            xPadding = 180;
            yPadding = 250;
            xScale = 30;
            yScale = 30;
        }

        if(GlobalSettings.GetDifficulty() == 0)
        {
            timeLimit = 15;
            scoreMultiplier = 20f;
        }
        else if(GlobalSettings.GetDifficulty() == 1)
        {
            timeLimit = 30;
            scoreMultiplier = 15f;
        }
        else if(GlobalSettings.GetDifficulty() == 2)
        {
            timeLimit = 60;
            scoreMultiplier = 10f;
        }
        else if(GlobalSettings.GetDifficulty() == 3)
        {
            timeLimit = 120;
            scoreMultiplier = 5f;
        }
        else if(GlobalSettings.GetDifficulty() == 4)
        {
            timeLimit = 9999;
            scoreMultiplier = 1.5f;
        }
        timeLeft = timeLimit;
    }

    void InstantiateCards()
    {
        CardList.Clear();
        for(int i = 0; i < (cardAmount / 2); i++)
        {
            int randomCard = Random.Range(0, CardPrefabs.Count);
            //UnityEngine.Debug.Log("Card number generated: " + randomCard);
            CardList.Add(CardPrefabs[randomCard]);
            CardList.Add(CardPrefabs[randomCard]);
        }
        for(int i = 0; i < rowLength; i++)
        {
            for(int y = 0; y < columnLength; y++)
            {
                int randomCard = Random.Range(0, CardList.Count);
                GameObject newCard = Instantiate(CardList[randomCard], new UnityEngine.Vector2 (y * xPadding + xOffset, i * yPadding + yOffset), UnityEngine.Quaternion.identity);
                newCard.transform.parent = UICanvas.transform;
                newCard.transform.localScale = new UnityEngine.Vector3(xScale,-yScale,xScale);
                newCard.transform.localPosition = new UnityEngine.Vector3(y * xPadding + xOffset, i * yPadding + yOffset, 0f);
                CardObjects.Add(newCard);
                CardList.RemoveAt(randomCard);
            }
        }
    }

    public static void PassCardSelection(GameObject selection)
    {
        SelectedCards.Add(selection);
    }

    public IEnumerator HideCards(GameObject cardOne, GameObject cardTwo)
    {   
        yield return new WaitForSeconds(0.85f);
        cardOne.GetComponent<CardController>().HideCard();
        cardTwo.GetComponent<CardController>().HideCard();
        yield return new WaitForSeconds(0.85f);
        cardOne.GetComponent<Button>().interactable = true;
        cardTwo.GetComponent<Button>().interactable = true;
    }

    public IEnumerator WinGame()
    {
        timerOn = false;
        yield return new WaitForSeconds(0.5f);
        confetti.SetActive(true);
        yield return new WaitForSeconds(4f);
        GlobalSettings.SetLastGameScore(currentScore);
        SceneManager.WinGame();
    }
}