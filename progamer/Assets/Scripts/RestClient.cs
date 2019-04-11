using UnityEngine;
// using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class RestClient : MonoBehaviour
{
    private static RestClient instance;
    public static RestClient Instance { get { return instance; } }
     
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        } 
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public const string CommonBaseURL = "http://localhost:8080";
    public const string ProgamerBaseURL = "http://localhost:8082";
    // public Text ResponseText;

    public IEnumerator Get(string baseURL, string path, System.Action<Ability> callBack) {
        using (UnityWebRequest www = UnityWebRequest.Get(baseURL + path)) {
            yield return www.SendWebRequest();

            if (www.isNetworkError) {
                Debug.Log(www.error);
            } else {
                if (www.isDone) {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Ability ability = JsonUtility.FromJson<Ability>(jsonResult);
                    callBack(ability);
                    Debug.Log(jsonResult);
                }
            }

        }
    }

}