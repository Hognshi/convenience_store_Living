using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StorySceneMNG : MonoBehaviour
{
    public GameObject closeBTN;
    public Text story;
    public Text warning;

    string storyText;
    string warningText;
    // Start is called before the first frame update
    void Start()
    {
        storyText = "당신은 15일 편의점 단기 알바에\n합격하게 되었음을 알려드립니다\n아래의 버튼을 눌러 출근하세요.";
        StartCoroutine(Typing(storyText));

        warningText = "모든 상호작용은 마우스 왼쪽 클릭으로\n진행됨을 알려드립니다.";
        StartCoroutine(Typingg(warningText));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkipBTN()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void CloseBTN()
    {
        SceneManager.LoadScene("PlayScene");
    }

    IEnumerator Typing(string talk)
    {
        story.text = null; // 문자열 초기화

        for (int i = 0; i < talk.Length; i++)
        {
            story.text += talk[i];
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator Typingg(string talkk)
    {
        warning.text = null; // 문자열 초기화
        yield return new WaitForSeconds(2.7f);
        for (int i = 0; i < talkk.Length; i++)
        {
            warning.text += talkk[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.1f);
        closeBTN.SetActive(true);
    }
}
