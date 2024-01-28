using System.Collections;
using UnityEngine;

class CutsceneChoiceAction : ChoiceAction
{
    public override void Perform(Player player)
    {
        StartCoroutine(StartCutscene(player));
    }

    IEnumerator StartCutscene(Player player)
    {
        player.HasWon = true;
        player.SetPhysicsEnabled(false);
        CameraFadeout.Instance.InstantBlackScreen();
        yield return new WaitForSeconds(1f);
        CameraFadeout.Instance.FadeOutOfBlack();
        Endscreen.Instance.Show();
        Claw.Instance.gameObject.SetActive(false);
    }
}
