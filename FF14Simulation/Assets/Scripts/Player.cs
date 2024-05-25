using UnityEngine;



public class Player : User
{
     


    private void Start()
    {
        base.Start();
        Init();
    }

    private void Update()
    {
        base.Update();
        Play();
    }

    private void Init()
    {
        

    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


    public void Play()
    {
        Movment();
        //쿨타임 적용시킬건가?
        Run();
    }
    private void Movment()
    {
        float inputX = Input.GetAxis("Vertical");
        float inputY = Input.GetAxis("Horizontal");
        float curSpeed = Speed;
        if (inputX * inputX + inputY * inputY > 1)
            curSpeed = Speed/1.141f;
   
        transform.Translate(new Vector2(0, inputX) * curSpeed * Time.deltaTime);
        transform.Translate(new Vector2(inputY, 0) * curSpeed * Time.deltaTime);


    }

    private void Run()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddBuffState(new Sprint(this, 10));
            Debug.Log("startRun");
        }
    }



}
