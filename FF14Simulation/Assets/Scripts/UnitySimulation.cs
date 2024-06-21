using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;


public class UnitySimulation : MonoBehaviour
{

    //private EnemyPattern enemyPattern;

    public TimelineDB TimelineDB;

    public float StartTime;
    public float CurTime { get { return Time.time - StartTime; } }

    public TestPool EnemyPatternPool;
   
    public Queue<TimelineData> Timelines;
    public Dictionary<int, Queue<UnityEnemyPattern>> unityEnemyPatternDic;
    
    public void InsertTimelineDB(TimelineDB db)
    {
        TimelineDB = db;
        Timelines= new Queue<TimelineData>();
        foreach (var it in TimelineDB.DataList)
        {
            Timelines.Enqueue(it);
        }




        InitEnemyPattern();

    }

    public async void SimulationStart()
    {
        StartTime = Time.time;

        await Simulate();

    }
    private void Awake()
    {
        EnemyPatternPool = transform.GetComponent<TestPool>();
    }
    private void Update()
    {

    }


    private void InitEnemyPattern()
    {
        unityEnemyPatternDic = new Dictionary<int, Queue<UnityEnemyPattern>>();

        foreach (var it in Timelines)
        {
          
            EnemyPattern enemyPattern = CreateEnemyPattern(it);
            Queue<UnityEnemyPattern> queue = new Queue<UnityEnemyPattern>();

            var unityPatternObj = EnemyPatternPool.ObjectPools[enemyPattern.GetPatternName()].Get();

            var unityPattern = unityPatternObj.GetComponent<UnityEnemyPattern>();
            unityPattern.SetObjectPool(EnemyPatternPool.ObjectPools[enemyPattern.GetPatternName()]);
            unityPattern.SetEnemyPattern(enemyPattern);
            

            if (!unityEnemyPatternDic.ContainsKey(it.GroupId))
                unityEnemyPatternDic.Add(it.GroupId, new Queue<UnityEnemyPattern>());

            unityEnemyPatternDic[it.GroupId].Enqueue(unityPattern);
        }
       
    }
    private async UniTask Simulate()
    {
        
        while (Timelines.Count != 0)
        {
            TimelineData current = Timelines.Peek();
            TimelineData next=current;

            do
            {
                if(Timelines.Count != 0)
                    next = Timelines.Dequeue();
            }
            while (next.GroupId == current.GroupId);
            

            await UniTask.Delay(TimeSpan.FromSeconds(current.CastEndTime - CurTime));


            foreach(var it in unityEnemyPatternDic[current.GroupId])
            {
                it.PatternStart();
            }

            if (Timelines.Count == 0)
                break;
      
            await UniTask.Delay(TimeSpan.FromSeconds(next.CastStartTime - CurTime));
        }
    }


    //abstract & factory? 
    private EnemyPattern CreateEnemyPattern(TimelineData timelineData)
    {
        switch (timelineData.EnemyPatternType)
        {
            case "AOE":
                return new AOE(timelineData);
               

        }

        return null;
    }


}



