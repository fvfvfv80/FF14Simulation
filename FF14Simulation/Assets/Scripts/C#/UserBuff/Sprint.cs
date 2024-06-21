


public class Sprint : UserBuff
{
    
    public override string Name { get { return "Sprint"; } }

    public float Boost = 10f;

    public Sprint(User user, int time) : base(user, time) { }

    public override void ActionBegin()
    {
        user.Speed += Boost;
    }
    public override void ActionEnd()
    {
        user.Speed -= Boost;
    }



}
