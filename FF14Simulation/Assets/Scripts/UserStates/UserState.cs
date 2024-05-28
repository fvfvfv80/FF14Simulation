using UnityEngine;

public class UserState
{
    
    private Sprite _icon;   //ui�̹�����
    private float _time;

    protected User _user;

    public string Name { get; set; } 

    public UserState(User user, float time, Sprite img)
    {
        this._user = user;
        this._time = time;
        this._icon = img;
    }
    public virtual void ActionBegin() { }
    public virtual void Action() { }
    public virtual void ActionEnd() { }


    public string UpdateAction()
    {
        if (_time > 0)
        {
            Action();
        }
        else
        {
            ActionEnd();

            Debug.Log(this + " FINISH");

            //�ݹ�??��Ʈ���� �ϸ� ����Ʈ���� �ڵ����� ������ٴ� �ູ�� �����
            //_user.BuffList.Remove(Name);
            return Name;
        }
        _time -= Time.deltaTime;
        Debug.Log(this + " Left: " + _time);

        return "";
    }
}