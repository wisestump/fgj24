using UnityEngine;

class Choice : MonoBehaviour
{
    public BoxCollider2D BoxCollider2D;
    [HideInInspector] public ChoiceAction[] ChoiceAction;

    private void Start()
    {
        this.ChoiceAction = GetComponents<ChoiceAction>();
    }

    private void Update()
    {
        if (BoxCollider2D.OverlapPoint(Player.Instance.transform.position))
        {
            foreach (var action in ChoiceAction)
                action.Perform(Player.Instance);
        }
    }
}
