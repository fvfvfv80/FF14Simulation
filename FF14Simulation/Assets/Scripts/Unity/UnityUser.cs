using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class UnityUser : MonoBehaviour
{
    public User user;
    protected Transform _body;

   

    private void Awake()
    {
        //network
     
    }
    //For individual
    protected virtual void Init()
    {
        user = new User();
        user.Init();
    }
    //For Gruop
    protected virtual void UnityInit()
    {
        _body = transform.Find("_body");
    }

    protected void Start()
    {
        Init();
        UnityInit();
       
    }



    protected void Update()
    {
        user.BuffUpdate(Time.deltaTime);
    }
}
