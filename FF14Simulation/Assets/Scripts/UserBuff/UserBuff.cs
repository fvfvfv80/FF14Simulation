using System.Collections.Generic;
using UnityEngine;

public abstract class UserBuff
{
   // public static Dictionary<string, UserBuff> UserBuffs;
    private float time;

    protected User user;

    public abstract string Name { get; }

    public UserBuff(User user, float time)
    {
        this.user = user;
        this.time = time;
      
    }
    public virtual void ActionBegin() { }
    public virtual void Action() { }
    public virtual void ActionEnd() { }


    public string UpdateAction()
    {
        if (time > 0)
        {
            Action();
        }
        else
        {
            ActionEnd();

            Debug.Log(this + " FINISH");

            return Name;
        }
        time -= Time.deltaTime;
        Debug.Log(this + " Left: " + time);

        return "";
    }
}