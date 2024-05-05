using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class JsonTest : MonoBehaviour
{
    private string filePath = "./Assets/8.Data/nouns.json"; // JSON 파일 경로
    [SerializeField] GameObject voiceWindow;
    [SerializeField] GameObject talkArrow;
    [SerializeField] Text voicText;

    private void Awake()
    {
        voiceWindow.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            voiceWindow.SetActive(false);
        }
    }

    private void OnEnable()
    {
        voiceWindow.SetActive(false);
    }

    public void voiceText()
    {
        string jsonString = File.ReadAllText(filePath); // 파일로부터 JSON 읽기
        voiceWindow.SetActive(true);
        StartCoroutine(WriteText(jsonString));
        Debug.Log(jsonString);
    }

    IEnumerator WriteText(string text)
    {
        voicText.text = "";
        foreach (char s in text)
        {
            voicText.text += s;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.1f);
        talkArrow.GetComponent<Animator>().SetTrigger("Move");
    }

    public void endVoice()
    {
        StopCoroutine("WriteText");
        voiceWindow.SetActive(false);
    }
}