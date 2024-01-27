using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailEndingMNG : MonoBehaviour
{
    public AudioSource aud;
    public Text fail;
    public GameObject exit;
    public GameObject retry;
    string failText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        failText = "����� �˹ٸ� ���� �� �̷���\n���ڷ� ���� ���ذ� ������\n����� �ذ��ϱ�� �߽��ϴ�.";
        StartCoroutine(Typing(failText));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typing(string talk)
    {
        fail.text = null; // ���ڿ� �ʱ�ȭ

        for (int i = 0; i < talk.Length; i++)
        {
            fail.text += talk[i];
            yield return new WaitForSeconds(0.05f);
        }


        fail.text = null;
        fail.color = Color.red;
        talk = "�ٽ� �����Ͻðڽ��ϱ�?";
        for (int i = 0;i < talk.Length; i++)
        {
            fail.text += talk[i];
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
