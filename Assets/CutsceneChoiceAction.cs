class CutsceneChoiceAction : ChoiceAction
{
    public override void Perform(Player player)
    {
        player.SetPhysicsEnabled(false);
    }
}
