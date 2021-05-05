


using UnityEngine;

[System.Serializable]
public struct NPCStats
{
    [Range(0,100)]
    public int Strength;
    public int Dexterity;
    public int Constution;
    public int Intellgence;
    public int Wisdom;
    public int Charisma;
}

[System.Serializable]
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
public class Town
{
    public const SiteType _type = SiteType.Town;

    public SiteName name;
    public float food;
    public int Population;
    public int Metals;
    public int stone;
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
    SiteType worldNodeType;
    Geography enviromentNodeType;
}


[System.Serializable]
public class Person
{
    public string name = "jeff";
    public NPCStats nPCStats;
    public NPC_Job _Job;
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
public class TownInteraction
{
    public SiteName Source;
    public SiteName Effected;
    public NodeInteraction nodeInteraction;
    public SiteStats stat;
    public int UpdateValue;
}

