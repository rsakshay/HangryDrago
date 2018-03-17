using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    public static CanvasManager Instance;

    public Image[] canvasImages;

	// Use this for initialization
	void Start () {

        if (Instance != null)
            return;

        Instance = this;

		for (int i = 0; i < canvasImages.Length; i++)
        {
            canvasImages[i].gameObject.SetActive(false);
        }
	}

    public void TurnOnFruitUI(DataTypes.Constants.TypesOfFruit fruit)
    {
        canvasImages[DataTypes.Constants.FindIndexforFruit(fruit)].gameObject.SetActive(true);
    }
}
