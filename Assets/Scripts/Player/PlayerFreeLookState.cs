using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    private readonly int freeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
    private const float animatorDampTime = 0.01f;
    
    public override void Enter()
    {
       
       
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();
        
        _playerStateMachine.CharacterController.Move(movement * (_playerStateMachine.FreeLookMovementSpeed * deltaTime));

        if (_playerStateMachine.InputReader.MovementValue == Vector2.zero)
        {
            _playerStateMachine.Animator.SetFloat(freeLookSpeedHash, 0f, animatorDampTime, deltaTime);
            return;
        }
        _playerStateMachine.Animator.SetFloat(freeLookSpeedHash, 1f, animatorDampTime, deltaTime);
        
        FreeMovementDirection(movement, deltaTime);
        Debug.Log("El valor es " + deltaTime);
        
    }

    public override void Exit()
    {
       
        
    }

    private Vector3 CalculateMovement()
    {
        Vector3 forward = _playerStateMachine.MainCameraTransform.forward;
        Vector3 right = _playerStateMachine.MainCameraTransform.right;
        
        forward.y = 0;
        right.y = 0;
        
        forward.Normalize();
        right.Normalize();

        return forward * _playerStateMachine.InputReader.MovementValue.y +
               right * _playerStateMachine.InputReader.MovementValue.x;
    }


    private void FreeMovementDirection(Vector3 movement, float deltaTime)
    {
        _playerStateMachine.transform.rotation = Quaternion.Lerp(
            _playerStateMachine.transform.rotation, Quaternion.LookRotation(movement), deltaTime * _playerStateMachine.RotationDamping);
    }
    
}
