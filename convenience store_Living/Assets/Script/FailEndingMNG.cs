using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailEndingMNG : MonoBehaviour
{
    public Text fail;
    public GameObject exit;
    public GameObject retry;
    string failText;
    // Start is called before the first frame update
    void Start()
    {
        failText = "당신이 알바를 시작 한 이래로\n적자로 인한 손해가 심해져\n당신을 해고하기로 했습니다.";
        StartCoroutine(Typing(failText));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typing(string talk)
    {
        fail.text = null; // 문자열 초기화

        for (int i = 0; i < talk.Length; i++)
        {
            fail.text += talk[i];
            yield return new WaitForSeconds(0.05f);
        }


        fail.text = null;
        fail.color = Color.red;
        talk = "다시 도전하시겠습니까?";
        for (int i = 0;i < talk.Length; i++)
        {
            fail.text += talk[i];
            yield return new WaitForSeconds(0.05f);
        }
        exit.SetActive(true); retry.SetActive(true);
    }

    public void StartBTN()
    {
        SceneManager.LoadScene("PlayScene");
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
