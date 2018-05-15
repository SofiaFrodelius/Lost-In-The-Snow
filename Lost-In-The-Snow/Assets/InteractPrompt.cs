using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPrompt : MonoBehaviour
{
    [SerializeField]
    private List<Text> promptToToggle;

    public void promptToggle(bool toggle)
    {
        for(int i = 0; i < promptToToggle.Count; i++)
        {
            promptToToggle[i].enabled = toggle;
        }
    }

    public void promptToggleSpecific(bool toggle, int id)
    {
        promptToToggle[id].enabled = toggle;
    }

    public void removePrompt(int id)
    {
        promptToToggle.RemoveAt(id);
    }
}
