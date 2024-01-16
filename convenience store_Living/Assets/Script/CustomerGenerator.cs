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
        switch (randomCustomer) //고객 나이대 유형
        {
            case 0:
                customerList[0].SetActive(true);
                customerCase = Random.Range(0, 3); //고객 인성 유형
                switch(customerCase)
                {
                    case 0:
                        customerText.text = "0손님 0케이스";
                        break; 
                    case 1:
                        customerText.text = "0손님 1케이스";
                        break; 
                    case 2:
                        customerText.text = "0손님 2케이스";
                        break;
                }
                break; 
            case 1:
                customerList[1].SetActive(true);
                customerCase = Random.Range(0, 3); //고객 인성 유형
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "1손님 0케이스";
                        break;
                    case 1:
                        customerText.text = "1손님 1케이스";
                        break;
                    case 2:
                        customerText.text = "1손님 2케이스";
                        break;
                }
                break; 
            case 2:
                customerList[2].SetActive(true);
                customerCase = Random.Range(0, 3); //고객 인성 유형
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "2손님 0케이스";
                        break;
                    case 1:
                        customerText.text = "2손님 1케이스";
                        break;
                    case 2:
                        customerText.text = "2손님 2케이스";
                        break;
                }
                break; 
            case 3:
                customerList[3].SetActive(true);
                customerCase = Random.Range(0, 3); //고객 인성 유형
                switch(customerCase)
                {
                    case 0:
                        customerText.text = "3손님 0케이스";
                        break; 
                    case 1:
                        customerText.text = "3손님 1케이스";
                        break; 
                    case 2:
                        customerText.text = "3손님 2케이스";
                        break;
                }
                break; 
            case 4:
                customerList[4].SetActive(true);
                customerCase = Random.Range(0, 3); //고객 인성 유형
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "4손님 0케이스";
                        break;
                    case 1:
                        customerText.text = "4손님 1케이스";
                        break;
                    case 2:
                        customerText.text = "4손님 2케이스";
                        break;
                }
                break; 
            case 5:
                customerList[5].SetActive(true);
                customerCase = Random.Range(0, 3); //고객 인성 유형
                switch (customerCase)
                {
                    case 0:
                        customerText.text = "5손님 0케이스";
                        break;
                    case 1:
                        customerText.text = "5손님 1케이스";
                        break;
                    case 2:
                        customerText.text = "5손님 2케이스";
                        break;
                }
                break;
        }
    }
}
