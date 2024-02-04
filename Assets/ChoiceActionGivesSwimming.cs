class ChoiceActionGivesSwimming : ChoiceAction
{
    public override void Perform(Player player)
    {
        player.SetSwimming(true);
    }
}
