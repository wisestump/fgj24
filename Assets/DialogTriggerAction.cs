class DialogTriggerAction : ChoiceAction
{
    public string name;
    public DialogRunner dialogRunnger;

    void Start()
    {
        
    }

    public void Reset(GameRestarter restarter)
    {
        gameObject.SetActive(true);
    }

    public override void Perform(Player player)
    {
        GameRestarter.Instance.OnRestartTriggered += Reset;
        dialogRunnger.ShowDialogsFor(name);
        gameObject.SetActive(false);
    }
}