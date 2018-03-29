using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IDogHandler : IEventSystemHandler , IInteractible{
    void Pet();

}
