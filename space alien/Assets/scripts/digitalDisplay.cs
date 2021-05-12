using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class digitalDisplay : MonoBehaviour
{
    [SerializeField]
    private Sprite[] digits;
    [SerializeField]
    private Image[] characters;
    private string codeSequence;
    public string LevelToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    // Start is called before the first frame update
    void Start()
    {
        codeSequence = "";

        for(int i = 0; i <= characters.Length - 1; i++)
        {
            characters[i].sprite = digits[10];

        }
        pushthebutton.ButtonPressed += AddDigitToCodeSequence;
    }
    private void AddDigitToCodeSequence(string digitEntered)
    {
        if(codeSequence.Length < 4)
        {
            switch (digitEntered)
            {
                case "zero":
                    codeSequence += "0";
                    DisplayCodeSequence(0);
                    break;
                case "one":
                    codeSequence += "1";
                    DisplayCodeSequence(1);
                    break;
                case "two":
                    codeSequence += "2";
                    DisplayCodeSequence(2);
                    break;
                case "three":
                    codeSequence += "3";
                    DisplayCodeSequence(3);
                    break;
                case "four":
                    codeSequence += "4";
                    DisplayCodeSequence(4);
                    break;
                case "five":
                    codeSequence += "5";
                    DisplayCodeSequence(5);
                    break;
                case "six":
                    codeSequence += "6";
                    DisplayCodeSequence(6);
                    break;
                case "seven":
                    codeSequence += "7";
                    DisplayCodeSequence(7);
                    break;
                case "eight":
                    codeSequence += "8";
                    DisplayCodeSequence(8);
                    break;
                case "nine":
                    codeSequence += "9";
                    DisplayCodeSequence(9);
                    break;
            }
        }
        switch (digitEntered)
        {
            case "Start":
                ResetDisplay();
                break;
            case "hash":
                if (codeSequence.Length > 0)
                {
                    checkresults();
                }
                break;
        }
    }

    private void DisplayCodeSequence(int digitJustEntered)
    {
        switch (codeSequence.Length) {
            case 1:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = digits[10];
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 2:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 3:
                characters[0].sprite = digits[10];
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 4:
                characters[0].sprite = characters[1].sprite;
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;

        }
    }

    private void checkresults()
    {
        if(codeSequence == "1510")
        {
            Debug.Log("Correct!");
            playerStorage.initialValue = playerPosition;
            Application.LoadLevel(LevelToLoad);
        }
        else
        {
            Debug.Log("Wrong!");
            ResetDisplay();
        }
    }
    private void ResetDisplay()
    {
        for(int i = 0; i <=characters.Length - 1; i++)
        {
            characters[i].sprite = digits[10];
        }
        codeSequence = "";
    }
    private void OnDestroy()
    {
        pushthebutton.ButtonPressed -= AddDigitToCodeSequence;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
