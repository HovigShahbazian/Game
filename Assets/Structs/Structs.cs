
using UnityEngine;

public struct NPCStats
{
    public int Strength;
    public int Dexterity;
    public int Constution;
    public int Intellgence;
    public int Wisdom;
    public int Charisma;
}


public struct Mission
{
    public MissionType missionType;
    public bool CompleteFlag;
    public int progress;

}


[System.Serializable]
public struct Job_Task
{
    NPC_Task_Type type;
    float taskTime;
    float cur_progress;
}


[System.Serializable]
public struct Town
{
    public string name;
    public float food;
    public int Population;
    public int wealth;
    public int Metals;
    public int stone;
    public int fuel;
    public int oil;


    public StatsLevel techLevel;
    public StatsLevel ScienceLevel;
    public StatsLevel EducationLevel;

    public StatsLevel transportationLevel;
    public StatsLevel GovernmentLevel;
    public StatsLevel Securitylvl;

    public StatsLevel fooddistributionLevel;
    public StatsLevel Healthlvl;

    public StatsLevel medecineLevel;
}

[System.Serializable]
public class WorldNode
{
    Site worldNodeType;
    Geography enviromentNodeType;
}


[System.Serializable]
public struct Person
{
  
}

[System.Serializable]
public struct PersonInteraction
{
    int Person;
    int Peron;
    int UpdateValue;
    int UpdateStatEnum;
}

[System.Serializable]
public struct Building
{
 
}

[System.Serializable]
public struct TownInteraction
{
    public string Source;
    public string Effected;
    public NodeInteraction nodeInteraction;
    public TownStats stat;
    public int UpdateValue;
}



public struct TownTimerUpdate
{
    float timeLeft;
    float TimeMax;
    string townName;
    int UpdateValue;
    int UpdateStatEnum;
}
