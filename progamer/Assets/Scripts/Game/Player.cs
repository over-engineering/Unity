using UnityEngine;

[System.Serializable]
public class Player
{
    public string Id;
    public Ability Ability;
    public Hero Hero;
    public int Team;
    public int Line;
    
    public Player(string id, Ability a, int team, int line) {
        this.Id = id;
        this.Ability = a;
        // this.Hero = h;
        this.Team = team;
        this.Line = line;
    }
}