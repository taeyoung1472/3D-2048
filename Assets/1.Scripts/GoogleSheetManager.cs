using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class GoogleSheetManager : MonoBehaviour
{
    const string URL = "https://script.google.com/macros/s/AKfycbw7sdpzYz47neBCaOoPxul6WrMtpbKmX4o5XJyt6qP1MwuIqSQGGHcalSHeoYRaStE/exec";
    bool isOver = true;
    public void Call(string mode, int score, string name = null)
    {
        WWWForm form = new WWWForm();
        if (name != null)
        {
            print(mode + score + name + GameManager.Instance.UserInfo.name);
            form.AddField("Name", name);
        }
        else
        {
            form.AddField("Name", GameManager.Instance.UserInfo.name);
        }
        form.AddField("Score", score);
        form.AddField("Mode", mode);
        if (mode == "Change")
        {
            isOver = false;
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