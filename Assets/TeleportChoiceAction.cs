class TeleportChoiceAction : ChoiceAction
{
    public Panel Target;

    public override void Perform(Player player)
    {
        player.transform.position = Target.PlayerStartingPoint;
        player.SetPanel(Target);
    }
}