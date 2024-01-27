using UnityEngine;

class GameRestarter : MonoBehaviour
{
    public InputActions InputActions;
    public ChoiceAction Action;
    public Endscreen Endscreen;

    private void Start()
    {
        Action.Perform(Player.Instance);
    }

    private void Update()
    {
        if (InputActions.IsRestartActive == false)
            return;

        Action.Perform(Player.Instance);
        Endscreen.Hide();
    }
}
