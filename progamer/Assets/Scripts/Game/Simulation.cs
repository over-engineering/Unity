using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Simulation : MonoBehaviour
{    
    private static Simulation instance;
    public static Simulation Instance { get { return instance; } }
     
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } 
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // [SerializeField] private float[] teamOffensive;
    // [SerializeField] private float[] indivisualOffensive;
    // private Dictionary<string, float> indivisualOffensive = new Dictionary<string, float>();
    // private Dictionary<string, Hero> hero = new Dictionary<string, Hero>();
    // public TeamStrategy[] teamStrategy;

    public TeamStatus[] teamStatus;
    // public Hero[] blueSideHero;
    // public Hero[] redSideHero;
    // public Ability[] blueAbility;
    // public Ability[] redAbility;
    private float timer;
    public float Timer{ get { return timer; } }

    
    // [SerializeField] private float maxValue;
     [Header("Ability")]
    [SerializeField] private float abilityRatio;
    [SerializeField] private int[] abilityType;
    [SerializeField] private float[] eachAbilityRatio;
    // [SerializeField] private int[] abilityType;
    // [SerializeField] private int[] eventAbilityType;
    
    [Header("Hero")]
    [SerializeField] private float heroRatio;
    [SerializeField] private float[] mastery;
    [SerializeField] private int totalHeroNum;
    [SerializeField] private float[,] heroTable;

    [Header("Growth")]
    [SerializeField] private float[] blueGrowth;
    [SerializeField] private float[] redGrowth;

    [SerializeField] private float baseExpGrowth;
    [SerializeField] private float expFactor;
    [SerializeField] private float[] blueExpGrowth;
    [SerializeField] private float[] redExpGrowth;

    [SerializeField] private int baseGoldGrowth;
    [SerializeField] private int goldFactor;
    [SerializeField] private int[] blueGoldGrowth;
    [SerializeField] private int[] redGoldGrowth;
    
    // [SerializeField] private GameEvent[] gameEvents;
    [Header("GameEvent")]
    public GameEvent currentGameEvent;
    [SerializeField] private bool isEvent = false;
    // public List<string> EventParticipants = new List<string>();
    // private Dictionary<string, float> abilityAdv = new Dictionary<string, float>();
    // private Dictionary<string, float> heroAdv = new Dictionary<string, float>();
    private Dictionary<string, float> abilityAdv = new Dictionary<string, float>();
    private Dictionary<string, float> heroAdv = new Dictionary<string, float>();
    // public int MyTeam;
    // public int MyHeroLine;
    // public string MyHeroId = "0";
    // public Hero MyHero;

    // private string source;
    // private string target;
    
    
    // public bool turn = false; // blue: true, red: false
    // public int turnIndex;
    
    // const int MY_TEAM = 0;
    // const int MY_HERO = 0;
    void Start() {
        // Setup();
        // ability = GameManager.Instance.Character.ability;
        MakeHeroTable();

        teamStatus = new TeamStatus[2];
        teamStatus[Const.BLUE] = new TeamStatus();
        teamStatus[Const.RED] = new TeamStatus();
        teamStatus[Const.BLUE].Hero = new Hero[5];
        teamStatus[Const.RED].Hero = new Hero[5];
        teamStatus[Const.BLUE].Ability = new Ability[5];
        teamStatus[Const.RED].Ability = new Ability[5];
        
        // blueSideHero = new Hero[5];
        // redSideHero = new Hero[5];
        
        // blueAbility = new Ability[5];
        // redAbility = new Ability[5];

        // maxValue = 100f * abilityType.Length;
        blueGrowth = new float[5];
        redGrowth = new float[5];

        blueExpGrowth = new float[5];
        blueGoldGrowth = new int[5];
        redExpGrowth = new float[5];        
        redGoldGrowth = new int[5];
    

        // teamOffensive = new float[2];
        // teamOffensive[0] = 1f;
        // teamOffensive[1] = 1f;

        // indivisualOffensive = new float[10];
        // for (int i = 0; i < 10; i++) {            
        //     indivisualOffensive[i] = 1f;
        // }      
    }

    void Update() {
        timer += Time.deltaTime;
        if (Input.GetKeyDown("space")) {       
            MakeEvent();
        }
    }

    
    private void MakeEvent() {
        // ClearEvent();     
        isEvent = true;
        currentGameEvent = GameEventMaker.Instance.MakeEvent();
        // SetGameEvent();
        CalculateAdvantage();         
        EventRaise();
        ClearEvent();
        isEvent = false;
        // gameEvent.Raise();
    }

    private void ClearEvent() {
        // EventParticipants.Clear();
        currentGameEvent = null;
        abilityAdv.Clear();
        heroAdv.Clear();
    }

    // private void SetGameEvent() {
    //     currentGameEvent = GameEventMaker.Instance.CurrentGameEvent[0];
    // }

    private void EventRaise() {
        bool b = CheckIfIncludeMyHero();
        
        if (b == true) {
            SceneManager.LoadScene("GameScene");
            // Sim();
            Debug.Log("My Hero attend");
        } else {
            Debug.Log("Simulation!!!");
            Sim();
            // GameEventData.CalculateResultProp();
            // ApplyEvent();
        }           
    }

    private bool CheckIfIncludeMyHero() {
        for (int i = 0; i < currentGameEvent.Targets.Count; i++) { 
            if (currentGameEvent.Targets[i] == GameSetup.Instance.MyPlayer.Id) {
                Debug.Log("Load Game Scene!!!");
                return true;     
            }
        }
        return false;
    }   

    private void MakeHeroTable() {
        heroTable = new float[totalHeroNum-1, totalHeroNum-1];
    }

    // private Ability GetAbility(string id, float val) {
    //     Ability ability = new Ability();
    //     ability.id = id;
    //     ability.ability_list = new List<float>();

    //     for (int i = 0; i < abilityType.Length + eventAbilityType.Length; i++) {
    //         ability.ability_list.Add(val);
    //     }
    //     return ability;
    // }

    

    // public void Test() {
    //     teamOffensive = new float[2];
    //     teamOffensive[0] = 1f;
    //     teamOffensive[1] = 1f;

    //     indivisualOffensive = new float[10];
    //     for (int i = 0; i < 10; i++) {
    //         indivisualOffensive[i] = 1f;
    //     }
    // }

    // public void Setup(string playerId, int i, Hero hero) {
    //     // gameEvent.Setup(playerId, hero);

    //     // get my team
    //     // MyTeam = Const.BLUE;
    //     // MyHeroLine = Const.MID;
        
    //     // // get team st
    //     // // teamStrategy = new TeamStrategy[2];
    //     // if (playerId == MyHeroId) {
    //     //     MyHero = hero;
    //     // }

    //     if (i <= 4) {
    //         teamStatus[Const.BLUE].Hero[i] = hero;
    //         teamStatus[Const.BLUE].Ability[i] = GetAbility(playerId, 40f);
    //         // blueSideHero[i] = hero;
    //         // blueAbility[i] = GetAbility(playerId, 40f);
    //     } else {
    //         teamStatus[Const.RED].Hero[i-5] = hero;
    //         teamStatus[Const.RED].Ability[i-5] = GetAbility(playerId, 60f);
    //         // redSideHero[i-5] = hero;
    //         // redAbility[i-5] = GetAbility(playerId, 60f);
    //     }

    //     GameEventMaker.Instance.Setup();
    // }

    private void CalculateGrowth() {        
        teamStatus = GameSetup.Instance.teamStatus;

        for (int i = Const.TOP; i <= Const.SPT; i++) {
            float blueAbilityGrowth = 0f;
            float redAbilityGrowth = 0f;
            for (int j = 0; j < abilityType.Length; j++) {
                blueAbilityGrowth += teamStatus[Const.BLUE].Ability[i].ability_list[abilityType[j]];
                redAbilityGrowth += teamStatus[Const.RED].Ability[i].ability_list[abilityType[j]];
            }
            blueAbilityGrowth = blueAbilityGrowth / (blueAbilityGrowth + redAbilityGrowth);
            redAbilityGrowth = 1 - blueAbilityGrowth;

            Debug.Log(teamStatus[Const.BLUE].Hero[i] + " " + teamStatus[Const.RED].Hero[i]);
            float blueHeroGrowth = heroTable[teamStatus[Const.BLUE].Hero[i].HeroData.Id, teamStatus[Const.RED].Hero[i].HeroData.Id];
            float redHeroGrowth = 1 - blueHeroGrowth;

            // float blueVs = heroTable[blueSideHero[i].GetId(), redSideHero[i].GetId()];            
            // float redVs = 1f - blueVs;            
            // Debug.Log(blueVs + " " + redVs);

            blueGrowth[i] = blueAbilityGrowth * abilityRatio + blueHeroGrowth * heroRatio;
            redGrowth[i] = 1 - blueGrowth[i];

            // blueGrowth[i] *= 100f;
            // redGrowth[i] *= 100f;
            
            blueExpGrowth[i] = baseExpGrowth + blueGrowth[i]*expFactor;
            blueGoldGrowth[i] = baseGoldGrowth + (int)(blueGrowth[i]*goldFactor);
            
            redExpGrowth[i] = baseExpGrowth + redGrowth[i]*expFactor;
            redGoldGrowth[i] = baseGoldGrowth + (int)(redGrowth[i]*goldFactor);

        }

    }

    public void StartSimulation() {
        // Debug.Log("Test!!!");
        // Debug.Log(gameEvent.heros[0.ToString()]);
        // Debug.Log(gameEvent.heros[1.ToString()]);
        // Debug.Log(gameEvent.heros[2.ToString()]);
        // Debug.Log(gameEvent.heros[3.ToString()]);
        // for (int i = 0; i < gameEvents.Length; i++) {
        //     Debug.Log(gameEvents[i].heros[0.ToString()]);
        //     Debug.Log(gameEvents[i].heros[1.ToString()]);
        //     Debug.Log(gameEvents[i].heros[2.ToString()]);
        //     Debug.Log(gameEvents[i].heros[3.ToString()]);
        // }

        ClearEvent();
        CalculateGrowth();
        InvokeRepeating("UpdateHero", 1f, 0.5f);
        // GameEventMaker.Instance.Setup();
        // GameEventMaker.Instance.MakeEvent();
        // InvokeRepeating("MakeGameEvent", 1f, 5f);
    }

    public void StopSimulation() {
        Debug.Log("Stop simulation");
    }

    private void UpdateHero() {
        // Debug.Log(currentGameEvent);
        // if (currentGameEvent != null || currentGameEvent.GameEventData != null) {
        //     return;
        // }
        if (isEvent == true) {
            return;
        }

        // Debug.Log("UpdateHero");
        for (int i = Const.TOP; i <= Const.SPT; i++) {
            teamStatus[Const.BLUE].Hero[i].UpdateHero(blueExpGrowth[i], blueGoldGrowth[i]);
            teamStatus[Const.RED].Hero[i].UpdateHero(redExpGrowth[i], redGoldGrowth[i]);
        }
    }

    private void CalculateAdvantage() {
        // List<string> ids = new List<string>();
        // List<float> vals = new List<float>();        
        currentGameEvent.CalculateAdv(abilityAdv, heroAdv);
            // for (int j = 0; j < gameEvent.Targets.Count; j++) {
            //     EventParticipants.Add(gameEvent.Targets[j]);
            // }
            // for (int j = 0; j < gameEvent.Targets.Count; j++) {
                
            // }
            // foreach (string key in gameEvent.AbilityAdv.Keys) {
            //     abilityAdv.Add(key, gameEvent.AbilityAdv[key]);
            //     Debug.Log("Ability adv: " + gameEvent.AbilityAdv[key]);
            // }
            // foreach (string key in gameEvent.HeroAdv.Keys) {
            //     heroAdv.Add(key, gameEvent.HeroAdv[key]);                
            //     Debug.Log("Hero adv: " + gameEvent.HeroAdv[key]);
            // }
        

    }

    const float ABT_MAX = 100f;
    const float HERO_MAX = 100f;
    private void Sim() {
        List<Player> bluePlayer = new List<Player>();
        List<Player> redPlayer = new List<Player>();
        int num = currentGameEvent.Targets.Count;
        float[] adjHeroAdv = new float[num];
        
        int i = 0;
        float tot = 0f;
        float blueTot = 0f;
        float redTot = 0f;
        foreach (string id in abilityAdv.Keys) {
            float abilityVal = abilityAdv[id] / ABT_MAX;            
            float heroVal = heroAdv[id];
            Debug.Log("Ability adv: " + abilityVal);
            Debug.Log("Hero adv: " + heroVal);
            adjHeroAdv[i] = heroVal * abilityVal;
            Debug.Log("adjHeroAdv: " + adjHeroAdv[i]);
            // tot += prop[i];
            Player player = GameSetup.Instance.GetPlayer(id);
            if (player.Team == Const.BLUE) {
                bluePlayer.Add(player);
                blueTot += adjHeroAdv[i];
            } else {
                redPlayer.Add(player);
                redTot += adjHeroAdv[i];
            }
            i++;
        }

        Debug.Log("Blue tot: " + blueTot + ", Red tot: " + redTot);
        float blueWinProp = blueTot / (blueTot + redTot) * currentGameEvent.Time / GameEvent.MAX_TIME;
        float redWinProp =  redTot / (blueTot + redTot) * currentGameEvent.Time / GameEvent.MAX_TIME;
        float nonProp = 1 - blueWinProp - redWinProp;
        Debug.Log("Sim " + blueWinProp + " " + redWinProp + " " + nonProp);         
        
        float[] minProp = new float[3];
        float[] maxProp = new float[3];
        minProp[0] = 0f;
        for (int j = 0; j < 3; j++) {
            if (j != 0) {
                minProp[j] = maxProp[j-1];
            }
            
            float tmp;
            if (j == 0) {
                tmp = blueWinProp;
            } else if (j == 1) {
                tmp = redWinProp;
            } else {
                tmp = nonProp;
            }
            
            maxProp[j] = minProp[j] + tmp;            
        }

        int result = CalculateSimResult(minProp, maxProp);
        int baseValue = 50;
        int amount = baseValue;
        float factor = 100f;
        
        if (blueWinProp >= redWinProp) {
            if (result == 1)
                amount += (int)((blueWinProp - redWinProp) * factor);
        } else {
            if (result == 0) {
                amount += (int)((redWinProp - blueWinProp) * factor);
            }
        }
        
        currentGameEvent.ApplySimResult(result, amount, bluePlayer, redPlayer);        
    }

    private int CalculateSimResult(float[] minProp, float[] maxProp) {
        float rand;
        while (true) {
            rand = Random.Range(0f, 1f);
            if (rand != 1f) {
                break;
            }
        }

        for (int i = 0; i < 3; i++) {
            if (rand >= minProp[i] && rand < maxProp[i]) {
                return i;
            }
        }
        
        return -1;
    }

    public float GetAbilityAdv(string id) {
        return abilityAdv[id];
    }

    

    // public void TakeDamage(Hero hero1, Hero hero2, int dmg1, int dmg2, int time, float rate) {
    //     StartCoroutine(TakeDamageRepeated(hero1, hero2, dmg1, dmg2, time, rate));
    // }

    // int cnt = 0;
    // private IEnumerator TakeDamageRepeated(Hero hero1, Hero hero2, int dmg1, int dmg2, int time, float rate) {
    //     while (cnt++ < time) {
    //         Debug.Log("TakeDamage Count: " + cnt);
    //         bool die1 = hero1.TakeDamage(dmg2);
    //         bool die2 = hero2.TakeDamage(dmg1);
    //         // if (die1 == true || die2 == true) {
    //         //     break;
    //         // }
    //         yield return new WaitForSeconds(rate);
    //     }
        
    //     Debug.Log("Event Done!!!");
    //     cnt = 0;
    //     currentGameEvent = null;
    // }

    // private void Turn() {
    //     // Debug.Log(turn + " " + turnIndex);        
    //     if (turn == true) {
    //         source = blueSideHero[turnIndex].PlayerId;            
    //         PickTarget(redSideHero);
    //     } else {
    //         source = redSideHero[turnIndex].PlayerId;
    //         PickTarget(blueSideHero);
    //     }
        
    //     turnIndex += 1;            
    //     if (turnIndex >= 5) {
    //         turnIndex = 0;
    //     }
    //     turn = !turn;
    // }

    // private void PickTarget(Hero[] targetHero) {
    //     int ran = Random.Range(0,4);
    //     target = targetHero[ran].PlayerId;
    // }

    // private void MakeGameEvent() {
    //     if (currentGameEvent != null) {
    //         return;
    //     }

    //     int ran = Random.Range(0, gameEvents.Length);
    //     // GameEvent event = 
    //     GameEvent gameEvent = gameEvents[ran];
    //     // int line = Random.Range(0, 4);
    //     if (gameEvent != null) {
    //         // gameEvent.Raise(source, target);
    //         gameEvent.Raise();
    //         currentGameEvent = gameEvent;
    //     }
      
    //     // if (turn == true) {
    //     //     gameEvent.EventHappen(blueSideHero[turnIndex], redSideHero);
    //     // } else {
    //     //     gameEvent.EventHappen(redSideHero[turnIndex], blueSideHero);
    //     // }

        
    //     // GameEvent event = gameEvents[ran];
    //     // event.EventHappen();        
    // }

    // public void UpdateIndivisual(float val) {
    //     teamStrategy[MyTeam].UpdateIndivisual(val, MyHeroLine);
    //     // indivisualOffensive[MY_HERO] = val;
    // }

    // public void UpdateTeam(float val) {
    //     teamStrategy[MyTeam].UpdateTeam(val);
    //     // teamOffensive[MY_TEAM] = val;
    // }


}
