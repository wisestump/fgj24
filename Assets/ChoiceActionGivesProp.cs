class ChoiceActionGivesProp : ChoiceAction
{
    public enum PropType
    {
        Swatter, 
        FartCloud,
        Finger,
        SpaceSuit,
    }

    public PropType Prop;

    public override void Perform(Player player)
    {
        switch (Prop)
        {
            case PropType.Swatter:
                player.SetSwatterActive(true);
                break;
            case PropType.FartCloud:
                player.SetFartCloudActive(true);
                break;
            case PropType.Finger:
                player.SetFoamFingerActive(true);
                break;
            case PropType.SpaceSuit:
                player.SetSpaceHelmetActive(true);
                break;
        }
    }
}