using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StorySceneMNG : MonoBehaviour
{
    public Button skipBTN;
    // Start is called before the first frame update
    void Start()
    {
        skipBTN.onClick.AddListener(SkipBTN);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkipBTN()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
