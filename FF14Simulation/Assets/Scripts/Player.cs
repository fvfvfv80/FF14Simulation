using UnityEngine;



public class Player : User, IPlayable
{
    
    public void Play()
    {

        Movment();
        //쿨타임 적용시킬건가?
        Run();
    }

    private void Movment()
    {
        transform.Translate(new Vector2(0, Input.GetAxis("Vertical")) * Speed * Time.deltaTime);
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0) * Speed * Time.deltaTime);
    }

    private void Run()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddBuffState(new Sprint(this, 10));
            Debug.Log("startRun");
        }
    }

    private void Update()
    {
        base.Update();
        Play();
    }

}
