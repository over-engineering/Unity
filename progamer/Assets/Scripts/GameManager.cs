using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
     
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } 
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public string CharacterId = "character0";
    
    // public RestAPI rest;

    void Start()
    {

    }

    void Update()
    {
        
    }

}
