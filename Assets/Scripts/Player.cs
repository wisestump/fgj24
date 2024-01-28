using System;
using UnityEngine;

class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event Action<Panel> OnPanelChange;

    public Panel CurrentPanel { get; private set; }
    public Movement Movement { get; private set; }

    public bool HasWon { get; set; }
    public JetpackProp Jetpack;
    public GameObject SpaceHelmet;
    public GameObject DivingMask;
    public GameObject FoamFinger;
    public GameObject Swatter;
    public GameObject FartCloud;

    private void Awake()
    {
        Instance = this;
        Movement = GetComponent<Movement>();
    }

    private void Start()
    {
        CameraFollower.Instance.Player = gameObject;
        // SetDivingMaskActive(true);
        // SetFartCloudActive(true);
    }

    public void SetPanel(Panel panel)
    {
        CurrentPanel = panel;
        OnPanelChange?.Invoke(panel);
    }

    public void EnableJetpack()
    {
        Movement.EnableJetpack();
        Jetpack.gameObject.SetActive(true);

    }

    public void DisableJetpack()
    {
        Movement.DisableJetpack();
        Jetpack.gameObject.SetActive(false);

    }

    public void SetSpaceHelmetActive(bool value) => SpaceHelmet.SetActive(value);
    public void SetDivingMaskActive(bool value) => DivingMask.SetActive(value);
    public void SetFoamFingerActive(bool value) => FoamFinger.SetActive(value);
    public void SetSwatterActive(bool value) => Swatter.SetActive(value);
    public void SetFartCloudActive(bool value) => FartCloud.SetActive(value);
    
    public void DisableAllProps()
    {
        DisableJetpack();
        SetSpaceHelmetActive(false);
        SetDivingMaskActive(false);
        SetFoamFingerActive(false);
        SetSwatterActive(false);
        SetFartCloudActive(false);
    }

    public bool Has1UP()
    {
        return FartCloud.activeSelf || FoamFinger.activeSelf || Swatter.activeSelf;
    }

    public bool Use1UP()
    {
        if(Has1UP())
        {
            SetFoamFingerActive(false);
            SetSwatterActive(false);
            SetFartCloudActive(false);
            return true;
        }
        return false;
    }

    public void SetPhysicsEnabled(bool value)
    {
        Movement.enabled = value;
        Movement.rb.isKinematic = !value;
        Movement.rb.gravityScale = 0;
        Movement.rb.velocity = Vector2.zero;
        Movement.SetStandAnimation();
    }
}