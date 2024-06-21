using System.Collections.Generic;
using UnityEngine;

public class TestGame : MonoBehaviour
{
    public TimelineDB timelineDB;
    public UnitySimulation ff14Simulation;
    private void Awake()
    {
        ff14Simulation = GameObject.Find("Simulation").GetComponent<UnitySimulation>();
        


    }
    void Start()
    {
        timelineDB.ParseJsonData();
        Debug.Log("DB DoTest Check\n TimelineDBCount: "+timelineDB.DataList.Count);
        ff14Simulation.InsertTimelineDB(timelineDB);
        ff14Simulation.SimulationStart();

    }

    // Update is called once per frame
    void Update()
    {

    }
   

    
}
