using UnityEngine;



public class Player : User
{

    public Vector2 Fowrad;

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
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        
        float curSpeed = Speed;

        Fowrad = new Vector2(inputX, inputY);

   
        transform.Translate(Fowrad * curSpeed * Time.deltaTime);
       


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
