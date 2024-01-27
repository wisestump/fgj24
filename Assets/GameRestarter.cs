using UnityEngine;

class GameRestarter : MonoBehaviour
{
    public InputActions InputActions;
    public ChoiceAction[] Actions;
    public Endscreen Endscreen;

    private void Start()
    {
        PerformActions();
    }

    private void Update()
    {
        if (InputActions.IsRestartActive == false)
            return;
        PerformActions();
        Endscreen.Hide();
    }

    private void PerformActions()
    {
        foreach (var a in Actions)
            a.Perform(Player.Instance);
    }
}
