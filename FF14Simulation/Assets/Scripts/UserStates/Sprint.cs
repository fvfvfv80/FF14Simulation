using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Sprint:UserState
{
    public float Boost = 10f;
    public Sprint(User user, int time, Sprite img = null) : base(user, time, img) { Name = "Sprint"; }
    public override void ActionBegin()
    {
        _user.Speed += Boost;
    }
    public override void ActionEnd()
    {
        _user.Speed -= Boost;
    }

    
   
}
