using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class GoogleSheetManager : MonoBehaviour
{
    const string URL = "https://script.google.com/macros/s/AKfycbw7sdpzYz47neBCaOoPxul6WrMtpbKmX4o5XJyt6qP1MwuIqSQGGHcalSHeoYRaStE/exec";
    public int score;
    public string name;
    public void RankSystem()
    {
        WWWForm form = new WWWForm();
        form.AddField("Id", "ABCD");
        form.AddField("Score", 123);
        StartCoroutine(SetRank(form));
    }
    public IEnumerator SetRank(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            if (www.isDone) print(www.downloadHandler.text); 
            else Debug.LogError("응답없음! 네트워크 연결오류.");
        }
    }
}