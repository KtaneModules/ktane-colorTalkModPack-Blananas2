using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class CrazyTalkWithAK : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable[] WeedChungi;
    public TextMesh Weedisplay;
    public TextMesh[] Weednumbers;
    public KMSelectable Hacheejay;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    string Fugly = "/abcdefghijklmnopqrstuvwxyz";
    int Sugna = 0;
    int Blangivemeanotherintegername = 0;
    int Idontfuckingknow = 0;
    int TurnTheKeys = 0;
    int SillySluts = 6;
    int Topdisplay = 9;

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable Weed in WeedChungi) {
            Weed.OnInteract += delegate () { WeedChungiPress(Weed); return false; };
        }
        Hacheejay.OnInteract += delegate () { PressSugma(); return false; };
    }
    void Start () {
      Sugna = UnityEngine.Random.Range(0,AKFortySevenTalk.Phrases.Count());
      Blangivemeanotherintegername = UnityEngine.Random.Range(0,AKFortySevenTalk.Phrases.Count());
      Weedisplay.text = AKFortySevenTalk.Phrases[Sugna] + "\n" + AKFortySevenTalk.Phrases[Blangivemeanotherintegername];
      for (int i = 0; i < AKFortySevenTalk.Phrases[Sugna].Length; i++) {
        for (int j = 0; j < 27; j++) {
          if (Fugly[j] == AKFortySevenTalk.Phrases[Sugna].ToLower()[i]) {
            Idontfuckingknow += j;
          }
        }
      }
      Debug.LogFormat("[Crazy Talk With A K #{0}] The sum of the first phrase's letters are {1}.", moduleId, Idontfuckingknow);
      for (int i = 0; i < AKFortySevenTalk.Phrases[Blangivemeanotherintegername].Length; i++) {
        for (int j = 0; j < 27; j++) {
          if (Fugly[j] == AKFortySevenTalk.Phrases[Blangivemeanotherintegername].ToLower()[i]) {
            TurnTheKeys += j;
          }
        }
      }
      Debug.LogFormat("[Crazy Talk With A K #{0}] The sum of the second phrase's letters are {1}.", moduleId, TurnTheKeys);
      Idontfuckingknow *= TurnTheKeys;
      Idontfuckingknow %= 100;
      if (Bomb.GetSerialNumberNumbers().Last() > 0) {
        Idontfuckingknow *= Bomb.GetSerialNumberNumbers().Last();
      }
      Idontfuckingknow %= 100;
      if (Bomb.GetBatteryCount() > 0) {
        Idontfuckingknow *= Bomb.GetBatteryCount();
      }
      Idontfuckingknow %= 100;
      Debug.LogFormat("[Crazy Talk With A K #{0}] The top phrase is {1}.", moduleId, AKFortySevenTalk.Phrases[Sugna]);
      Debug.LogFormat("[Crazy Talk With A K #{0}] The top phrase is {1}.", moduleId, AKFortySevenTalk.Phrases[Blangivemeanotherintegername]);
      Debug.LogFormat("[Crazy Talk With A K #{0}] The final number is {1}.", moduleId, Idontfuckingknow);
	}
	void WeedChungiPress (KMSelectable Weed) {
    Weed.AddInteractionPunch();
    GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Weed.transform);
    if (Weed == WeedChungi[0]) {
      SillySluts += 1;
      if (SillySluts > 9) {
        SillySluts %= 10;
      }
      Weednumbers[0].text = SillySluts.ToString();
    }
    else if (Weed == WeedChungi[1]) {
      SillySluts -= 1;
      if (SillySluts < 0) {
        SillySluts += 10;
      }
      Weednumbers[0].text = SillySluts.ToString();
    }
    else if (Weed == WeedChungi[2]) {
      Topdisplay += 1;
      if (Topdisplay > 9) {
        Topdisplay %= 10;
      }
      Weednumbers[1].text = Topdisplay.ToString();
    }
    else if (Weed == WeedChungi[3]) {
      Topdisplay -= 1;
      if (Topdisplay < 0) {
        Topdisplay += 10;
      }
      Weednumbers[1].text = Topdisplay.ToString();
    }
	}
  void PressSugma(){
    Hacheejay.AddInteractionPunch();
    GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Hacheejay.transform);
    if ((SillySluts * 10) + Topdisplay == Idontfuckingknow) {
      GetComponent<KMBombModule>().HandlePass();
      Audio.PlaySoundAtTransform("was-that-the-bite-of-87-sound-effect", transform);
      Debug.LogFormat("[Crazy Talk With A K #{0}] You submitted {1}. Module disarmed.", moduleId, Idontfuckingknow);
      Weedisplay.text = "Crazy Talk\nWith A K";
    }
    else {
      GetComponent<KMBombModule>().HandleStrike();
      Debug.LogFormat("[Crazy Talk With A K #{0}] You submitted {1}. Strike, although I don't care enough about this mod so you don't get a condescending message.", moduleId, (SillySluts * 10) + Topdisplay);
    }
  }
}
