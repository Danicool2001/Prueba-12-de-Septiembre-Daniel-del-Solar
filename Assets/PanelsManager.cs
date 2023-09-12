using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsManager : MonoBehaviour
{
    public string initialIdentifier;
    public List<Container> containers;
    private string actualIdentifier;

    private void OnEnable()
    {
        SwitchPanel(initialIdentifier);
    }

    public void SwitchPanel(string newIdentifier)
    {
        if (actualIdentifier == newIdentifier) return;
        actualIdentifier = newIdentifier;

        foreach(Container container in containers)
        {
            if (container.identifier == newIdentifier) container.panel.Open();
            else container.panel.Close();
        }
    }
}
