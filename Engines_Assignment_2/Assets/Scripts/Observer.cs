using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public abstract class Observer
    {
        public abstract void OnNotify();

    }

    public class EnemyCube : Observer
    {
        GameObject enemy;
        enemyEvents ev;


        public EnemyCube(GameObject enemy, enemyEvents ev)
        {
            this.enemy = enemy;
            this.ev = ev;
        }

        public override void OnNotify()
        {
            scoreUpdate(ev.getScore());
        }

        void scoreUpdate(int score)
        {
            enemy = GameObject.Find("MainCamera");
            enemy.GetComponent<Control>().score += 1;
        }
    }
}