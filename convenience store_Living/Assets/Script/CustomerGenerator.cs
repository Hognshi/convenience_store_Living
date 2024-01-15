using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{
    public GameObject[] customerList;

    public int randomCustomer;
    public int customerCase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomCustomerCase()
    {
        randomCustomer = Random.Range(0, 6);

        switch(randomCustomer) //고객 나이대 유형
        {
            case 0:
                customerList[0].SetActive(true);
                customerCase = Random.Range(0, 3); //고객 인성 유형
                switch(customerCase)
                {
                    case 0:
                        break; 
                    case 1:
                        break; 
                    case 2:
                        break;
                }
                break; 
            case 1:
                customerList[1].SetActive(true);
                customerCase = Random.Range(0, 3); //고객 인성 유형
                switch (customerCase)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }
                break; 
            case 2:
                customerList[2].SetActive(true);
                customerCase = Random.Range(0, 3); //고객 인성 유형
                switch (customerCase)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }
                break; 
            case 3:
                customerList[3].SetActive(true);
                customerCase = Random.Range(0, 3); //고객 인성 유형
                switch(customerCase)
                {
                    case 0:
                        break; 
                    case 1:
                        break; 
                    case 2:
                        break;
                }
                break; 
            case 4:
                customerList[4].SetActive(true);
                customerCase = Random.Range(0, 3); //고객 인성 유형
                switch (customerCase)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }
                break; 
            case 5:
                customerList[5].SetActive(true);
                customerCase = Random.Range(0, 3); //고객 인성 유형
                switch (customerCase)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }
                break;
        }
    }
}
