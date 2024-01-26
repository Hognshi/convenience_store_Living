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
        storyText = "����� 15�� ������ �ܱ� �˹ٿ�\n�հ��ϰ� �Ǿ����� �˷��帳�ϴ�\n�Ʒ��� ��ư�� ���� ����ϼ���.";
        StartCoroutine(Typing(storyText));

        warningText = "��� ��ȣ�ۿ��� ���콺 ���� Ŭ������\n������� �˷��帳�ϴ�.";
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
        story.text = null; // ���ڿ� �ʱ�ȭ

        for (int i = 0; i < talk.Length; i++)
        {
            story.text += talk[i];
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator Typingg(string talkk)
    {
        warning.text = null; // ���ڿ� �ʱ�ȭ
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
