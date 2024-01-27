using System;
using UnityEngine;

class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event Action<Panel> OnPanelChange;

    public Panel CurrentPanel { get; private set; }

    private void Awake()
    {
        Debug.Assert(Instance == null);
        Instance = this;
    }

    public void SetPanel(Panel panel)
    {
        CurrentPanel = panel;
        OnPanelChange?.Invoke(panel);
    }
}