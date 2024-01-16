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

    public int randomCustomer;
    public int customerCase;
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
        randomCustomer = Random.Range(0, 6);
        textBox.SetActive(true);
        customerTextGameObject.SetActive(true);
        switch (randomCustomer) //�� ���̴� ����
        {
            case 0:
                customerList[0].SetActive(true);
                customerCase = Random.Range(0, 3); //�� �μ� ����
                switch(customerCase)
                {
                    case 0:
                        customerText.text = "0�մ� 0���̽�";
                        break; 
                    case 1:
                        customerText.text = "0�մ� 1���̽�";
                        break; 
                    case 2:
                        customerText.text = "0�մ� 2���̽�";
                        break;
                }
                break; 
            case 1:
                customerList[1].SetActive(true);
                customerCase = Random.Range(0, 3); //�� �μ� ����
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "1�մ� 0���̽�";
                        break;
                    case 1:
                        customerText.text = "1�մ� 1���̽�";
                        break;
                    case 2:
                        customerText.text = "1�մ� 2���̽�";
                        break;
                }
                break; 
            case 2:
                customerList[2].SetActive(true);
                customerCase = Random.Range(0, 3); //�� �μ� ����
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "2�մ� 0���̽�";
                        break;
                    case 1:
                        customerText.text = "2�մ� 1���̽�";
                        break;
                    case 2:
                        customerText.text = "2�մ� 2���̽�";
                        break;
                }
                break; 
            case 3:
                customerList[3].SetActive(true);
                customerCase = Random.Range(0, 3); //�� �μ� ����
                switch(customerCase)
                {
                    case 0:
                        customerText.text = "3�մ� 0���̽�";
                        break; 
                    case 1:
                        customerText.text = "3�մ� 1���̽�";
                        break; 
                    case 2:
                        customerText.text = "3�մ� 2���̽�";
                        break;
                }
                break; 
            case 4:
                customerList[4].SetActive(true);
                customerCase = Random.Range(0, 3); //�� �μ� ����
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "4�մ� 0���̽�";
                        break;
                    case 1:
                        customerText.text = "4�մ� 1���̽�";
                        break;
                    case 2:
                        customerText.text = "4�մ� 2���̽�";
                        break;
                }
                break; 
            case 5:
                customerList[5].SetActive(true);
                customerCase = Random.Range(0, 3); //�� �μ� ����
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "5�մ� 0���̽�";
                        break;
                    case 1:
                        customerText.text = "5�մ� 1���̽�";
                        break;
                    case 2:
                        customerText.text = "5�մ� 2���̽�";
                        break;
                }
                break;
        }
    }
}
