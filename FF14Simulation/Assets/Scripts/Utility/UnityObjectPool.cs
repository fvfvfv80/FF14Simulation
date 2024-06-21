using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public interface IPoolable
{
    public void SetObjectPool(IObjectPool<GameObject> objectPool);
    public GameObject CreateItem(GameObject obj);

    public void OnGetItem(GameObject obj);

    public void OnReleaseItem(GameObject obj);

    public void OnDestroyItem(GameObject obj);
}

public class UnityObjectPool<T> : MonoBehaviour where T : MonoBehaviour , IPoolable
{
    public List<T> poolablePrefabList;

    public Dictionary<string, IObjectPool<GameObject>> ObjectPools;

    private void Awake()
    {
        ObjectPools= new Dictionary<string, IObjectPool<GameObject>>();
    }

    private void Start()
    {
        foreach(var it in poolablePrefabList)
        {
            IObjectPool<GameObject> pool = new ObjectPool<GameObject>(()=>it.CreateItem(it.gameObject), it.OnGetItem, it.OnReleaseItem, it.OnDestroyItem);
          
            ObjectPools.Add(it.gameObject.name, pool);
        }
        
    }
}




/*
 * 
 * using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public interface IPoolable
{

}

public abstract class UnityObjectPool<T> : MonoBehaviour where T : MonoBehaviour 
{
    protected T poolablePrefab;

    public IObjectPool<T> ObjectPool;

    private void Awake()
    {
        ObjectPool = new ObjectPool<T>(Create, OnGet, OnRelease, OnDestroy);

    }

    public abstract T Create();

    public abstract void OnGet(T obj);

    public abstract void OnRelease(T obj);

    public abstract void OnDestroy(T obj);
}


public class UnityAOEPool:UnityObjectPool<UnityAOE>
{
    public override UnityAOE Create()
    {
        GameObject obj = Instantiate(poolablePrefab.gameObject);
        return obj.GetComponent<UnityAOE>();

    }

    
}
 * */