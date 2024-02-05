using System.Collections;
using UnityEngine;

class CutsceneChoiceAction : ChoiceAction
{
    public DialogRunner DialogRunner;
    public string DialogLine;

    public override void Perform(Player player)
    {
        StartCoroutine(StartCutscene(player));
    }

    IEnumerator StartCutscene(Player player)
    {
        player.HasWon = true;
        player.SetPhysicsEnabled(false);
        Claw.Instance.gameObject.SetActive(false);
        CameraFadeout.Instance.InstantBlackScreen();
        yield return new WaitForSeconds(1f);
        CameraFadeout.Instance.FadeOutOfBlack();
        yield return new WaitForSeconds(8f);
        DialogRunner.ShowDialogsFor(DialogLine);
        yield return new WaitForSeconds(6f);
        Endscreen.Instance.Show();
    }
}
