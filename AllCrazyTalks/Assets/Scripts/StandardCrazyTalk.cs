using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;
public class StandardCrazyTalk : MonoBehaviour {
    public KMBombInfo Bomb;
    public KMAudio Audio;
    public TextMesh MainText;
    public KMSelectable Chungun;
    public KMSelectable[] TopButtons;   //1, 2, 3, 4, 5
    public KMSelectable[] OtherButtons; //status, TL, TR, BL, BR
    public GameObject[] ButtonsForColor; //1, 2, 3, 4, 5
    public Material[] ButtonMats; //R, O, G, B, P
    public Color[] TextColors; //R, O, G, B, P
    public GameObject Surf;
    public Material[] Weed;
    private List<string> colorOrder = new List<string> { "Red", "Orange", "Green", "Blue", "Purple" };
    private List<string> ordinals = new List<string> { "st", "nd", "rd", "th", "th" };
    private List<string> placeNames = new List<string>{ "sl", "tl", "tr", "bl", "br" };
    private List<string> colorNames = new List<string> { "Red", "Orange", "Green", "Blue", "Purple" };
    string message = "";
    int RNG = 0;
    private List<string> splitMessage = new List<string> { "", "", "", "", "" };
    int selectedPhrase = 0;
    int firstColor = 0;
    int secondColor = 0;
    int firstPosition = 0;
    int secondPosition = 0;
    int distance = 0;
    bool verdict = false;
    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable tButton in TopButtons) {
            tButton.OnHighlight += delegate () { tButtonPress(tButton);};
        }

        foreach (KMSelectable oButton in OtherButtons) {
            oButton.OnInteract += delegate () { oButtonPress(oButton); return false; };
        }
        Chungun.OnInteract += delegate () { PressChungun(); return false; };
    }
    void Start () {
        colorOrder.Shuffle();
        for (int i = 0; i < 5; i++) {
            switch (colorOrder[i]) {
                case "Red": ButtonsForColor[i].GetComponent<MeshRenderer>().material = ButtonMats[0]; break;
                case "Orange": ButtonsForColor[i].GetComponent<MeshRenderer>().material = ButtonMats[1]; break;
                case "Green": ButtonsForColor[i].GetComponent<MeshRenderer>().material = ButtonMats[2]; break;
                case "Blue": ButtonsForColor[i].GetComponent<MeshRenderer>().material = ButtonMats[3]; break;
                case "Purple": ButtonsForColor[i].GetComponent<MeshRenderer>().material = ButtonMats[4]; break;  //4,1,0,3,2
                default: break;
            }
        }
        Debug.LogFormat("[Standard Crazy Talk #{0}] The order of colors are {1},{2},{3},{4},{5}.", moduleId, colorOrder[0],colorOrder[1],colorOrder[2],colorOrder[3],colorOrder[4]);
        selectedPhrase = UnityEngine.Random.Range(0, StandardPhrases.Phrases.Count());
        firstColor = UnityEngine.Random.Range(0, 5);
        secondColor = UnityEngine.Random.Range(0, 5);
        while (secondColor == firstColor) {
          secondColor = UnityEngine.Random.Range(0, 5);
        }
        firstPosition = UnityEngine.Random.Range(0, 5);
        secondPosition = UnityEngine.Random.Range(0, 5);
        while (secondPosition == firstPosition) {
          secondPosition = UnityEngine.Random.Range(0, 5);
        }
        distance = UnityEngine.Random.Range(1, 5);
        message = String.Format( StandardPhrases.Phrases[selectedPhrase], colorNames[firstColor].ToLower(), (firstPosition+1).ToString(), colorNames[secondColor].ToLower(), (secondPosition+1).ToString(), distance.ToString(), ordinals[firstPosition], ordinals[secondPosition], placeNames[firstPosition],placeNames[secondPosition]);
        Debug.LogFormat("[Standard Crazy Talk #{0}] The phrase is: \"{1}\"", moduleId, message.Replace("\n", " "));
        for (int i = 0; i < message.Length; i++) {
            if (message[i] == '\n') {
                splitMessage[0] += "\n";
                splitMessage[1] += "\n";
                splitMessage[2] += "\n";
                splitMessage[3] += "\n";
                splitMessage[4] += "\n";
            } else {
                RNG = UnityEngine.Random.Range(0, 5);
                for (int j = 0; j < 5; j++) {
                    if (RNG == j) {
                        splitMessage[j] += message[i];
                    } else {
                        splitMessage[j] += " ";
                    }
                }
            }
        }
        Debug.LogFormat("[Standard Crazy Talk #{0}] The split phrases are: \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\"", moduleId, splitMessage[0].Replace("\n", "#").Replace(" ", "#"), splitMessage[1].Replace("\n", "#").Replace(" ", "#"), splitMessage[2].Replace("\n", "#").Replace(" ", "#"), splitMessage[3].Replace("\n", "#").Replace(" ", "#"), splitMessage[4].Replace("\n", "#").Replace(" ", "#"));
        Debug.Log(String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", colorNames[firstColor].ToLower(), firstPosition.ToString(), colorNames[secondColor].ToLower(), secondPosition.ToString(), distance.ToString(), ordinals[firstPosition], ordinals[secondPosition], placeNames[firstPosition],placeNames[secondPosition]));
        Debug.Log(String.Format("C1 AT {0} | C2 AT {1}", colorOrder.IndexOf(colorNames[firstColor]), colorOrder.IndexOf(colorNames[secondColor])));

        switch (selectedPhrase) {
          case 0:
          if (colorOrder.IndexOf(colorNames[firstColor]) == firstPosition - 1) {
            verdict = true;
          }
          break;
          case 1:
          if (colorOrder.IndexOf(colorNames[firstColor]) + 1 == colorOrder.IndexOf(colorNames[secondColor]) || colorOrder.IndexOf(colorNames[firstColor]) - 1 == colorOrder.IndexOf(colorNames[secondColor])) {
            verdict = true;
          }
          break;
          case 2:
          if (colorOrder.IndexOf(colorNames[firstColor]) > colorOrder.IndexOf(colorNames[secondColor])) {
            verdict = true;
          }
          break;
          case 3:
          if (colorOrder.IndexOf(colorNames[secondColor]) > colorOrder.IndexOf(colorNames[firstColor])) {
            verdict = true;
          }
          break;
          case 4:
          if (colorOrder.IndexOf(colorNames[firstColor]) + distance == colorOrder.IndexOf(colorNames[secondColor]) || colorOrder.IndexOf(colorNames[firstColor]) - distance == colorOrder.IndexOf(colorNames[secondColor])) {
            verdict = true;
          }
          break;
          case 5:
          if (colorOrder.IndexOf(colorNames[firstColor]) == 4) {
            verdict = true;
          }
          break;
          case 6: if (colorOrder.IndexOf(colorNames[firstColor]) == 0) {
            verdict = true;
          }
          break;
          case 7: if (colorOrder.IndexOf(colorNames[firstColor]) == 1) {
            verdict = true;
          }
          break;
          case 8: if (colorOrder.IndexOf(colorNames[firstColor]) == 2) {
            verdict = true;
          }
          break;
          case 9: if (colorOrder.IndexOf(colorNames[firstColor]) == 3) {
            verdict = true;
          }
          break;
          case 10:
          if (firstPosition == colorOrder.IndexOf(colorNames[firstColor]) || firstPosition == colorOrder.IndexOf(colorNames[secondColor])) {
            verdict = true;
          }
          break;
          default:
          GetComponent<KMBombModule>().HandlePass();
          Debug.LogFormat("Fat");
          break;
        }
        Debug.Log(verdict);
    }
    void tButtonPress(KMSelectable tButton) {
        for (int i = 0; i < 5; i++) {
            if (tButton == TopButtons[i]) {
                MainText.text = splitMessage[i];
                switch (colorOrder[i]) {
                    case "Red": MainText.color = TextColors[0]; break;
                    case "Orange": MainText.color = TextColors[1]; break;
                    case "Green": MainText.color = TextColors[2]; break;
                    case "Blue": MainText.color = TextColors[3]; break;
                    case "Purple": MainText.color = TextColors[4]; break;
                    default: break;
                }
            }
        }
    }
    void oButtonPress(KMSelectable oButton) {
        for (int i = 0; i < 5; i++) {
            if (oButton == OtherButtons[i]) { //BL BR TR TL SL
              Debug.Log("DIldos" + i);
                if (verdict == true && i == firstPosition) {
                  GetComponent<KMBombModule>().HandlePass();
                  Audio.PlaySoundAtTransform("FTANG", transform);
                  moduleSolved = true;
                  MainText.text = "Standard Crazy\nTalk";
                  message = "Press the V in lives.";
                  splitMessage[0] = ""; splitMessage[1] = ""; splitMessage[2] = ""; splitMessage[3] = ""; splitMessage[4] = "";
                  for (int q = 0; q < message.Length; q++) {
                      if (message[q] == '\n') {
                          splitMessage[0] += "\n";
                          splitMessage[1] += "\n";
                          splitMessage[2] += "\n";
                          splitMessage[3] += "\n";
                          splitMessage[4] += "\n";
                      } else {
                          RNG = UnityEngine.Random.Range(0, 5);
                          for (int j = 0; j < 5; j++) {
                              if (RNG == j) {
                                  splitMessage[j] += message[q];
                              } else {
                                  splitMessage[j] += " ";
                              }
                          }
                      }
                  }
                }
                else if (verdict == false && i == secondPosition) {
                  GetComponent<KMBombModule>().HandlePass();
                  Audio.PlaySoundAtTransform("FTANG", transform);
                  moduleSolved = true;
                  MainText.text = "Standard Crazy\nTalk";
                  message = "Press the V in lives.";
                  splitMessage[0] = ""; splitMessage[1] = ""; splitMessage[2] = ""; splitMessage[3] = ""; splitMessage[4] = "";
                  for (int q = 0; q < message.Length; q++) {
                      if (message[q] == '\n') {
                          splitMessage[0] += "\n";
                          splitMessage[1] += "\n";
                          splitMessage[2] += "\n";
                          splitMessage[3] += "\n";
                          splitMessage[4] += "\n";
                      } else {
                          RNG = UnityEngine.Random.Range(0, 5);
                          for (int j = 0; j < 5; j++) {
                              if (RNG == j) {
                                  splitMessage[j] += message[q];
                              } else {
                                  splitMessage[j] += " ";
                              }
                          }
                      }
                  }
                }
                else {
                  GetComponent<KMBombModule>().HandleStrike();
                  Audio.PlaySoundAtTransform("Bitch", transform);
                }
            }
        }
    }
    void PressChungun(){
      if (moduleSolved == true) {
        for (int i = 0; i < 5; i++) {
          ButtonsForColor[i].transform.localPosition = new Vector3(-0.07f,-0.1f,-0.06f);
        }
        Audio.PlaySoundAtTransform("FTANG", transform);
        MainText.text = "";
        Surf.GetComponent<MeshRenderer>().material = Weed[0];
      }
    }
    //Twitch Plays
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use !{0} cycle 5 to cycle all the top buttons 5 times (default to 1 cycle if digit is not specified and no more 3 digits can be used). Use !{0} highlight 15 2 to highlight button 1, 5, and 2 along the top. Use !{0} press (tl|tr|bl|br|sl) to press in 4 corners and a status light. Use !{0} setspeed 0.05 to set cycle/highlight speed to 0.05 seconds (can not be longer that 19.99 seconds).";
    #pragma warning restore 414
    private Coroutine vodka = null;
    bool TwitchShouldCancelCommand;
    int cycleCount = 5;
    IEnumerator tButtonCycle(int num){
        for (int i = 0; i < 5 * num; i++){
            TopButtons[i % 5].OnHighlight();
            for (int j = 0; j < cycleCount; j++){
                yield return new WaitForSeconds(0.01f);
                if (TwitchShouldCancelCommand)
                    goto done1;
            }
        }
        done1:
        vodka = null;
    }
    IEnumerator tButtonHighlight(string nun){
        for (int i = 0; i < nun.Length; i++){
            TopButtons[nun[i] - '1'].OnHighlight();
            for (int j = 0; j < cycleCount; j++){
                yield return new WaitForSeconds(0.01f);
                if (TwitchShouldCancelCommand)
                    goto done2;
            }
        }
        done2:
        vodka = null;
    }
    IEnumerator ProcessTwitchCommand(string yeet){
        yeet = yeet.ToLowerInvariant().Trim();
        Match m = Regex.Match(yeet, @"^(?:press ([tb][lr]|sl)|cycle( [1-9]\d{0,2})?|highlight ((?:[1-5]\s*)+)|setspeed (1?\d(?:.\d{1,2})?)?)$");
        if (m.Success){
            yield return null;
            if (m.Groups[1].Success){
                Dictionary<string, int> yeetToButtonPress = new Dictionary<string, int>(){
                    { "sl", 0 },
                    { "tl", 1 },
                    { "tr", 2 },
                    { "bl", 3 },
                    { "br", 4 }
                };
                OtherButtons[yeetToButtonPress[m.Groups[1].Value]].OnInteract();
            }
            else if (m.Groups[3].Success){
                yeet = m.Groups[3].Value.Replace(" ", String.Empty);
                vodka = StartCoroutine(tButtonHighlight(yeet));
                while (vodka != null)
                    yield return "trycancel";
            }
            else if (m.Groups[4].Success){
                cycleCount = (int) (Mathf.Max(float.Parse(m.Groups[4].Value), 0.05f) / 0.01f);
            }
            else {
                int num = 1;
                if (m.Groups[2].Success)
                    num = int.Parse(m.Groups[2].Value);
                if (num == 0){
                    yield return "sendtochaterror You can't cycle fast 0 times.";
                    yield break;
                }
                vodka = StartCoroutine(tButtonCycle(num));
                while (vodka != null)
                    yield return "trycancel";
            }
        }
        else
            yield return "sendtochaterror Valid commands are highlight, cycle, and press. Use !{1} help to find the full commands.";
        yield break;
    }
    IEnumerator TwitchHandleForcedSolve(){
        if(vodka != null)
            StopCoroutine(vodka);
        vodka = null;
        if (verdict)
            OtherButtons[firstPosition].OnInteract();
        else
            OtherButtons[secondPosition].OnInteract();
        yield return new WaitForSeconds(.1f);
    }
}
