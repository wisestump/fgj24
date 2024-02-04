class ChoiceActionRemovesSwimming : ChoiceAction
{
    public override void Perform(Player player)
    {
        player.SetSwimming(false);
    }
}
