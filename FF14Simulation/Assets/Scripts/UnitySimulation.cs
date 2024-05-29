using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySimulation : MonoBehaviour
{
    
    public float StartTime;
    public float CurTime { get { return Time.time - StartTime; } }
    public float endTime;

    public Queue<Timeline> timelines;


    public void SimulationStart()
    {
        StartTime = Time.time;
        StartCoroutine(Simulate());

    }

    private void Update()
    {
        
    }

    IEnumerator Simulate()
    {
        while(timelines.Count!=0)
        {
            Timeline current = timelines.Dequeue();
            Timeline next = timelines.Peek();



            yield return new WaitForSeconds(next.StartTime-CurTime);

        }
        


        yield return null;
    }
}
