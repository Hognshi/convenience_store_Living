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
    public GameObject[] itemPick = new GameObject[5]; // �մ��� ���� �� �������� ������ �� �������� ��� ����
    public GameObject[] itemList; // ��ü ������ ����Ʈ

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
        customerCase = Random.Range(0, 3); //�� �μ� ����
        itemSize = Random.Range(1, 6); //��� �� ������ ����

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
        switch (randomCustomer) //�� ���̴� ����
        {
            case 0: //���ܸ�
                customerList[0].SetActive(true);
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "����� ���ּ���";
                        break; 
                    case 1:
                        customerText.text = "�л� �����";
                        break; 
                    case 2:
                        customerText.text = "�ȳ��ϼ���, ��� ��Ź�帱�Կ�.";
                        break;
                }
                break; 
            case 1: //������
                customerList[1].SetActive(true);
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "����� ���ּ���";
                        break;
                    case 1:
                        customerText.text = "�л� �����";
                        break;
                    case 2:
                        customerText.text = "�ȳ��ϼ���, ��� ��Ź�帱�Կ�.";
                        break;
                }
                break; 
            case 2: //�ҸӴ�
                customerList[2].SetActive(true);
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "�л� ����� ����";
                        break;
                    case 1:
                        customerText.text = "����� ���ֽñ���";
                        break;
                    case 2:
                        customerText.text = "���� �л� ����� �����~";
                        break;
                }
                break; 
            case 3: //�Ҿƹ���
                customerList[3].SetActive(true);
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "�л� �������";
                        break; 
                    case 1:
                        customerText.text = "�л��� ����� ����";
                        break; 
                    case 2:
                        customerText.text = "��� ����";
                        break;
                }
                break; 
        }
    }
}
