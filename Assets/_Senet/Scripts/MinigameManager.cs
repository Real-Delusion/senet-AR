using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour {
    public bool hasWon;

    public PuzzlePiece[] puzzle = new PuzzlePiece[3];

    public PuzzlePiece pieceOne;
    public PuzzlePiece pieceThree;
    public PuzzlePiece pieceFour;

    public Renderer[] puzzleRenderer = new Renderer[4];

    public GameObject wonUI;

    public Texture texture1;
    public Texture texture2;
    public Texture texture3;

    // Start is called before the first frame update
    void Start () {
        ChangeTexture ();
    }

    // Update is called once per frame
    void Update () {
        // Check if the pieces are correct
        bool ok = hasWon;

        if (pieceOne.PlacedPiece && pieceThree.PlacedPiece && pieceFour.PlacedPiece) {
            hasWon = true;
        }

        if (!ok && (pieceOne.PlacedPiece && pieceThree.PlacedPiece && pieceFour.PlacedPiece)) {
            Debug.Log ("WON!");
            wonUI.SetActive (true);
        }

    }

    public void ChangeTexture () {
        foreach (Renderer renderer in puzzleRenderer) {
            renderer.material.SetTexture ("_MainTex", texture2);
            Debug.Log (renderer);
        }
    }
}