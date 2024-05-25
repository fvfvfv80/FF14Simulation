using System.Collections.Generic;
using UnityEngine;

//예정
public class JobClass
{
    protected string Name;

}

public class Healer: JobClass
{

}
//

public class User : MonoBehaviour
{
    protected Transform _body;
    private CircleCollider2D _bodyCollider;


    public float Speed = 3f;
    public string Name;
    public JobClass Job;

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
    private void Init()
    {
        _body = transform.Find("_body");
        _bodyCollider = _body.GetComponent<CircleCollider2D>();

    }

    public void AddBuffState(UserState buff)
    {
       
        BuffList.Add(buff.Name,buff);
        Debug.Log(BuffList.Count);
        buff.ActionBegin();
    }



}





