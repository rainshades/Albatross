﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Albatross
{

    [CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]
    public class Monster : Entity
    {
        public new string name;

        public MonAbility passive;

        public string description;

        public int attack;
        public int health;
        public int defence;
        public int mana; 
        public int speed;

        public Sprite artwork;
        public bool alive;

        public override void Damage(MonsterObject mon)
        {
            mon.health -= attack;
        }
    }
}