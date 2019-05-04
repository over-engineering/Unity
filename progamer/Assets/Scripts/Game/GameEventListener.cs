// using UnityEngine;
// using UnityEngine.Events; 
// using System.Collections.Generic;

// [System.Serializable]
// public class CustomEvent : UnityEvent<string, string>
// {
// }

// public class GameEventListener : MonoBehaviour
// {
//     private Dictionary<GameEvent, CustomEvent> gameEventResponse = new Dictionary<GameEvent, CustomEvent>();
//     [SerializeField] private List<GameEvent> gameEvents = new List<GameEvent>(); 
//     // [SerializeField] private List<CustomEvent> responses = new List<CustomEvent>();
//     // private Dictionary<string, Hero> blueSideHero = new Dictionary<string, Hero>();
//     // private Dictionary<string, Hero> redSideHero = new Dictionary<string, Hero>();
//     // private Dictionary<string, Hero> heros = new Dictionary<string, Hero>();
//     // [SerializeField] private List<Hero> blueSideHero;
//     // [SerializeField] private List<Hero> redSideHero; 

//     private void OnEnable() 
//     {        
//         for (int i = 0; i < gameEvents.Count; i++) {
//             gameEvents[i].RegisterListener(this);
//             CustomEvent response = new CustomEvent();            
//             response.AddListener(gameEvents[i].func);
//             // responses.Add(response);
//             gameEventResponse.Add(gameEvents[i], response);
//         }     
//     }

//     private void OnDisable() 
//     {
//         for (int i = 0; i < gameEvents.Count; i++) {            
//             gameEvents[i].UnregisterListener(this);
//             // responses[i].RemoveListener(gameEvents[i].func);
//             gameEventResponse.Remove(gameEvents[i]);
//         }             
//         // gameEvent.UnregisterListener(this);
//         // response.RemoveListener(gameEvent.func);
//     }

//     public void OnEventRaised(GameEvent gameEvent, string source, string target)
//     {
//         gameEventResponse[gameEvent].Invoke(source, target);
//         // response.Invoke(source, target);
//     }
// }