using UnityEngine;

public class UnityPlayer : UnityUser
{
    public Vector2 Fowrad;

    private CircleCollider2D bodyCollider;

    protected override void Init()
    {
        //Is it Right?
        user = new Player();
        user.Init();
    }

    protected override void UnityInit()
    {
        base.UnityInit();
        bodyCollider = _body.GetComponent<CircleCollider2D>();
    }

    protected void Start()
    {
        base.Start();
        
    }

    protected void Update()
    {
        base.Update();
        Play();
    }

    public void Play()
    {
        Movment();

        Run();
    }
    private void Movment()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        float curSpeed = user.Speed;

        Fowrad = new Vector2(inputX, inputY);

        transform.Translate(Fowrad * curSpeed * Time.deltaTime);

    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            user.AddBuff(new Sprint(user, 10));
            Debug.Log("startRun");
        }
    }

    public void GetAttacked(float Damage)
    {

    }

}
