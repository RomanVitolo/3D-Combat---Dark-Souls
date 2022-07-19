using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
   protected PlayerStateMachine _playerStateMachine;

   public PlayerBaseState(PlayerStateMachine stateMachine)
   {
      this._playerStateMachine = stateMachine;
   }
}
