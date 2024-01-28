using UnityEngine;
using System;

class GameRestarter : MonoBehaviour
{
    public InputActions InputActions;
    public ChoiceAction[] Actions;
    public Endscreen Endscreen;


    public event Action<GameRestarter> OnRestartTriggered;
    public static GameRestarter Instance { get; private set; }

    private void Start()
    {
        Debug.Assert(Instance == null);
        Instance = this;
        PerformActions(Player.Instance);
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
        var player = Player.Instance;
        if (player.HasWon)
        {
            Destroy(player.gameObject);
            player = PlayerSpawner.Instance.SpawnNewPlayer();
        }
        PerformActions(player);
        Endscreen.Hide();
        CameraFollower.Instance.FollowPlayer = true;
        SoundManager.Instance.ResetLevel();
        player.gameObject.GetComponent<Movement>().enabled = true;
        player.gameObject.GetComponent<Movement>().rb.isKinematic = false;
        player.gameObject.GetComponent<Movement>().DisableJetpack();
        OnRestartTriggered?.Invoke(this);
        Claw.Instance.gameObject.SetActive(true);
    }

    private void PerformActions(Player player)
    {
        foreach (var a in Actions)
            a.Perform(player);
    }
}
