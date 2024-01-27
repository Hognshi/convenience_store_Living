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
        successText = "����� �ܱ� �˹ٸ�\n�����ϼ̽��ϴ�.\n�̷� ���� �����\n���ʽ��� �ް� �Ǿ����ϴ�";
        StartCoroutine(Typing(successText));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Typing(string talk)
    {
        success.text = null; // ���ڿ� �ʱ�ȭ

        for (int i = 0; i < talk.Length; i++)
        {
            success.text += talk[i];
            yield return new WaitForSeconds(0.05f);
        }


        success.text = null;
        success.color = Color.red;
        talk = "�ٽ� �����Ͻðڽ��ϱ�?";
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
        Application.Quit(); // ���ø����̼� ����
#endif
    }
}
