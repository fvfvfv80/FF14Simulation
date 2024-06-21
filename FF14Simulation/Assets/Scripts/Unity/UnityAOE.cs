using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class UnityAOE : UnityEnemyPattern
{
    private AOE aoeData;
    private UnityPlayer player;

    public Transform _dangerZone;
    
    //
    private float observeableTime=3f;
    private bool isIn;
    //

    public int TargetCount
    {
        get
        {
            int cnt = 0;
            foreach (var it in targetColliderList)
            {
                //말고 다른거
                if (hitBox.IsTouching(it))
                    cnt++;
            }

            return cnt;
        }
    }

    public UnityAOE() { }


    public UnityAOE(UnityPlayer player , float baseDamage,float delay,float observeableTime)
    {
        this.player = player;
        
        this.BaseDamage = baseDamage;

    }
    //dbdata투입
    public UnityAOE(UnityPlayer player)
    {
        this.player = player;
       
    }

    public UnityAOE(UnityPlayer player, EnemyPattern enemyPattern)
    {
        this.player = player;  

    }


    private void Awake()
    {
        base.Awake();
        Init();
        
    }
    private async void Start()
    {
      
        
    }
    private void Init()
    {
        _dangerZone = transform.Find("_dangerZone");
        _dangerZone.gameObject.SetActive(false);
        isIn = false;
    }

    public override void SetEnemyPattern(EnemyPattern pattern)
    {
        aoeData = pattern as AOE;
      //  _dangerZone.transform.localScale.;
    }

    public override async void PatternStart()
    {
        await RunAOE();
    }

    public override GameObject CreateItem(GameObject obj)
    {
        GameObject prefab = Instantiate(obj);

        return prefab;
    }

    public override void OnGetItem(GameObject obj)
    {
        obj.SetActive(true);

    }

    public override void OnReleaseItem(GameObject obj)
    {
        obj.SetActive(false);
    }

    public override void OnDestroyItem(GameObject obj)
    {
        Destroy(obj);
    }


    private async UniTask RunAOE()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(aoeData.Delay));

        _dangerZone.gameObject.SetActive(true);
        await UniTask.Delay(TimeSpan.FromSeconds(observeableTime));
        if (isIn)
        {
            Debug.Log("Damaged!!");
            player.GetAttacked(aoeData.DamageType.Damage(3f, 2));
        }

        _dangerZone.gameObject.SetActive(false);


        pool.Release(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isIn = true;
        }
        if(aoeData.DamageType is ShareDamageType)
        {
            if (collision.gameObject.CompareTag("User"))
            {
                targetColliderList.Add(collision);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isIn = false;                       
        }
        if (aoeData.DamageType is ShareDamageType)
        {
            if (collision.gameObject.CompareTag("User"))
            {
                targetColliderList.Remove(collision);
            }
        }
    }
}
