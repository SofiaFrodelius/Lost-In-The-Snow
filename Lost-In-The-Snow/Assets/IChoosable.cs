using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IChoosable : IEventSystemHandler
{
    void choose1();
    void choose2();

}
