using System.Collections.Generic;

//¿¹Á¤
public class JobClass
{
    protected string Name;

}

public class Healer : JobClass
{

}
//

public class User
{

    public float Speed = 3f;
    public string Name;
    public JobClass Job;

    protected Dictionary<string, UserBuff>[] _userBuffLists;
    public Dictionary<string, UserBuff> BuffList;
    public Dictionary<string, UserBuff> DebuffList;

    public virtual void Init()
    {
        BuffList = new Dictionary<string, UserBuff>();
        DebuffList = new Dictionary<string, UserBuff>();

        _userBuffLists = new Dictionary<string, UserBuff>[2];
        _userBuffLists[0] = BuffList;
        _userBuffLists[1] = DebuffList;
    }

    private void AddUserBuff(Dictionary<string, UserBuff> list , UserBuff buff)
    {
        list.Add(buff.Name, buff);
        
        buff.ActionBegin();
    }

    public void AddBuff(UserBuff buff)
    {
        AddUserBuff(BuffList, buff);
    }

    public void AddDeBuff(UserBuff buff)
    {
        AddUserBuff(DebuffList, buff);
    }



    public void BuffUpdate()
    {
        foreach(var list in _userBuffLists)
        {
            List<string> removeList = new List<string>();
            foreach (var state in list)
            {
                

                string str = state.Value.UpdateAction();
                if (str != "")
                    removeList.Add(str);

            }
            foreach (var str in removeList)
            {
                list.Remove(str);
            }
        }
       
    }

}





