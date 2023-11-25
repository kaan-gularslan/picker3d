using System;
using System.Collections;
using Newtonsoft.Json;
using Runtime.Data.ValueObjects.NotionData;
using UnityEngine;
using UnityEngine.Networking;

namespace Runtime.Managers
{
    
    public class NotionManager : MonoBehaviour
    {
        private void Start()
        {
            TextAsset deneme = Resources.Load<TextAsset>("NotionTemplates/CreateAPage");
            string body = deneme.text;
            //StartCoroutine(PostRequest("https://api.notion.com/v1/pages", body));
        }
        
        

        IEnumerator PostRequest(string uri, string body)
        {
            //string body = JsonConvert.SerializeObject(createPageRequest);
            UnityWebRequest www = UnityWebRequest.Put(uri, body);
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Notion-Version", "2022-02-22");
            www.SetRequestHeader("Authorization", "secret_UjKHbYrKnodOcRpRP0Bk0QuLmYnfNYsIxVJ10AB8O1G");
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                Debug.Log(www.result);
            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(www.result.ToString());
            }
        }
    }
}