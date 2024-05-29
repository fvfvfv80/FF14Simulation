using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

[CreateAssetMenu(fileName = "TimelineDB", menuName = "Scriptable Objects/TimelineDB")]
public class TimelineDB : DataBaseSO<TimelineData>
{
    protected override string JsonPath => "Assets/Json/test.json";

    public override void DataInit(string jContent)
    {
        DataList = new List<TimelineData>();
        JsonTimelineDatas dList = JsonUtility.FromJson<JsonTimelineDatas>(jContent);

        foreach (var it in dList.data)
        {
            DataList.Add(it);
        }
    }
}

