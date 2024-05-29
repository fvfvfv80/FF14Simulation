using System.Collections.Generic;
using UnityEngine;

public class TestGame : MonoBehaviour
{
    public TimelineDB timelineDB;
  
    void Start()
    {
        timelineDB.ParseJsonData();
        Debug.Log("DB DoTest Check\n TimelineDBCount: "+timelineDB.DataList.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }
   

    
}
