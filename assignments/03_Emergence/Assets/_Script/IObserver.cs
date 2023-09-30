using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver 
{
    //subject use this interface to communicate with the observer
    public void OnNotify(Actions actions);
}
