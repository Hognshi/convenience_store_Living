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

    public Button memoBTN; 
    public Button sellBTN; //계산 버튼
    public Button closeDayOverScreenBTN;
    public Button sellCompleteBTN;

    public Text workTimeText;
    public Text memoText;
    public Text incomeText;
    public GameObject memoList; // 메모를 띄울 공간
    public GameObject sellPlace; // 판매품을 띄우는 공간
    public GameObject oneDayOverScreen; // 판매품을 띄우는 공간
    public GameObject openIncomeText; // 수입 텍스트 보이게 하기
    public GameObject completeButton; // 완료 버튼 끄고 키기
    public CustomerGenerator csGen; // 고객 제네레이터

    public int totalMoney; // 하루 총수익

    [SerializeField]
    float sec;
    [SerializeField]
    int min;
    int workTime = 1; //게임중 몇일차인지
    int rand;
    string dialogue; // 수익 출력을 위한 문자열
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
        memoBTN.onClick.AddListener(OpenMemo);
        sellBTN.onClick.AddListener(SellItem);
        closeDayOverScreenBTN.onClick.AddListener(CloseDayOverScreen);
        sellCompleteBTN.onClick.AddListener(SellCompleteBTN);
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
            oneDayOverScreen.SetActive(true);
            Time.timeScale = 0;
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

    public void SellItem()
    {
        sellPlace.SetActive(true);
    }

    public void SellCompleteBTN()
    {
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
        openIncomeText.SetActive(false);
        completeButton.SetActive(false);
        oneDayOverScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
