using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneMNG : MonoBehaviour
{
    public Text busy;
    public Text living;
    public Button start;
    public Button quit;
    public GameObject sTart;
    public GameObject qUit;

    string dialogue;
    string dialoguee;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = "바쁘다 바빠";
        StartCoroutine(Typing(dialogue));
        dialoguee = "편의점 생활기";
        StartCoroutine(Typingg(dialoguee));

        start.onClick.AddListener(StartBTN);
        quit.onClick.AddListener(QuitBTN);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typing(string talk) //https://maintaining.tistory.com/entry/Unity-Text%EC%97%90-%ED%83%80%EC%9D%B4%ED%95%91-%EB%AA%A8%EC%85%98-%EB%84%A3%EA%B8%B0
    {
        living.text = null; // 문자열 초기화

        for (int i = 0; i < talk.Length; i++)
        {
            busy.text += talk[i];
            yield return new WaitForSeconds(0.05f);
        }
    }
    
    IEnumerator Typingg(string talkk)
    {
        living.text = null; // 문자열 초기화
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < talkk.Length; i++)
        {
            living.text += talkk[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.05f);
        sTart.SetActive(true);
        qUit.SetActive(true);
    }

    public void StartBTN()
    {
        SceneManager.LoadScene("StoryScene");
    }
    public void QuitBTN()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
