using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosMNG : MonoBehaviour
{
    public PlaySceneMNG prMNG;
    public Button chocolatePlus;
    public Button chocolateMinus;

    public Button alcoholPlus;
    public Button alcoholMinus;

    public Button freshFoodPlus;
    public Button freshFoodMinus;

    public Button snackPlus;
    public Button snackMinus;

    public Button cigarettePlus;
    public Button cigaretteMinus;

    public Button candyPlus;
    public Button candyMinus;

    public Text chocolateCount;
    public Text alcoholCount;
    public Text freshFoodCount;
    public Text snackCount;
    public Text cigaretteCount;
    public Text candyCount;

    public int choCount = 0;
    public int alcCount = 0;
    public int freshCount = 0;
    public int snaCount = 0;
    public int cigaCount = 0;
    public int canCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChoPlusBTN()
    {
        choCount++;
        chocolateCount.text = choCount.ToString();
    }

    public void ChoMinusBTN()
    {
        choCount--;
        if(choCount < 0)
        {
            choCount = 0;
        }
        chocolateCount.text = choCount.ToString();
    }

    public void AlcPlusBTN()
    {
        alcCount++;
        alcoholCount.text = alcCount.ToString();
    }
    public void AlcMinusBTN()
    {
        alcCount--;
        if (alcCount < 0)
        {
            alcCount = 0;
        }
        alcoholCount.text = alcCount.ToString();
    }

    public void FreshPlusBTN()
    {
        freshCount++;
        freshFoodCount.text = freshCount.ToString();
    }
    public void FreshMinusBTN()
    {
        freshCount--;
        if (freshCount < 0)
        {
            freshCount = 0;
        }
        freshFoodCount.text = freshCount.ToString();
    }

    public void SnaPlusBTN()
    {
        snaCount++;
        snackCount.text = snaCount.ToString();
    }
    public void SnaMinusBTN()
    {
        snaCount--;
        if (snaCount < 0)
        {
            snaCount = 0;
        }
        snackCount.text = snaCount.ToString();
    }

    public void CigaPlusBTN()
    {
        cigaCount++;
        cigaretteCount.text = cigaCount.ToString();
    }
    public void CigaMinusBTN()
    {
        cigaCount--;
        if (cigaCount < 0)
        {
            cigaCount = 0;
        }
        cigaretteCount.text = cigaCount.ToString();
    }

    public void CanPlusBTN()
    {
        canCount++;
        candyCount.text = canCount.ToString();
    }
    public void CanMinusBTN()
    {
        canCount--;
        if (canCount < 0)
        {
            canCount = 0;
        }
        candyCount.text = canCount.ToString();
    }
}
