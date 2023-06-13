using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //几号玩家
    public int PlayerIndex;
    //玩家移动速度
    public float MoveSpeed;
    //玩家移动方向
    private Vector2 MoveDirection;
    private Rigidbody2D _rigidbody2D;

    private InputAndRumbleManager _inputAndRumbleManager;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Dash()
    {
        var InputManagers = FindObjectsOfType<InputAndRumbleManager>();
        _inputAndRumbleManager = InputManagers.FirstOrDefault(m => m.GetInputPlayerIndex() == PlayerIndex);
        _inputAndRumbleManager.RumblePluse(0.25f,0.75f,0.5f);
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(MoveDirection.x * MoveSpeed, _rigidbody2D.velocity.y);
    }

    public void SetPlayerDirection(Vector2 input)
    {
        MoveDirection = input;
    }

    public int GetPlayerIndex()
    {
        return PlayerIndex;
    }

}
