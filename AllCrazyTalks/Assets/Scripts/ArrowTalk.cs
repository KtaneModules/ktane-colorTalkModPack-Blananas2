using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using KModkit;

public class ArrowTalk : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable[] fats;
    private List<float[]> efponupnijudrpiju = new List<float[]>{
      new float[]{180f,0f},
      new float[]{180f,0f},
      new float[]{0f,180f},
      new float[]{0f,180f},
      new float[]{270f,90f},
      new float[]{270f,90f},
      new float[]{90f,270f},
      new float[]{90f,270f}
    };
    public TextMesh Candela;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    bool[] FUCKGODDAMNIT = new bool[8];
    bool[] something = new bool[8];
    int FUCK = 0;
    string FUCKbutasastring = "";
    int shitsucker = 0;
    string whateverthehell = "";
    bool ColoredSwitches = false;
    bool BlanHasNowAlsoBecomeRetardedHelp = false;
    bool pp = false;

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable fat in fats) {
            fat.OnInteract += delegate () { fatPress(fat); return false; };
        }
    }

    void Start () {
      while(FUCK == 0){
      for (int i = 0; i < 8; i++) {
        FUCK = FUCK * 10 + UnityEngine.Random.Range(0,2);
      }
    }
      FUCKbutasastring = FUCK.ToString();
      while(FUCKbutasastring.Length < 8){
        FUCKbutasastring = "0" + FUCKbutasastring;
      }
      Debug.LogFormat("<Arrow Talk #{0}> The starting rotations with 1 being turned and 0 being correct is {1} (in the order given in the manual).", moduleId, FUCKbutasastring.Replace("\n"," "));
      for (int i = 0; i < 8; i++) {
        if (FUCKbutasastring[i] == '1') {
          fats[i].transform.Rotate(0f,180f,0f);
          FUCKGODDAMNIT[i] = !FUCKGODDAMNIT[i];
        }
      }
      StartCoroutine(lkiukgtijuyhjhgftjuyhghmtijuyk());
	}
	void fatPress(KMSelectable fat) { //BBL BBR TTL TTR TML BML TMR BMR
    for (int i = 0; i < 8; i++) {
      if (moduleSolved == true) {
        Candela.text = "Arrow\nTalk";
        return;
      }
      else if (fat == fats[i]) {
        if (fats[shitsucker] != fats[i]) {
          GetComponent<KMBombModule>().HandleStrike();
          Debug.LogFormat("[Arrow Talk #{0}] You pressed an arrow that should not have been pressed. Strike, lardlass.", moduleId);
          ColoredSwitches = true;
        }
          if (something[i]) {
            return;
          }
          if (ColoredSwitches == false && BlanHasNowAlsoBecomeRetardedHelp == false) {
            Audio.PlaySoundAtTransform("OhHeyIFoundJewelVault", transform);
            FUCKbutasastring = FUCKbutasastring.Substring(0,shitsucker) + "0" + FUCKbutasastring.Substring(shitsucker + 1);
            FUCKGODDAMNIT[i] = !FUCKGODDAMNIT[i];
            StartCoroutine(FUCUCUCUCUK(fats[i]));
            StartCoroutine(lkiukgtijuyhjhgftjuyhghmtijuyk());
          }
          else if (ColoredSwitches == false && BlanHasNowAlsoBecomeRetardedHelp == true) {
            Audio.PlaySoundAtTransform("OhHeyIFoundJewelVault", transform);
            FUCKbutasastring = FUCKbutasastring.Substring(0,shitsucker) + "1" + FUCKbutasastring.Substring(shitsucker + 1);
            FUCKGODDAMNIT[i] = !FUCKGODDAMNIT[i];
            StartCoroutine(FUCUCUCUCUK(fats[i]));
            StartCoroutine(GuysBlanHasBecomeFerralHelp());
          }
          else {
            ColoredSwitches = false;
          }
      }
    }
  }
  IEnumerator FUCUCUCUCUK(KMSelectable fat){
    var x = Array.IndexOf(fats,fat);
    something[x] = true;
    var elapsed = 0f;
    var duration = 2.04f;
    var endrotation = !moduleSolved ? (FUCKGODDAMNIT[x] ? efponupnijudrpiju[x][0] : efponupnijudrpiju[x][1]) : efponupnijudrpiju[x][1];
    var startroationfadsa = !moduleSolved ? (FUCKGODDAMNIT[x] ? efponupnijudrpiju[x][1] : efponupnijudrpiju[x][0]) : fat.transform.localEulerAngles.y;
    while (elapsed < duration){
      fat.transform.localEulerAngles = new Vector3(0f, Mathf.Lerp(startroationfadsa, endrotation, elapsed / duration), 0f);
      yield return null;
      elapsed += Time.deltaTime;
    }
    something[x] = false;
  }
  IEnumerator lkiukgtijuyhjhgftjuyhghmtijuyk(){
    shitsucker = UnityEngine.Random.Range(0,8);
    for (int i = 0; i < 8; i++) {
      if (FUCKbutasastring[i] == '1') {
        while(FUCKbutasastring[shitsucker] == '0'){
          shitsucker = UnityEngine.Random.Range(0,8);
        }
      }
      if (FUCKbutasastring == "00000000") {
        BlanHasNowAlsoBecomeRetardedHelp = true;
        StartCoroutine(GuysBlanHasBecomeFerralHelp());
      }
    }
    if (moduleSolved == false) {
      switch (shitsucker) {
        case 0:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(0,6)];
        break;
        case 1:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(7,12)];
        break;
        case 2:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(13,18)];
        break;
        case 3:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(19,24)];
        break;
        case 4:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(25,30)];
        break;
        case 5:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(31,36)];
        break;
        case 6:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(37,42)];
        break;
        case 7:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(43,48)];
        break;
        default:
        Candela.text = "Arrow\nTalk";
        break;
      }
    }
    else{
      yield return null;
    }
    Debug.LogFormat("[Arrow Talk #{0}] The screen says \"{1}\".", moduleId, Candela.text.Replace("\n"," "));
    yield return null;
  }
  IEnumerator GuysBlanHasBecomeFerralHelp(){
    shitsucker = UnityEngine.Random.Range(0,8);
    for (int i = 0; i < 8; i++) {
      if (FUCKbutasastring[i] == '0') {
        while(FUCKbutasastring[shitsucker] == '1'){
          shitsucker = UnityEngine.Random.Range(0,8);
        }
      }
      if (FUCKbutasastring == "11111111") {
        GetComponent<KMBombModule>().HandlePass();
        moduleSolved = true;
        foreach (KMSelectable fat in fats) {
          StartCoroutine(FUCUCUCUCUK(fat));
        }
        StartCoroutine(Imeanwhyevenbother());
        Candela.text = "Arrow\nTalk";
        yield return null;
      }
    }
    if (moduleSolved == false) {
      switch (shitsucker) {
        case 0:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(0,6)];
        break;
        case 1:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(7,12)];
        break;
        case 2:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(13,18)];
        break;
        case 3:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(19,24)];
        break;
        case 4:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(25,30)];
        break;
        case 5:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(31,36)];
        break;
        case 6:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(37,42)];
        break;
        case 7:
        Candela.text = ArrowFuck.Phrases[UnityEngine.Random.Range(43,48)];
        break;
        default:
        Candela.text = "Arrow\nTalk";
        break;
      }
    }
    else {
      yield return null;
    }
    Debug.LogFormat("[Arrow Talk #{0}] The screen says \"{1}\".", moduleId, Candela.text.Replace("\n"," "));
    yield return null;
  }
  IEnumerator Imeanwhyevenbother(){
    if (!pp) {
      Debug.LogFormat("[Arrow Talk #{0}] All the arrows point inwards. Module disarmed.", moduleId);
      Candela.text = "Arrow\nTalk";
      pp = true;
    }
    yield return null;
  }
  //Twitch Plays
  #pragma warning disable 414
  private readonly string TwitchHelpMessage = @"Use !{0} press 1-8 to press an arrow where 1 is the arrow in north north west and going clockwise.";
  #pragma warning restore 414
  IEnumerator ProcessTwitchCommand(string thisisblansfault){
	thisisblansfault = thisisblansfault.Trim();
    Match m = Regex.Match(thisisblansfault, @"^press ([1-8])$", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
    if (m.Success){
      int rklsgdgrsmgioiojpwaerargkirekmlerkmlefawepof = int.Parse(m.Groups[1].Value) - 1;
      int[] shutupson_blan2020 = new int[1 + 4 + 3] { 2, 3, 6, 7, 1, 0, 5, 4};
      yield return null;
      fats[shutupson_blan2020[rklsgdgrsmgioiojpwaerargkirekmlerkmlefawepof]].OnInteract();
      yield return new WaitForSeconds(.1f);
    }
    else
      yield return "sendtochaterror Valid command is press. Use !{1} help to see the full command";
    yield break;
  }
  IEnumerator TwitchHandleForcedSolve(){
    while (!moduleSolved){
      fats[shitsucker].OnInteract();
      yield return new WaitForSeconds(.1f);
    }
  }
}