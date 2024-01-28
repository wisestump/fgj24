using System.Collections.Generic;
using System.Collections;
using UnityEngine;


class Phrases : MonoBehaviour
{
    public Transform plushie = null;
    public Transform claw = null;
    public Transform narrator = null;
    Dictionary<string, List<Phrase>> pairs;

    private void Start()
    {
        pairs = Parse();
    }

    private void Update()
    {
        if(Player.Instance != null)
        {
            plushie = Player.Instance.transform;
            narrator = Player.Instance.transform;
        }
    }


    public Dictionary<string, List<Phrase>> Parse()
    {
        var phrases = new Dictionary<string, List<Phrase>>
        {
            {
                "PROLOGUE",
                new List<Phrase>()
                {
                    new Phrase(0, narrator, "narrator", "Plushie is one of the few remaining stuffed toys left in the Claw Cave.", 0.9f),
                    new Phrase(1, narrator, "narrator", "No one wants to leave a good friend hanging around. But one by one, Plushie's friends have clawed their way out.", 0.9f),
                    new Phrase(2, narrator, "narrator", "Plushie decides on a great escape.", 0.9f),
                }
            },
            {
                "ARCADE",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "claw", "Stop moving and I'll claw you back into my arms.", 0.9f),
                    new Phrase(1, plushie, "plushie", "Watch me outpun you!", 0.9f),
                }
            },
            {
                "SPACE 1",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "claw", "All suited up with no space to go.", 0.9f),
                    new Phrase(1, plushie, "plushie", "That's a one star pun, Claw. Now, get outer my space.", 0.9f),
                }
            },
            {
                "SEWER 1",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "claw", "Ready for a poop joke?", 0.9f),
                    new Phrase(1, plushie, "plushie", "Nope, they stink", 0.9f),
                }
            },
            {
                "SPACE 2",
                new List<Phrase>()
                {
                    new Phrase(0, plushie, "plushie", "These puns are pointing us in the right direction.", 0.9f),
                    new Phrase(1, claw, "claw", "Do you want me to give you a hand?", 0.9f),
                    new Phrase(2, plushie, "plushie", "Not a meteor chance.", 0.9f),
                }
            },
            {
                "GROUND 1",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "claw", "Don't be a buzzkill, Plushie. Let's swat it out!", 0.9f),
                    new Phrase(1, plushie, "plushie", "Don't worry, I'm just here to wing it", 0.9f),
                }
            },
            {
                "SEWER 2",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "claw", "Your fart knocked the wind out of me.", 0.9f),
                    new Phrase(1, plushie, "plushie", "Don't mind me. I'm just blowing off some steam", 0.9f),
                    new Phrase(2, claw, "claw", "I'm flushed with embarrassment.", 0.9f),
                }
            },
            {
                "SPACE 3",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "claw", "I’m running out of space puns.", 0.9f),
                    new Phrase(1, plushie, "plushie", "Well, you need to planet better.", 0.9f),
                }
            },
            {
                "GROUND 2",
                new List<Phrase>()
                {
                    new Phrase(0, claw, "claw", "You are not buzzworthy at all, Plushie", 0.9f),
                    new Phrase(1, plushie, "plushie", "That's because I bring it down to Earth... with a splat.", 0.9f),
                }
            },
            {
                "GROUND 3",
                new List<Phrase>()
                {
                    new Phrase(0, plushie, "plushie", "Oh dear, there is a lot of ground to cover", 0.9f),
                    new Phrase(1, claw, "claw", "Don’t trust the stairs, they are always up to something!", 0.9f),
                    new Phrase(2, plushie, "plushie", "I'm not taking any chance for granite.", 0.9f),
                }
            },
            {
                "SEWER 3",
                new List<Phrase>()
                {
                    new Phrase(0, narrator, "narrator", "missing", 0.9f),
                    new Phrase(1, narrator, "narrator", "missing", 0.9f),
                }
            },
            {
                "ENDING 1",
                new List<Phrase>()
                {
                    new Phrase(0, narrator, "narrator", "Congratulations! You have won a Constellation prize.", 0.9f),
                    new Phrase(1, narrator, "narrator", "A one-way trip to the Black Hole.", 0.9f),
                }
            },
            {
                "ENDING 2",
                new List<Phrase>()
                {
                    new Phrase(0, narrator, "narrator", "missing", 0.9f),
                    new Phrase(1, narrator, "narrator", "missing", 0.9f),
                }
            },
            {
                "ENDING 3",
                new List<Phrase>()
                {
                    new Phrase(0, narrator, "narrator", "Congratulations! You have arrived at Rock Bottom.", 0.9f),
                    new Phrase(1, narrator, "narrator", "It takes a boulder attitude to be here.", 0.9f),
                }
            },
            {
                "ENDING 4",
                new List<Phrase>()
                {
                    new Phrase(0, narrator, "narrator", "Congratulations! You are now a member of an elite group Sewer-side Squad that has reached the bottom of the Earth.", 0.9f),
                    new Phrase(1, narrator, "narrator", "It's a real “poop”ular spot.", 0.9f),
                }
            },
            {
                "GAME OVER",
                new List<Phrase>() { new Phrase(0, claw, "claw", "I always claw my way to victory.", 0.9f), }
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
