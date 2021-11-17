using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class GoogleSheetManager : MonoBehaviour
{
    const string URL = "https://script.google.com/macros/s/AKfycbw7sdpzYz47neBCaOoPxul6WrMtpbKmX4o5XJyt6qP1MwuIqSQGGHcalSHeoYRaStE/exec";
    bool isOver = true;
    public void Call(string mode, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("Name",GameManager.Instance.UserInfo.name);
        form.AddField("Score", score);
        form.AddField("Mode", mode);
        if (mode == "Change")
        {
            form.AddField("NewId", GameManager.Instance.UserInfo.nameTemp);
            isOver = false;
            GameManager.Instance.UserInfo.RealChangeName();
        }
        else
        {
            isOver = true;
        }
        StartCoroutine(SetRank(form));
    }
    public IEnumerator SetRank(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            if (www.isDone) print(www.downloadHandler.text);
            else Debug.LogError("응답없음! 네트워크 연결오류.");
            GameManager.Instance.overString = www.downloadHandler.text;
            if (isOver)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}