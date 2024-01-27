using UnityEngine;

class GameRestarter : MonoBehaviour
{
    public InputActions InputActions;
    public ChoiceAction Action;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (InputActions.IsRestartActive == false)
            return;

        Action.Perform(Player.Instance);
    }
}
