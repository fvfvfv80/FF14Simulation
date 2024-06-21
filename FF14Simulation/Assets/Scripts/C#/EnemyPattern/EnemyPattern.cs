using System;



public class EPatternTarget
{
    public EPatternTarget(int val)
    { }
}

public class PosTarget:EPatternTarget
{
    public PosTarget(int targetVal) : base(targetVal) { }
}

public class UserTarget:EPatternTarget
{
    public UserTarget(int targetVal) : base(targetVal) { }
}

public abstract class IDamageType
{
    public abstract float GetDamage(EnemyPattern pattern);

    public abstract float Damage(float baseDamage, int targetCnt);
}

public class SimpleDamageType : IDamageType
{
    public override float GetDamage(EnemyPattern pattern)
    {
        return pattern.BaseDamage;
    }
    public override float Damage(float baseDamage, int targetCnt)
    {
        throw new NotImplementedException();
    }
}

public class ShareDamageType : IDamageType
{
    public static ShareDamageType ShareType;
    public override float GetDamage(EnemyPattern pattern)
    {
        return 3f;// pattern.BaseDamage/1+pattern.TargetCount;
    }
    public override float Damage(float baseDamage, int targetCnt)
    {
        throw new NotImplementedException();
    }
}

public abstract class EnemyPattern 
{
    //private EnemyPatternType patternType;
    //protected EPatternTarget target;

    protected int patternId;


    public float BaseDamage;

    public IDamageType DamageType;
    public EnemyPattern(TimelineData tData)
    {
      

        //target = SetPatternTarget(tData.TargetType,tData.TargetVal);

        DamageType = ShareDamageType.ShareType;

    }

    public abstract EPatternTarget SetPatternTarget(int targetType, int option);


    public abstract string GetPatternName();
}

public class AOE : EnemyPattern
{

    public float Delay=2f;
    public AOE(TimelineData data) : base(data) 
    {

    }

    public override EPatternTarget SetPatternTarget(int targetType, int option)
    {
        switch (targetType)
        {
            case 0:
                return new PosTarget(option);
            case 1:
                return new UserTarget(option);
        }
        return null;
    }


    public override string GetPatternName()
    {
        return "AOE";
    }
}








