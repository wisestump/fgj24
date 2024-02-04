class ChoiceActionRemovesFlying : ChoiceAction
{
    public override void Perform(Player player)
    {
        player.DisableJetpack();
    }
}
