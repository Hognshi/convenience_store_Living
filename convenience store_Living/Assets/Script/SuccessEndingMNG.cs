using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SuccessEndingMNG : MonoBehaviour
{
    public AudioSource aud;
    public Text success;
    public GameObject exit;
    public GameObject retry;
    public string successText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        successText = "당신은 단기 알바를\n성공하셨습니다.\n이로 인해 당신은\n보너스를 받게 되었습니다";
        StartCoroutine(Typing(successText));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Typing(string talk)
    {
        success.text = null; // 문자열 초기화

        for (int i = 0; i < talk.Length; i++)
        {
            success.text += talk[i];
            yield return new WaitForSeconds(0.05f);
        }


        success.text = null;
        success.color = Color.red;
        talk = "다시 도전하시겠습니까?";
        for (int i = 0; i < talk.Length; i++)
        {
            success.text += talk[i];
            yield return new WaitForSeconds(0.05f);
        }
        exit.SetActive(true); retry.SetActive(true);
    }

    public void StartBTN()
    {
        aud.Play();
        SceneManager.LoadScene("PlayScene");
    }
    public void QuitBTN()
    {
        aud.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
