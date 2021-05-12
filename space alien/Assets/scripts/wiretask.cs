using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class wiretask : MonoBehaviour
{
    public List<Color> _wireColors = new List<Color>();
    public List<wire> _leftWires = new List<wire>();
    public List<wire> _rightWires = new List<wire>();

    public wire CurrentDraggedWire;
    public wire CurrentHoveredWire;

    public bool IsTaskCompleted = false;

    private List<Color> _availableColors;
    private List<int> _availableLeftWireIndex;
    private List<int> _availableRightWireIndex;

    public Sprite brokenElectricityBox;
    public GameObject player;
    public GameObject Audio;

    private GameObject progressManager;
    private void Start()
    {
        progressManager = GameObject.Find("ProgressManager");
        
        _availableColors = new List<Color>(_wireColors);
        _availableLeftWireIndex = new List<int>();
        _availableRightWireIndex = new List<int>();

        for (int i = 0; i < _leftWires.Count; i++)
        {
            _availableLeftWireIndex.Add(i);
        }

        for (int i = 0; i < _rightWires.Count; i++)
        {
            _availableRightWireIndex.Add(i);
        }

        while (_availableColors.Count > 0 &&_availableLeftWireIndex.Count > 0 && _availableRightWireIndex.Count > 0)
        {
            Color pickedColor =
             _availableColors[Random.Range(0, _availableColors.Count)];

            int pickedLeftWireIndex = Random.Range(0, _availableLeftWireIndex.Count);
            int pickedRightWireIndex = Random.Range(0, _availableRightWireIndex.Count);
            _leftWires[_availableLeftWireIndex[pickedLeftWireIndex]].SetColor(pickedColor);
            _rightWires[_availableRightWireIndex[pickedRightWireIndex]].SetColor(pickedColor);

            _availableColors.Remove(pickedColor);
            _availableLeftWireIndex.RemoveAt(pickedLeftWireIndex);
            _availableRightWireIndex.RemoveAt(pickedRightWireIndex);
        }

        StartCoroutine(CheckTaskCompletion());
    }

    private IEnumerator CheckTaskCompletion()
    {
        while (!IsTaskCompleted)
        {
            int successfulWires = 0;

            for (int i = 0; i < _rightWires.Count; i++)
            {
                if (_rightWires[i].IsSuccess) { successfulWires++; }
            }
            if (successfulWires >= _rightWires.Count)
            {
                Debug.Log("TASK COMPLETED");
                GameObject.Find("trigger").SetActive(false);
                player.SetActive(true);
                GameObject.Find("Canvas wires").SetActive(false);
                GameObject.Find("elextricity box").GetComponent<SpriteRenderer>().sprite = brokenElectricityBox;
                Audio.SetActive(true);
                progressManager.GetComponent<ProgressTracker>().isStorageComplete = true;
                //GameObject.Find("door").GetComponent<CorridorPortal>().enabled = true;  deprecated
                GameObject.Find("ProgressManager").GetComponent<LevelProgress>().isCorridorPortalOpen = true;
            }
            else
            {
                Debug.Log("TASK INCOMPLETED");
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}

