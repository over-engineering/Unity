using UnityEngine;
using System.Collections.Generic;

public class GameEventMaker : MonoBehaviour
{
    private static GameEventMaker instance;
    public static GameEventMaker Instance { get { return instance; } }
     
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } 
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // [SerializeField] private float blueTeamOffensive;
    // [SerializeField] private float redTeamOffensive;
    // [SerializeField] private float[] blueIndvisualOffensive;
    // [SerializeField] private float[] redIndivisualOffensive;    

    public TeamStrategy[] teamStrategy;
    // [SerializeField] private float totalILine;
    // [SerializeField] private float totalITeamFight;
    // [SerializeField] private float totalTLine;
    // [SerializeField] private float totalTTeamFight;

    // public TeamStatus[] teamStatus;
    // public Ability[] blueAbility;
    // public Ability[] redAbility;    

    // [SerializeField] private int[,] eventAbilityType;
    [SerializeField] private float[] strPerEvent;
    [SerializeField] private float[] eventRaiseProps;
    [SerializeField] private float[] minProp;
    [SerializeField] private float[] maxProp;
    // [SerializeField] private float[] lineProp;

    [SerializeField] private GameEventData[] gameEvents;    
    [SerializeField] private GameEvent currentGameEvent;
    // public List<GameEvent> CurrentGameEvent = new List<GameEvent>();    
    // [SerializeField] private int currentGameEventIndex;
    // public List<string> EventParticipants = new List<string>();
    // public Dictionary<string, float> EventParticipants = new Dictionary<string, float>();

    [SerializeField] private int roaming;
    private const float MAX_STR = 10f;
    // public int MyTeam;
    // public int MyHeroLine;

    void Start() {
        strPerEvent = new float[gameEvents.Length];
        eventRaiseProps = new float[gameEvents.Length];
        minProp = new float[gameEvents.Length];
        maxProp = new float[gameEvents.Length];     
        for (int i = 0; i < gameEvents.Length; i++) {
            if (gameEvents[i].Id == 1) {
                roaming = i;
            }
        }   
        // lineProp = new float[gameEvents.Length];        
    }

    void Update() {
        // if (Input.GetKeyDown("space")) {            
        //     MakeEvent();
        //     // gameEvent.Raise();
        // }

        

    }

    public void Setup() {
        // Set Team
        // teamStrategy = new TeamStrategy[2];
        // teamStatus = new TeamStatus[2];
        

        // MyTeam = Const.BLUE;
        // MyHeroLine = Const.MID;
        // this.teamStrategy = teamStrategy;
        
    }

    public GameEvent MakeEvent() {
        // CalculateTeamStrategy();   
        // ClearGameEvent();     
        CalculateEventRaiseProp();
        GameEvent gameEvent = PickEvent();                
        return gameEvent;
        // currentGameEvent.SelectRaser();

        // return currentGameEvent;
    }

    // private void ClearGameEvent() {
    //     currentGameEventIndex = -1;
    //     CurrentGameEvent.Clear();     
    // }

    // private void CalculateTeamStrategy() {
    //     teamStrategy[Const.BLUE].UpdateTotal();            
    //     teamStrategy[Const.RED].UpdateTotal();            

    //     totalILine = teamStrategy[Const.BLUE].TotalILine + teamStrategy[Const.RED].TotalILine;
    //     totalITeamFight = teamStrategy[Const.BLUE].TotalITeamFight + teamStrategy[Const.RED].TotalITeamFight;
    //     totalTLine = teamStrategy[Const.BLUE].TLine + teamStrategy[Const.RED].TLine;
    //     totalTTeamFight = teamStrategy[Const.BLUE].TTeamFight + teamStrategy[Const.RED].TTeamFight;
    // }

    
    // private float CalculateStrategy() {
    //     float tot = 0f;
    //     for (int k = 0; k < gameEvents.Length; k++) {
    //         float totalIndStr = 0f;
    //         GameEvent gameEvent = gameEvents[k];
    //         for (int j = 0; j < gameEvent.lines.Length; j++) {
    //             int line = lines[j];
    //             totalIndStr += gameEvent.CalculateIndStr(Const.BLUE, j);
    //             totalIndStr += gameEvent.CalculateIndStr(Const.RED, j);
    //         }
    //         strPerEvent[k] = totalIndStr;            
    //         tot += totalIndStr;
    //     }
    // }

    // const float MAX_STR = 10f;
    private void CalculateEventRaiseProp() {
        // float tot = CalculateStrategy();

        // float[] eventProp = new float[gameEvents.Length];
        float tot = 0f;
        for (int k = 0; k < gameEvents.Length; k++) {
            strPerEvent[k] = gameEvents[k].CalculateRaiseProp();
            tot += strPerEvent[k];            
            Debug.Log("CalculateEventProp!!! event prop: " + strPerEvent[k]);
        }
        CalculateProp(tot);        
    }

    private void CalculateProp(float tot) {
        minProp[0] = 0f;
        for (int k = 0; k < gameEvents.Length; k++) {
            eventRaiseProps[k] = strPerEvent[k] / tot;
            strPerEvent[k] /= MAX_STR;
            // strPerEvent[k] /= gameEvents[k].lines.Length;
            if (k != 0) {
                minProp[k] = maxProp[k-1];
            }
            maxProp[k] = minProp[k] + eventRaiseProps[k];
            // Debug.Log("Prop: " + eventRaiseProps[k]);
        }
    }

    private GameEvent PickEvent() {        
        float rand;
        while (true) {
            rand = Random.Range(0f, 1f);
            if (rand != 1f) {
                break;
            }
        }

        // GameEvent gameEvent = null;
        // List<GameEvent> gameEventList = new List<GameEvent>();
        // Debug.Log("Random: " + rand);
        for (int k = 0; k < gameEvents.Length; k++) {
            if (rand >= minProp[k] && rand < maxProp[k]) {
                Debug.Log(gameEvents[k]);
                currentGameEvent = new GameEvent(gameEvents[k]);
                // if (currentGameEvent.GameEventData.Id == 1) { // roaming
                //     TreatRoamingEvent(currentGameEvent);  
                // }
                // gameEvent.SelectRaser();                
                // CurrentGameEvent.Add(gameEvent);
                // currentGameEventIndex++;
                // AddEventParticipant(gameEvent);
                // gameEvents[k].SelectRaser();
                // gameEvent = gameEvents[k];
                break;
                // return gameEvents[k];
            }
        }

       
        return currentGameEvent;

        // 로밍
        // List<GameEvent> gameEventList = new List<GameEvent>();
        
        // return gameEventList;

        // return null;
    }   

    // private void AddEventParticipant(GameEvent gameEvent) {
    //     gameEvent.SelectRaser();

    //     for (int i = 0; i < gameEvent.Targets.Count; i++) {
    //         foreach (string key in gameEvent.AbilityAdv.Keys) {
    //             EventParticipants.Add(gameEvent.Targets[i], );
    //             abilityAdv.Add(key, gameEvent.AbilityAdv[key]);
    //             Debug.Log("Ability adv: " + gameEvent.AbilityAdv[key]);
    //         }
            
    //     }
    // }

    // private void TreatRoamingEvent(GameEvent gameEvent) { 
    //     Debug.Log("TreatRoamingEvent");
       
    //     // UpdateRoamingEventLine();
    //     // CalculateRoamingEventProp();
    //     // CalculateEventRaiseProp();
    //     GameEvent nextGameEvent = gameEvent;
    //     while (true) {            
    //         // GameEvent nextGameEvent = PickEvent();            
    //         // PickEvent();  
    //         UpdateEventLine(roaming, nextGameEvent);        
    //         CalculateEventRaiseProp();          
    //         nextGameEvent = PickSpecificEvent(roaming);            
    //         if (nextGameEvent == null)
    //             break;
    //         AddEventTargets(roaming, nextGameEvent.Targets);
    //         // UpdateEventParticipant();
    //         // if (nextGameEvent.GameEventData.Id == 0 || nextGameEvent.GameEventData.Id == 2) {
    //         // if (CurrentGameEvent[currentGameEventIndex].GameEventData.Id == 0 || CurrentGameEvent[currentGameEventIndex].GameEventData.Id == 2) {
    //         //     // CurrentGameEvent.Add(nextGameEvent);                    
    //         //     break;
    //         // } else if (CurrentGameEvent[currentGameEventIndex].GameEventData.Id == 1) {
    //         //     // CurrentGameEvent.Add(nextGameEvent);
    //         //     UpdateEventLine();
    //         //     CalculateEventRaiseProp();
    //         // }
    //     }        

    //     ResetEventLine(roaming);    
    // }

    // private void AddEventTargets(int k, List<string> targets) {
    //     currentGameEvent.AddTargets(targets);
    // }

    // private void UpdateEventLine(int k, GameEvent gameEvent) {
    //     int sourceLine = gameEvent.RaiseLine + gameEvent.RaiseTeam*5;
    //     int targetLine = gameEvent.TargetLine + gameEvent.TargetTeam*5;        
    //     gameEvents[k].NewSourceLine(sourceLine, targetLine);
    //     // for (int i = 0; i < gameEvents.Length; i++) {
    //     //     if (gameEvents[i].Id == 1) { // romaing 
    //     //         gameEvents[i].NewSourceLine(sourceLine, targetLine);
    //     //     }
            
    //     // }
    // }

    // private GameEvent PickSpecificEvent(int k) {
    //     float minProp = 0f;
    //     float maxProp = minProp + strPerEvent[k];
    //     Debug.Log("Romaing Event Pick Prop: " + minProp + " " + maxProp);
    //     float rand;
    //     while (true) {
    //         rand = Random.Range(0f, 1f);
    //         if (rand != 1f) {
    //             break;
    //         }
    //     }
        
    //     GameEvent gameEvent = null;
    //     if (rand >= minProp && rand < maxProp) {
    //         gameEvent = new GameEvent(gameEvents[k]);
    //         // gameEvent.SelectRaser();
    //         // CurrentGameEvent.Add(gameEvent);
    //         // currentGameEventIndex++;
    //     }

    //     return gameEvent;
    // }

    // private void ResetEventLine(int k) {
    //     // for (int i = 0; i < gameEvents.Length; i++) {
    //     //     gameEvents[i].OriginLine();
    //     // }
    //     gameEvents[k].ResetLine();
    // }

    private void CalculateRoamingEventProp() {

    }

    public void UpdateIndivisual(int type, float val) {
        teamStrategy[GameSetup.Instance.MyPlayer.Team].UpdateIndivisual(type, val, GameSetup.Instance.MyPlayer.Line);
        // indivisualOffensive[MY_HERO] = val;
    }

    public void UpdateTeam(int type, float val) {
        teamStrategy[GameSetup.Instance.MyPlayer.Team].UpdateTeam(type, val);
        // teamOffensive[MY_TEAM] = val;
    }
}