
using System.Collections.Generic;
using UnityEngine;

public class TestGame : MonoBehaviour
{
    //版肺电 胶怕平捞电 构电
    public TimelineDB timelineDB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timelineDB.ParseJsonData();
        Debug.Log(timelineDB.DataList[4].name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
