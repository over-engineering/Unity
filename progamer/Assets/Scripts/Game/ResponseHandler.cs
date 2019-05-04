// using UnityEngine;
// using System.Collections.Generic;

// public static class ResponseHandler
// {
//     private static Dictionary<string, Hero> heros = new Dictionary<string, Hero>();

//     public static void Setup(string id, Hero hero) {
//         // if (turn == true) {
//         //     blueSideHero.Add(id, hero);
//         // } else {
//         //     redSideHero.Add(id, hero);
//         // }
//         Debug.Log("Setup!!! " + id + " " + hero);
//         heros.Add(id, hero);
//     }

//     public static void AttackDamage(string source, string target) {
//         Debug.Log("TakeDamageEvent!!!, Source: " + heros[source].PlayerId + ", Target: " + heros[target].PlayerId);
//         heros[target].TakeDamage(heros[source].HeroData.AttackDamage);        
//     }

//     public static void LevelUp(string source, string target) {
//         Debug.Log(source + " LevelUp!!!");
//     }

// }