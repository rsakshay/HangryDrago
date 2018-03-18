using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class CanvasManager : MonoBehaviour {

    public static CanvasManager Instance;

    public string endSceneName = "Endscene";
    public Image[] canvasImages;

    private int count = 0;

	// Use this for initialization
	void Start () {

        if (Instance != null)
            return;

        Instance = this;

        count = 0;

		for (int i = 0; i < canvasImages.Length; i++)
        {
            canvasImages[i].gameObject.SetActive(false);
        }
	}

    public void TurnOnFruitUI(DataTypes.Constants.TypesOfFruit fruit)
    {
        int index = DataTypes.Constants.FindIndexforFruit(fruit);

        canvasImages[index].gameObject.SetActive(true);
        count++;

        if (count >= canvasImages.Length)
        {
            DOVirtual.DelayedCall(3, () => SceneManager.LoadScene(endSceneName));
        }
    }
}
