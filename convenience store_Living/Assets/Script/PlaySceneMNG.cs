using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaySceneMNG : MonoBehaviour
{
    public PosMNG pos;
    public CustomerGenerator csGen;

    public AudioSource aud;

    public Button sellBTN; //계산 버튼
    public Button closeDayOverScreenBTN;
    public Button sellCompleteBTN;

    public Image sun;

    public Text workTimeText;
    public Text incomeText;
    public Text outcomeText;
    public Text orderText;//주문 확인 텍스트

    public GameObject sellPlace; // 판매품을 띄우는 공간
    public GameObject oneDayOverScreen; // 판매품을 띄우는 공간

    public GameObject trueEndingScreen; 
    public GameObject badEndingScreen; 

    public GameObject chocolate;
    public GameObject alcohol; 
    public GameObject freshFood;
    public GameObject snack; 
    public GameObject cigarette; 
    public GameObject candy; 

    public int totalMoney; // 하루 총 수익
    public int lostMoney; // 하루 총 손해액

    [SerializeField]
    float sec;
    [SerializeField]
    int min;
    public int workTime = 1; //게임중 몇일차인지
    [SerializeField]
    bool isNewCustomer = true;

    int choMoney = 1000;
    int alcMoney = 1500;
    int freshMoney = 3000;
    int snaMoney = 1500;
    int cigaMoney = 4500;
    int canMoney = 500;

    void Start()
    {
    }


    void Update()
    {
        GameTime();
        EnterEscape();
        if (isNewCustomer)
        {
            isNewCustomer = false;
            for(int i =0; i < csGen.customerList.Count(); i++)
            {
                csGen.customerList[i].SetActive(false);
            }
            csGen.RandomCustomerCase();
        }
        
    }


    void EnterEscape() //esc눌렀을때 꺼짐
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            orderText.text = null;
            sellPlace.SetActive(false);
        }
    }

    void GameTime()
    {
        sec += Time.deltaTime;
        sun.fillAmount = 1 - (sec + min * 60) / 300;
        if ((int)sec == 60)
        {
            min++;
            sec = 0;
        }

        if (min >= 5)
        {
            workTime++;
            OneDayOver();
            min = 0;
        }
        workTimeText.text = workTime.ToString();
    }


    void CountMoney() //한 손님당 받은 가격 충 수익에 더하기
    {
        int countMoney = 0; //정답 돈을 계산하기 위함
        int lost = 0;
        for (int i = 0; i < csGen.itemSize; i++)
        {
            if (csGen.itemPick[i] == chocolate)
            {
                countMoney += choMoney;
                pos.choCount--;
            }
            else if (csGen.itemPick[i] == alcohol)
            {
                countMoney += alcMoney;
                pos.alcCount--;
            }
            else if (csGen.itemPick[i] == freshFood)
            {
                countMoney += freshMoney;
                pos.freshCount--;
            }
            else if (csGen.itemPick[i] == snack)
            {
                countMoney += snaMoney;
                pos.snaCount--;
            }
            else if (csGen.itemPick[i] == cigarette)
            {
                countMoney += cigaMoney;
                pos.cigaCount--;
            }
            else if (csGen.itemPick[i] == candy)
            {
                countMoney += canMoney;
                pos.canCount--;
            }
        }
        lost = 0;

        if(pos.choCount != 0)
        {
            if(pos.choCount < 0)
            {
                pos.choCount *= -1;
            }
            lost += pos.choCount* choMoney;
        }
        else if (pos.alcCount != 0)
        {
            if (pos.alcCount < 0)
            {
                pos.alcCount *= -1;
            }
            lost += pos.alcCount * alcMoney;
        }
        else if (pos.freshCount != 0)
        {
            if (pos.freshCount < 0)
            {
                pos.freshCount *= -1;
            }
            lost += pos.freshCount * freshMoney;
        }
        else if (pos.snaCount != 0)
        {
            if (pos.snaCount < 0)
            {
                pos.snaCount *= -1;
            }
            lost += pos.snaCount * snaMoney;
        }
        else if (pos.cigaCount != 0)
        {
            if (pos.cigaCount < 0)
            {
                pos.cigaCount *= -1;
            }
            lost += pos.cigaCount * cigaMoney;
        }
        else if (pos.canCount != 0)
        {
            if (pos.canCount < 0)
            {
                pos.canCount *= -1;
            }
            lost += pos.canCount * canMoney;
        }

        totalMoney += countMoney - lost;
        lostMoney += lost;
    }

    void OneDayOver()
    {
        Time.timeScale = 0;
        oneDayOverScreen.SetActive(true);
        outcomeText.text = $"현재 총 손해 금액 : {lostMoney}";
        incomeText.text = $"현재 총 수입 금액 : {totalMoney}";
    }

    void SellPlaceOrderMemo()
    {
        for(int i = 0; i < csGen.itemSize; i++)
        {
            if (csGen.itemPick[i] == chocolate)
            {
                orderText.text += "초콜릿\n";
            }
            if (csGen.itemPick[i] == alcohol)
            {
                orderText.text += "술\n";
            }
            if (csGen.itemPick[i] == freshFood)
            {
                orderText.text += "신선식품\n";
            }
            if (csGen.itemPick[i] == snack)
            {
                orderText.text += "과자\n";
            }
            if (csGen.itemPick[i] == cigarette)
            {
                orderText.text += "담배\n";
            }
            if (csGen.itemPick[i] == candy)
            {
                orderText.text += "사탕\n";
            }
        }
    }

    void GameEnding()
    {
        if (lostMoney >= 100000)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("FailEnding");
        }
        if (workTime == 6)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("SuccessEnding");
        }

    }

    public void SellItemBTN()
    {
        aud.Play();
        sellPlace.SetActive(true);
        SellPlaceOrderMemo();
    }

    public void SellCompleteBTN()
    {
        aud.Play();
        orderText.text = null;
        CountMoney();
        pos.choCount = 0;
        pos.alcCount = 0;
        pos.freshCount = 0;
        pos.snaCount = 0;
        pos.cigaCount = 0;
        pos.canCount = 0;

        pos.chocolateCount.text = pos.choCount.ToString();
        pos.alcoholCount.text = pos.alcCount.ToString();
        pos.freshFoodCount.text = pos.freshCount.ToString();
        pos.snackCount.text = pos.snaCount.ToString();
        pos.cigaretteCount.text = pos.cigaCount.ToString();
        pos.candyCount.text = pos.canCount.ToString();
        sellPlace.SetActive(false);
        isNewCustomer = true;
    }

    public void CloseDayOverScreenBTN()
    {
        aud.Play();
        oneDayOverScreen.SetActive(false);
        Time.timeScale = 1;

        GameEnding();
    }
}
