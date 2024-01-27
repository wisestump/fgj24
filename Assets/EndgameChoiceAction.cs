class EndgameChoiceAction : ChoiceAction
{
    public Endscreen endscreen;

    public override void Perform(Player player)
    {
        endscreen.Show();
    }
}
