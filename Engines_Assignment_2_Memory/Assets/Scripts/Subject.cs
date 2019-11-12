using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class Subject
    {
        // Start is called before the first frame update
        List<Observer> observers = new List<Observer>();

        public void Notify()
        {
            for (int i = observers.Count - 1; i < observers.Count; i++)//updates list of observers to be notified
            {
                observers[i].OnNotify();
            }
        }

        public void NotifyHealth()
        {
            for (int i = observers.Count - 1; i < observers.Count; i++)//updates list of observers to be notified
            {
                observers[i].OnNotifyHealth();
            }
        }

        public void AddObserver(Observer ob)//add a new observer to the list
        {
            observers.Add(ob);
        }

        public void RemoveObserver(Observer ob)//removes observer
        {

        }

        public List<Observer> getObservers()//returns how many observers in the list
        {
            return observers;
        }
    }
}