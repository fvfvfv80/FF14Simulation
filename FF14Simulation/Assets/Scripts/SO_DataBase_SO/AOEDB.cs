using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AOEDB", menuName = "Scriptable Objects/AOEDB")]
public class AOEDB : DataBaseSO<AOEData>
{
    protected override string JsonPath => "Assets/Json/AOE.json";

    public override void DataInit(string jContent)
    {
        DataList = new List<AOEData>();
        JsonAOEDatas dList = JsonUtility.FromJson<JsonAOEDatas>(jContent);

        foreach (var it in dList.data)
        {
            DataList.Add(it);
        }
    }
}
