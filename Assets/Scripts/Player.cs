using System;
using UnityEngine;

class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event Action<Panel> OnPanelChange;

    public Panel CurrentPanel { get; private set; }
    public Movement Movement { get; private set; }

    private void Awake()
    {
        Debug.Assert(Instance == null);
        Instance = this;
        Movement = GetComponent<Movement>();
    }

    private void Start()
    {
        CameraFollower.Instance.Player = gameObject;
    }

    public void SetPanel(Panel panel)
    {
        CurrentPanel = panel;
        OnPanelChange?.Invoke(panel);
    }

    public void EnableJetpack()
    {
        Movement.EnableJetpack();
    }
    public void SetPhysicsEnabled(bool value)
    {
        Movement.enabled = value;
        Movement.rb.isKinematic = !value;
        Movement.rb.gravityScale = 0;
        Movement.rb.velocity = Vector2.zero;
        Movement.ResetAnimation();
    }
}