using System.Collections.Generic;
using UnityEngine;

//����
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

    //�̰͵� Ŭ����ȭ ��Ű�°� �³�?
    // ������ ������ �ش� �������� ����?
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





