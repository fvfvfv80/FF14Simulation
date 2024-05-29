using System;
using UnityEngine;

public class DBData
{
    public string id;
    public string name;

}


[Serializable]
public class TimelineData : DBData
{

    public int GroupId;
    public int StartTime;

}

public class JsonTimelineDatas
{
    public TimelineData[] data;
}
