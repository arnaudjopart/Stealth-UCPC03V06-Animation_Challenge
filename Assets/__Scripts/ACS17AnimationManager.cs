using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ACS17AnimationManager : MonoBehaviour
{
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_currentMode = EnemyNav.eMode.idle;
    }

    public EnemyNav m_enemyNav;

    private Animator m_animator;

    private EnemyNav.eMode m_currentMode;
    // Read public mode and turnDir information from EnemyNav on parent GameObject
    // Try using anim.CrossFade("ACS_Walk", 0);

    private void Update()
    {
        
        switch (m_enemyNav.mode)
        {
            case EnemyNav.eMode.idle:
                if (m_currentMode == EnemyNav.eMode.idle) return;
                m_currentMode = EnemyNav.eMode.idle;
                m_animator.CrossFade("ACS_Idle",0.25f);
                break;
            case EnemyNav.eMode.wait:
                if (m_currentMode == EnemyNav.eMode.wait) return;
                m_currentMode = EnemyNav.eMode.wait;
                m_animator.CrossFade("ACS_Idle",0.25f);
                break;
            case EnemyNav.eMode.preMoveRot:
                if (m_currentMode == EnemyNav.eMode.preMoveRot) return;
                m_currentMode = EnemyNav.eMode.preMoveRot;
                m_animator.CrossFade(m_enemyNav.turnDir == -1 ? "ACS_TurnLeft" : "ACS_TurnRight", 0.25f);
                break;
            case EnemyNav.eMode.move:
                if (m_currentMode == EnemyNav.eMode.move) return;
                m_currentMode = EnemyNav.eMode.move;
                m_animator.CrossFade("ACS_Walk",0.25f);
                break;
            case EnemyNav.eMode.postMoveRot:
                if (m_currentMode == EnemyNav.eMode.postMoveRot) return;
                m_currentMode = EnemyNav.eMode.postMoveRot;
                m_animator.CrossFade(m_enemyNav.turnDir == -1 ? "ACS_TurnLeft" : "ACS_TurnRight", 0.25f);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
