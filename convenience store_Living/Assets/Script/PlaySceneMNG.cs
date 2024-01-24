using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class PlaySceneMNG : MonoBehaviour
{
    public PosMNG pos;
    public CustomerGenerator csGen;

    public Button memoBTN; 
    public Button sellBTN; //계산 버튼
    public Button closeDayOverScreenBTN;
    public Button sellCompleteBTN;

    public Text workTimeText;
    public Text memoText;
    public Text incomeText;
    public Text outcomeText;
    public Text orderText;//주문 확인 텍스트
    public GameObject memoList; // 메모를 띄울 공간
    public GameObject sellPlace; // 판매품을 띄우는 공간
    public GameObject oneDayOverScreen; // 판매품을 띄우는 공간

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
    int workTime = 1; //게임중 몇일차인지
    int rand;
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
        rand = Random.Range(0, 3);
        TodaysWarning();
    }


    void Update()
    {
        GameTime();
        EnterEscape();

        if(isNewCustomer)
        {
            isNewCustomer = false;
            for(int i =0; i < csGen.customerList.Count(); i++)
            {
                csGen.customerList[i].SetActive(false);
            }
            csGen.RandomCustomerCase();
        }
    }

    public void OpenMemo()
    {
        memoList.SetActive(true);
    }

    void EnterEscape() //esc눌렀을때 꺼짐
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            memoList.SetActive(false);
            sellPlace.SetActive(false);
        }
    }

    void GameTime()
    {
        sec += Time.deltaTime;

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
            TodaysWarning();
            rand = Random.Range(0, 3);
        }
        workTimeText.text = workTime.ToString();
    }

    void TodaysWarning() // 메모에 적히는 금일 주의사항
    {

        if (workTime >= 15)
        {
            switch (rand)
            {
                case 0:
                    memoText.text = "*민증v\n*운전면허증\n*푸키먼 빵o";
                    break;
                case 1:
                    memoText.text = "*민증v\n*운전면허증\n*담배 재고x";
                    break;
                case 2:
                    memoText.text = "*민증V\n*운전면허증\n*신선식품 재고x";
                    break;
            }
        }
        else if (workTime < 15)
        {
            switch (rand)
            {
                case 0:
                    memoText.text = "*민증v\n*푸키먼 빵o";
                    break;
                case 1:
                    memoText.text = "*민증v\n*담배 재고x";
                    break;
                case 2:
                    memoText.text = "*민증v\n*신선식품 재고x";
                    break;
            }
        }
    }

    void CountMoney() //한 손님당 받은 가격 충 수익에 더하기
    {
        totalMoney += (pos.choCount * choMoney) + (pos.alcCount * alcMoney) + (pos.freshCount * freshMoney) + (pos.snaCount * snaMoney)
            + (pos.cigaCount * cigaMoney) + (pos.canCount * canMoney);
    }

    void OneDayOver()
    {
        Time.timeScale = 0;
        oneDayOverScreen.SetActive(true);
        outcomeText.text = $"오늘 손해 금액 : {lostMoney}";
        incomeText.text = $"오늘 수입 금액 : {totalMoney}";
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

    public void SellItem()
    {
        sellPlace.SetActive(true);
        SellPlaceOrderMemo();
    }

    public void SellCompleteBTN()
    {
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

    public void CloseDayOverScreen()
    {
        oneDayOverScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
