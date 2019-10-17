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
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].OnNotify();
            }
        }

        public void AddObserver(Observer ob)
        {
            observers.Add(ob);
        }

        public void RemoveObserver(Observer ob)
        {

        }

        public List<Observer> getObservers()
        {
            return observers;
        }
    }
}