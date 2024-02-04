class DialogTriggerAction : ChoiceAction
{
    public string name;
    public DialogRunner dialogRunnger;

    void Start()
    {
        
    }

    public void Reset(GameRestarter restarter)
    {
        enabled = true;
    }

    public override void Perform(Player player)
    {
        if (enabled == false)
            return;

        GameRestarter.Instance.OnRestartTriggered += Reset;
        dialogRunnger.ShowDialogsFor(name);
        enabled = false;
    }
}