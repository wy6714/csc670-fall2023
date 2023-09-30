using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    //collection of all observers
    private List<IObserver> observerList = new List<IObserver>();

    //add observer to the list(subject collections)
    public void AddObservor(IObserver observer)
    {
        observerList.Add(observer);
    }

    //remove observer from the list(subject collections)
    public void RemoveObserver(IObserver observer)
    {
        observerList.Remove(observer);
    }

    //notify each observer that event happens
    public void NotifyObservers(Actions actions)
    {
        observerList.ForEach(observer => observer.OnNotify(actions));

        //foreach (var observer in observerList)
        //{
        //    observer.OnNotify(actions);
        //}
    }
}
