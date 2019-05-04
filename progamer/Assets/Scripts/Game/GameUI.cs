using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameUI : MonoBehaviour
{
    private static GameUI instance;
    public static GameUI Instance { get { return instance; } }
     
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } 
        instance = this;
        // DontDestroyOnLoad(this.gameObject);
    }

    // [SerializeField] private GameObject texts;
    
    // [SerializeField] private HealthBar healthBarPrefab;
    [SerializeField] private Button pickBan;    
    // [SerializeField] private Button gameStart;    
    [SerializeField] private Transform pickHero;    
    [SerializeField] private Transform messages;

    
    [SerializeField] private List<Button> heroButton = new List<Button>();
    
    // private List<Text> text = new List<Text>();

    [SerializeField] private List<Hero> heroPrefabs = new List<Hero>();
    [SerializeField] private Transform players;     

    // [SerializeField] private GameObject heroImagePrefab;
    // [SerializeField] private HealthBar heroDoubleBarPrefab;
    // [SerializeField] private Transform[] spawnPoint;
    
    // private Dictionary<string, Hero> heros = new Dictionary<string, Hero>();
    // private Dictionary<string, HealthBar> healthBars = new Dictionary<string, HealthBar>();
    // [SerializeField] private Image[] image;
    private int currentText;

    [SerializeField] private Slider iSlider0;
    [SerializeField] private Slider iSlider2;
    [SerializeField] private Slider tSlider0;
    [SerializeField] private Text timer;

    void Start() {
        foreach (Transform child in pickHero) {
            heroButton.Add(child.GetComponent<Button>());
        }
        timer = transform.GetChild(7).GetComponent<Text>();
        // Setup();
        // foreach (Transform child in texts) {
        //     text.Add(child.GetComponent<Text>());
        // }
        // Simulation.Instance.GameStart();
    }

    // private void SetTexts(int i, Hero hero) {
    //     hero.Texts[0].text = hero.PlayerId;
    //     hero.Texts[1].text = hero.HeroData.Name;
    //     hero.Texts[2].text = hero.HeroData.Level.ToString();
        
    //     if (i >= 5) {
    //         for (int j = 0; j < hero.Texts.Length; j++) {
    //             float x = hero.Texts[j].GetComponent<RectTransform>().anchoredPosition.x;
    //             float y = hero.Texts[j].GetComponent<RectTransform>().anchoredPosition.y;
    //             hero.Texts[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(-x, y);
    //         }
    //     }
    // }
    void Update() {
        int time = (int)(Simulation.Instance.Timer);
        timer.text = time.ToString();
    }

    public void OnClickPickAndBan() {
        GameSetup.Instance.PickAndBan();
        pickBan.gameObject.SetActive(false);        
    }

    // public void OnClickGameStart() {

    // }
    
    public void SetHeroButtons() {
        // Debug.Log("SetHeroButtons!!! " + heroButton.Count);
        for (int i = 0; i < heroButton.Count; i++) {   
            // Debug.Log(heroButton[i].gameObject);
            heroButton[i].gameObject.SetActive(true);
            int index = i;
            heroButton[i].onClick.AddListener(() => { 
                Hero heroInstance = Instantiate(heroPrefabs[index], players.GetChild(GameSetup.Instance.PlayerPos()));
                // Debug.Log(heroInstance);
                GameSetup.Instance.PickHero(heroInstance);
                heroButton[index].gameObject.SetActive(false); 
            });
            heroButton[i].transform.GetChild(0).GetComponent<Text>().text = heroPrefabs[i].name;
        }
    }

    // private void Setup() {
    //     int i = 0;
    //     foreach (Transform child in players) {
    //         Hero hero = Instantiate(heroPrefabs[i], child);            
    //         hero.PlayerId = i.ToString();
    //         hero.SetTexts();
    //         if (i >= 5) {
    //             hero.MoveText();
    //         }
    //         // SetTexts(i, hero);
    //         hero.HealthBar.SetHealth(hero.HeroData.Health, hero.HeroData.MaxHP);
    //         // ResponseHandler.Setup(hero.PlayerId, hero);
    //         Simulation.Instance.Setup(hero.PlayerId, i, hero);
    //         // hero.Setup(i.ToString());
    //         i++;            
    //         // heros.Add(hero.PlayerId, hero);
    //         // healthBars.Add(hero.PlayerId, hero.HealthBar);



            

    //         // GameObject go = Instantiate(heroImagePrefab, child);
            
    //         // HealthBar healthBar = Instantiate(heroDoubleBarPrefab, child);
            
    //         // healthBars.Add(hero.playerId, healthBar);
    //     }
    //     // AddHealthBar(0.ToString(), );
    //     // for (int i = 0; i < 10; i++) {            
    //     //     HealthBar healthBar = Instantiate(healthBarPrefab, image[i].transform);
    //     //     AddHealthBar(i.ToString(), healthBar);
    //     //     healthBar.transform.SetParent(image[i].transform);
    //     //     // healthBar.transform.parent = ;
    //     // }

    //     // HealthBar healthBar = Instantiate(healthBarPrefab, spawnPoint[i++]);
    //     // AddHealthBar("A", healthBar);        
    //     // healthBar = Instantiate(healthBarPrefab, spawnPoint[i++]);
    //     // GameUI.Instance.AddHealthBar("B", healthBar);
    //     // healthBar = Instantiate(healthBarPrefab, spawnPoint[i++]);
    //     // GameUI.Instance.AddHealthBar("C", healthBar);
    //     // healthBar = Instantiate(healthBarPrefab, spawnPoint[i++]);
    //     // GameUI.Instance.AddHealthBar("D", healthBar);
    //     // healthBar = Instantiate(healthBarPrefab, spawnPoint[i++]);
    //     // GameUI.Instance.AddHealthBar("E", healthBar);
    //     // healthBar = Instantiate(healthBarPrefab, spawnPoint[i++]);
    //     // GameUI.Instance.AddHealthBar("F", healthBar);
    //     // healthBar = Instantiate(healthBarPrefab, spawnPoint[i++]);
    //     // GameUI.Instance.AddHealthBar("G", healthBar);
    //     // healthBar = Instantiate(healthBarPrefab, spawnPoint[i++]);
    //     // GameUI.Instance.AddHealthBar("H", healthBar);
    //     // healthBar = Instantiate(healthBarPrefab, spawnPoint[i++]);
    //     // GameUI.Instance.AddHealthBar("I", healthBar);
    //     // healthBar = Instantiate(healthBarPrefab, spawnPoint[i++]);
    //     // GameUI.Instance.AddHealthBar("J", healthBar);
    // }

    public void OnIndValueChanged(Slider slider) {
        // Debug.Log("OnIndValueChanged " + slider.value);
        // Simulation.Instance.UpdateIndivisual(slider.value);
        if (slider == iSlider0) {
            GameEventMaker.Instance.UpdateIndivisual(0, slider.value);
        } else if (slider == iSlider2) {
            GameEventMaker.Instance.UpdateIndivisual(2, slider.value);
        }

        // float[] vals = new float[2];
        // vals[0] = slider[0].value;
        // vals[1] = slider[1].value;
        // GameEventMaker.Instance.UpdateIndivisual(vals);
    }

    public void OnTeamValueChanged(Slider slider) {
        // Debug.Log("OnTeamValueChanged " + slider.value);
        // Simulation.Instance.UpdateTeam(slider.value);
        // float[] vals = new float[1];
        // vals[0] = slider[0].value;
        // vals[1] = slider[1].value;
        if (slider == tSlider0) {
            GameEventMaker.Instance.UpdateTeam(0, slider.value);
        }
    }

    public void ShowEventMsg(string msg) {
        messages.transform.GetChild(currentText).GetComponent<Text>().text = msg;
        // texts.GetChild(current).GetComponent<texts>().text = msg;
        currentText++;
        if (currentText >= 16) {
            currentText = 0;
        }
    }

    // public void AddHealthBar(string id, HealthBar healthBar) {
    //     healthBars[id] = healthBar;
    // }

    // public void UpdateHealth(string playerId, int health, int maxHealth) {
    //     healthBars[playerId].HandleHealthChanged(health, maxHealth);       
    // }
}
