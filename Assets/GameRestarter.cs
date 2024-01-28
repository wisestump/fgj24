using UnityEngine;

class GameRestarter : MonoBehaviour
{
    public InputActions InputActions;
    public ChoiceAction[] Actions;
    public Endscreen Endscreen;


    public static GameRestarter Instance { get; private set; }

    private void Start()
    {
        Debug.Assert(Instance == null);
        Instance = this;
        PerformActions();
        SoundManager.Instance.ResetLevel();
    }

    private void Update()
    {
        if (InputActions.IsRestartActive == false)
            return;
        Restart();
    }

    public void Restart()
    {
        PerformActions();
        Endscreen.Hide();
        CameraFollower.Instance.FollowPlayer = true;
        SoundManager.Instance.ResetLevel();
        Player.Instance.gameObject.GetComponent<Movement>().enabled = true;
        Player.Instance.gameObject.GetComponent<Movement>().rb.isKinematic = false;
        Player.Instance.gameObject.GetComponent<Movement>().DisableJetpack();
    }

    private void PerformActions()
    {
        foreach (var a in Actions)
            a.Perform(Player.Instance);
    }
}
