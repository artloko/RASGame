using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactedSelectedScript : MonoBehaviour {

    private List<GameObject> models;

    private int selectionIndex = 0;

    private void Start()
    {
        selectionIndex = PlayerPrefs.GetInt("CharacterSelected");
        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        models[selectionIndex].SetActive(true);
    }

}
