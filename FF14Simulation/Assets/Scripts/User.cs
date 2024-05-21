using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    private CircleCollider2D _bodyCollider;


    public float Speed = 3f;


    //이것도 클래스화 시키는게 맞나?
    // 버프당 스택은 해당 버프에서 관리?
    public Dictionary<string,UserState> BuffList;


    protected void Start()
    {
        BuffList = new Dictionary<string, UserState>();
        Init();
    }

    protected void Update()
    {
       
        foreach (var state in BuffList)
        {
            Debug.Log(state.Key);
            state.Value.UpdateAction();
            
        }


    }
    public void Init()
    {
        Transform _body = transform.Find("_body");
        _bodyCollider = _body.GetComponent<CircleCollider2D>();


    }

    public void AddBuffState(UserState buff)
    {
       
        BuffList.Add(buff.Name,buff);
        Debug.Log(BuffList.Count);
        buff.ActionBegin();
    }



}





