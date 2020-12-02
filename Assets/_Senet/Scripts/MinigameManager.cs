using System.Collections;
using System.Collections.Generic;
using RealDelusion.Utils;
using UnityEngine;

// NOTES: The controlPiece has to be piece n2, the right up corner.

public class MinigameManager : MonoBehaviour {
    public bool hasWon;

    // List of each puzzlepiece
    public PuzzlePiece[] puzzlePieces = new PuzzlePiece[4];

    // List of all renderes for each piece
    public Renderer[] puzzleRenderer = new Renderer[4];

    // Panel when won
    public GameObject wonUI;

    // List of all available textures (different puzzles)
    public Texture[] puzzles = new Texture[2];

    // List of all available rotations for the puzzle pieces (only 90 degree differences)
    private float[] pieceRotations = new float[] {
        0f,
        90f,
        180f,
        270f
    };

    // Start is called before the first frame update
    void Start () {
        StartMinigame ();
    }

    // Update is called once per frame
    void Update () {

        // We need this value so we only notice once when the game has been won
        bool ok = hasWon;

        // Check if the pieces are positioned correctly (except for the 'control' piece, n2)
        if (puzzlePieces[0].PlacedPiece && puzzlePieces[2].PlacedPiece && puzzlePieces[3].PlacedPiece) {
            hasWon = true;
        }

        if (!ok && (puzzlePieces[0].PlacedPiece && puzzlePieces[2].PlacedPiece && puzzlePieces[3].PlacedPiece)) {
            GameWon ();
        }

    }

    // Changes the puzzle texture to a random one out of the list
    public void ChangeToRandomTexture () {
        Texture texture = RandomUtils.Choose (puzzles);
        foreach (Renderer renderer in puzzleRenderer) {
            renderer.material.SetTexture ("_MainTex", texture);
        }
    }

    // Sets all values needed to start the minigame
    public void StartMinigame () {
        // Choose a puzzle
        ChangeToRandomTexture ();

        // Rotate the puzzle pieces
        FlipPieces ();
    }

    // Sets a random rotation for each puzzle piece
    public void FlipPieces () {
        foreach (PuzzlePiece piece in puzzlePieces) {
            piece.gameObject.transform.Rotate (0f, RandomUtils.Choose (pieceRotations), 0f);
        }
    }

    // Controls what to do when the minigame has been won
    public void GameWon () {
        Debug.Log ("WON!");
        wonUI.SetActive (true);
    }
}