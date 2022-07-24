using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) { }
    
    public override void Enter()
    {
       
       
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();
        movement.x = _playerStateMachine.InputReader.MovementValue.x;
        movement.y = 0;
        movement.z = _playerStateMachine.InputReader.MovementValue.y;
        _playerStateMachine.transform.Translate(movement * deltaTime);
    }

    public override void Exit()
    {
       
        
    }

    private void OnJump()
    {
       
    }
    
}
