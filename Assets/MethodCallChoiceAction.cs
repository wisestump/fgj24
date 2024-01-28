using UnityEngine.Events;

class MethodCallChoiceAction : ChoiceAction
{
    public UnityEvent Event;
    public override void Perform(Player player)
    {
        Event.Invoke();
    }
}
