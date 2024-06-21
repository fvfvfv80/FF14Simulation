using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public abstract class UnityEnemyPattern : MonoBehaviour, IPoolable 
{
    protected Collider2D hitBox;
    protected List<Collider2D> targetColliderList;
    //protected T enemyPattern;    //AOE, TankBurst , exa , ±âµÕ, ¼±,º¸½º¼±, ³Ë¹é 
    public float BaseDamage;
    protected IObjectPool<GameObject> pool;



    //  public static Dictionary<string, IObjectPool<GameObject>> ObjectPool;

  
    protected void Awake()
    {
        Init();
    }

    private void Init()
    {
        hitBox = transform.GetComponent<Collider2D>();
        targetColliderList = new List<Collider2D>();




    }

    public abstract void PatternStart();

    public abstract void SetEnemyPattern(EnemyPattern pattern);

    public void SetObjectPool(IObjectPool<GameObject> pool)
    {
        this.pool = pool;   
    }

    public abstract GameObject CreateItem(GameObject obj);

    public abstract void OnGetItem(GameObject obj);

    public abstract void OnReleaseItem(GameObject obj);

    public abstract void OnDestroyItem(GameObject obj);
}
