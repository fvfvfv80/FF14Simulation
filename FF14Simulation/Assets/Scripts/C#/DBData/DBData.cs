using System;

public class DBData
{
    public string Id;
    public string name;

}


[Serializable]
public class TimelineData : DBData
{

    public int GroupId;

    public int CastStartTime;
    public int CastEndTime;

    public string EnemyPatternType;
    public int EnemyPatternID;

    public int TargetType;
    public int TargetVal;

}

public class JsonTimelineDatas
{
    public TimelineData[] data;
}


[Serializable]
public class AOEData : DBData
{
    public string ZoneType;
    public string DmgType;

    public float LenW;
    public float LenH;
    public float Rot;

    public float Delay;

    public float Dmg;
}

public class JsonAOEDatas
{
    public AOEData[] data;
}