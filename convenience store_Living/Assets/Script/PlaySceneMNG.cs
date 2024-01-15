using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlaySceneMNG : MonoBehaviour
{
    public Button memoBTN;
    public Text workTimeText;
    public Text memoText;
    public GameObject memoList; // 메모를 띄울 공간
    public CustomerGenerator csGen; // 고객 제네레이터

    [SerializeField]
    float sec;
    [SerializeField]
    int min;
    int workTime = 1; //게임중 몇일차인지
    int rand;
    [SerializeField]
    bool isNewCustomer = true;

    void Start()
    {
        memoBTN.onClick.AddListener(OpenMemo);
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
        SellItem();
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

        if (min == 5)
        {
            min = 0;
            workTime++;
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

    void SellItem()
    {
        if(Input.GetKeyDown(KeyCode.A)) 
        {
            isNewCustomer = true;
        }
    }
}
