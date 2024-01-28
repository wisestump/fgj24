using System.Collections.Generic;
using UnityEngine;

class DialogRunner : MonoBehaviour
{
    public Phrases Phrases;

    public void ShowDialogsFor(string zone)
    {
        var zoneP = Phrases.Parse()[zone];
    }
}

class Phrases : MonoBehaviour
{
    Transform plushie = null;
    public Transform claw = null;
    Transform narrator = null;
    Dictionary<string, List<Phrase>> pairs;

    private void Start()
    {
        plushie = Player.Instance.transform;
        narrator = Player.Instance.transform;
        pairs = Parse();
    }


    public Dictionary<string, List<Phrase>> Parse()
    {
        var phrases = new Dictionary<string, List<Phrase>>
        {
            {
                "PROLOGUE",
                new List<Phrase>()
                {
                    new Phrase(0, narrator, "Plushie is one of the few remaining stuffed toys left in the Claw Cave.", 0.5f),
                    new Phrase(1, narrator, "No one wants to leave a good friend hanging around. But one by one, Plushie's friends have clawed their way out.", 0.5f),
                    new Phrase(2, narrator, "Plushie decides on a great escape.", 0.5f),
                }
            },
            {
                "ARCADE",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "Stop moving and I'll claw you back into my arms.", 0.5f),
                    new Phrase(1, plushie, "Watch me outpun you!", 0.5f),
                }
            },
            {
                "SPACE 1",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "All suited up with no space to go.", 0.5f),
                    new Phrase(1, plushie, "That's a one star pun, Claw. Now, get outer my space.", 0.5f),
                }
            },
            {
                "SEWER 1",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "Ready for a poop joke?", 0.5f),
                    new Phrase(1, plushie, "Nope, they stink", 0.5f),
                }
            },
            {
                "SPACE 2",
                new List<Phrase>()
                {
                    new Phrase(0, plushie, "These puns are pointing us in the right direction.", 0.5f),
                    new Phrase(1, claw, "Do you want me to give you a hand?", 0.5f),
                    new Phrase(2, plushie, "Not a meteor chance.", 0.5f),
                }
            },
            {
                "GROUND 1",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "Don't be a buzzkill, Plushie. Let's swat it out!", 0.5f),
                    new Phrase(1, plushie, "Don't worry, I'm just here to wing it", 0.5f),
                }
            },
            {
                "SEWER 2",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "Your fart knocked the wind out of me.", 0.5f),
                    new Phrase(1, plushie, "Don't mind me. I'm just blowing off some steam", 0.5f),
                    new Phrase(2, claw, "I'm flushed with embarrassment.", 0.5f),
                }
            },
            {
                "SPACE 3",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "I’m running out of space puns.", 0.5f),
                    new Phrase(1, plushie, "Well, you need to planet better.", 0.5f),
                }
            },
            {
                "GROUND 2",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "You are not buzzworthy at all, Plushie", 0.5f),
                    new Phrase(1, plushie, "That's because I bring it down to Earth... with a splat.", 0.5f),
                }
            },
            {
                "GROUND 3",
                new List<Phrase>()
                {
                    new Phrase(0, plushie, "Oh dear, there is a lot of ground to cover", 0.5f),
                    new Phrase(1, claw, "Don’t trust the stairs, they are always up to something!", 0.5f),
                    new Phrase(2, plushie, "I'm not taking any chance for granite.", 0.5f),
                }
            },
            {
                "SEWER 3",
                new List<Phrase>()
                {
                    new Phrase(0, narrator, "missing", 0.5f),
                    new Phrase(1, narrator, "missing", 0.5f),
                }
            },
            {
                "ENDING 1",
                new List<Phrase>()
                {
                    new Phrase(0, narrator, "Congratulations! You have won a Constellation prize.", 0.5f),
                    new Phrase(1, narrator, "A one-way trip to the Black Hole.", 0.5f),
                }
            },
            {
                "ENDING 2",
                new List<Phrase>()
                {
                    new Phrase(0, narrator, "missing", 0.5f),
                    new Phrase(1, narrator, "missing", 0.5f),
                }
            },
            {
                "ENDING 3",
                new List<Phrase>()
                {
                    new Phrase(0, narrator, "Congratulations! You have arrived at Rock Bottom.", 0.5f),
                    new Phrase(1, narrator, "It takes a boulder attitude to be here.", 0.5f),
                }
            },
            {
                "ENDING 4",
                new List<Phrase>()
                {
                    new Phrase(0, narrator, "Congratulations! You are now a member of an elite group Sewer-side Squad that has reached the bottom of the Earth.", 0.5f),
                    new Phrase(1, narrator, "It's a real “poop”ular spot.", 0.5f),
                }
            },
            {
                "GAME OVER",
                new List<Phrase>() { new Phrase(0, claw, "I always claw my way to victory.", 0.5f), }
            }

        };
        return phrases;
    }

    //    Dictionary<string, List<Phrase>> Parse(string textRaw)
    //{

    //    //var dtimeAddition = 2f;
    //    Dictionary<string, List<Phrase>> result = new Dictionary<string, List<Phrase>>()
    //    {
    //        { "str", new List<Phrase>() },
    //    };
    //    List<Phrase> phrases = new List<Phrase>();
    //    var regex = new Regex("^[\".],^[.\"]");
    //    var text = textRaw.Split("\n").Select(x => regex.Split(x));
    //    var zone = "";
    //    var dtime = 0f;
    //    foreach (var str in text)
    //    {
    //        var phrase = new Phrase();
    //        if (!string.IsNullOrEmpty(str[0]))
    //        {
    //            zone = str[0];
    //            dtime = 0;
    //            result[zone] = new List<Phrase>();
    //        }
    //        phrase.Actor = MapActor(str[1]);
    //        phrase.Dtime = dtime;
    //        phrase.Text = str[2];
    //        phrase.Duration = str[2].Length * 0.05f;
    //        dtime += phrase.Duration + 0.3f;
    //        result[zone].Add(phrase);
    //    }

    //    return result;
    //}
}
