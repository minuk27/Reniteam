using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class STTRecording : MonoBehaviour
{
    // Start is called before the first frame update
    Process recoding;
    Process STT;
    // Start is called before the first frame update
    void Start()
    {
        recoding = new Process();
        STT = new Process();
        recoding.StartInfo.FileName = "C:/Users/ÇÑ½Â¼ö/AppData/Local/Programs/Python/Python39/python";
        recoding.StartInfo.Arguments = "./Assets/6.STT/microphone.py";
        recoding.StartInfo.CreateNoWindow = true;
        recoding.StartInfo.UseShellExecute = false;
        STT.StartInfo.FileName = "C:/Users/ÇÑ½Â¼ö/AppData/Local/Programs/Python/Python39/python";
        STT.StartInfo.Arguments = "./Assets/6.STT/main.py";
        STT.StartInfo.CreateNoWindow = true;
        STT.StartInfo.UseShellExecute = false;
    }

    public void Recording()
    {
        UnityEngine.Debug.Log("Recording½ÃÀÛ");
        recoding.Start();
        //Invoke("SoundText", 6f);
    }
    public void SoundText()
    {
        UnityEngine.Debug.Log("stt½ÃÀÛ");
        STT.Start();;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Recording();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SoundText();
        }
        
    }
}
