using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class GoogleSheetManager : MonoBehaviour
{
    const string URL = "https://script.google.com/macros/s/AKfycbw7sdpzYz47neBCaOoPxul6WrMtpbKmX4o5XJyt6qP1MwuIqSQGGHcalSHeoYRaStE/exec";
    public string name;
    public void Call(string mode, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("Name",name);
        form.AddField("Score", score);
        form.AddField("Mode", mode);
        StartCoroutine(SetRank(form));
    }
    public IEnumerator SetRank(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            if (www.isDone) print(www.downloadHandler.text);
            else Debug.LogError("�������! ��Ʈ��ũ �������.");
            GameManager.Instance.overString = www.downloadHandler.text;
            GameManager.Instance.GameOver();
        }
    }
}