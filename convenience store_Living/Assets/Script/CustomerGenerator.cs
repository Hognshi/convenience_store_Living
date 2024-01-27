using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerGenerator : MonoBehaviour
{
    public GameObject[] customerList;
    public GameObject textBox;
    public GameObject customerTextGameObject;
    public Text customerText;
    public GameObject[] itemPick = new GameObject[5]; // 손님이 구입 할 아이템의 갯수와 그 아이템을 담는 공간
    public GameObject[] itemList; // 전체 아이템 리스트

    public int randomCustomer;
    public int customerCase;
    public int itemCheck;
    public int itemSize;
    // Start is called before the first frame update
    void Start()
    {
        RandomCustomerCase();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomCustomerCase()
    {
        randomCustomer = Random.Range(0, 4);
        textBox.SetActive(true);
        customerTextGameObject.SetActive(true);
        customerCase = Random.Range(0, 3); //고객 인성 유형
        itemSize = Random.Range(1, 6); //들고 올 아이템 갯수

        for (int i = 0; i < itemSize; i++)
        {
            itemCheck = Random.Range(0, 6);
            switch (itemCheck)
            {
                case 0:
                    itemPick[i] = itemList[0]; break;
                case 1:
                    itemPick[i] = itemList[1]; break;
                case 2:
                    itemPick[i] = itemList[2]; break;
                case 3:
                    itemPick[i] = itemList[3]; break;
                case 4:
                    itemPick[i] = itemList[4]; break;
                case 5:
                    itemPick[i] = itemList[5]; break;
            }
        }
        switch (randomCustomer) //고객 나이대 유형
        {
            case 0: //아줌마
                customerList[0].SetActive(true);
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "계산좀 해주세요";
                        break; 
                    case 1:
                        customerText.text = "학생 계산좀";
                        break; 
                    case 2:
                        customerText.text = "안녕하세요, 계산 부탁드릴게요.";
                        break;
                }
                break; 
            case 1: //아저씨
                customerList[1].SetActive(true);
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "계산좀 해주세요";
                        break;
                    case 1:
                        customerText.text = "학생 계산좀";
                        break;
                    case 2:
                        customerText.text = "안녕하세요, 계산 부탁드릴게요.";
                        break;
                }
                break; 
            case 2: //할머니
                customerList[2].SetActive(true);
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "학생 고생이 많네";
                        break;
                    case 1:
                        customerText.text = "계산좀 해주시구려";
                        break;
                    case 2:
                        customerText.text = "허허 학생 계산좀 해줘요~";
                        break;
                }
                break; 
            case 3: //할아버지
                customerList[3].SetActive(true);
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "학생 계산해줘";
                        break; 
                    case 1:
                        customerText.text = "학생이 고생이 많아";
                        break; 
                    case 2:
                        customerText.text = "계산 고맙네";
                        break;
                }
                break; 
        }
    }
}
