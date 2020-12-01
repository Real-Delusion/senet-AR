using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour {
    public bool hasWon;

    public PuzzlePiece[] puzzle = new PuzzlePiece[3];

    public Renderer[] puzzleRenderer = new Renderer[4];

    public GameObject wonUI;

    public Texture[] puzzles = new Texture[3];

    // Start is called before the first frame update
    void Start () {
        ChangeTexture ();
    }

    // Update is called once per frame
    void Update () {
        // Check if the pieces are correct
        bool ok = hasWon;

        if (puzzle[0].PlacedPiece && puzzle[1].PlacedPiece && puzzle[2].PlacedPiece) {
            hasWon = true;
        }

        if (!ok && (puzzle[0].PlacedPiece && puzzle[1].PlacedPiece && puzzle[2].PlacedPiece)) {
            Debug.Log ("WON!");
            wonUI.SetActive (true);
        }

    }

    public void ChangeTexture () {
        foreach (Renderer renderer in puzzleRenderer) {
            renderer.material.SetTexture ("_MainTex", puzzles[0]);
        }
    }
}