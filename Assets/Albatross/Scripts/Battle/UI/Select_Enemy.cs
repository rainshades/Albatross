﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Albatross
{
    public class Select_Enemy : MonoBehaviour, IPointerClickHandler
    {
        TurnManager tm;
        SpellManager sm;
        public MonsterObject TargetMon;
        MonsterObject currentMon;
        public GameObject CanvasToTurnOff;

        void Start()
        {
            CanvasToTurnOff = transform.parent.gameObject;
            tm = FindObjectOfType<TurnManager>();
            sm = FindObjectOfType<SpellManager>();
            currentMon = tm.getCurrentMonster();
        }

        public void OnPointerClick(PointerEventData PE)
        {
            switch (tm.getAction())
            {
                case Action.Attack:
                    currentMon.AttackTarget(TargetMon);
                    tm.CanvasOff(CanvasToTurnOff);
                    Debug.Log(currentMon.name + " attacked " + TargetMon);
                    tm.EndTurn();
                    break;

                case Action.ActiveAbility:
                    Debug.Log("Ability the target");
                    if (currentMon.canTarget())
                    {
                        currentMon.ActivateAbility(TargetMon);
                        Debug.Log(currentMon.name + " used their ability on " + TargetMon);
                        tm.EndTurn();
                    }
                    else
                    {
                        currentMon.ActivateAbility();
                        Debug.Log(currentMon.name + " used their ability");
                        tm.EndTurn();
                    }
                    break;
                case Action.Cast:
                    Debug.Log("Cast " + sm.getCurrentSpell().name + " on " + TargetMon);
                    sm.getCurrentSpell().CastToTarget(TargetMon);
                    tm.EndTurn();
                    break;
                case Action.Defend:
                    Debug.Log("Defended Yourself");
                    tm.EndTurn();
                    break;
            }
        }
    }
}