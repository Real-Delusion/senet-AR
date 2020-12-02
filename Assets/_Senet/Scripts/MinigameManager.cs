using System.Collections;
using System.Collections.Generic;
using RealDelusion.Utils;
using UnityEngine;

// NOTES: The controlPiece has to be piece n2, the right up corner.

public class MinigameManager : MonoBehaviour {
    // Controls whether the game has been won or not
    public bool hasWon;

    // List of each puzzlepiece
    public PuzzlePiece[] puzzlePieces = new PuzzlePiece[4];

    // List of all renderes for each piece
    public Renderer[] puzzleRenderer = new Renderer[4];

    // Panel when completed puzzle
    public GameObject wonPuzzleUI;

    // Panel when won
    public GameObject wonGameUI;

    // List of all available textures (different puzzles)
    public Texture[] puzzles = new Texture[2];

    // Number of puzzles completed
    private int gamesWon = 0;

    // List of puzzle prefabs
    public GameObject[] piecesPrefabs = new GameObject[4];

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
        Debug.Log ("TEXTURE");
        Texture texture = RandomUtils.Choose (puzzles);
        foreach (Renderer renderer in puzzleRenderer) {
            renderer.material.SetTexture ("_MainTex", texture);
        }
    }

    // Sets all values needed to start the minigame
    public void StartMinigame () {
        // Hide panel
        wonPuzzleUI.SetActive (false);

        // Get pieces out of parent...

        // Change pieces order
        ShufflePieces ();

        foreach (PuzzlePiece piece in puzzlePieces) {
            Debug.Log (piece.transform.GetChild (0).transform.position);
        }

        // Choose a puzzle
        ChangeToRandomTexture ();
        foreach (PuzzlePiece piece in puzzlePieces) {
            Debug.Log (piece.transform.GetChild (0).transform.position);
        }

        // Rotate the puzzle pieces
        FlipPieces ();
        foreach (PuzzlePiece piece in puzzlePieces) {
            Debug.Log (piece.transform.GetChild (0).transform.position);
        }

    }

    // Sets a random rotation for each puzzle piece
    public void FlipPieces () {
        Debug.Log ("FLIP");
        foreach (PuzzlePiece piece in puzzlePieces) {
            piece.gameObject.transform.Rotate (0f, RandomUtils.Choose (pieceRotations), 0f);
            //piece.gameObject.transform.GetChild (0).gameObject.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
        }
    }

    // Controls what to do when the minigame has been won
    public void GameWon () {
        gamesWon++;
        // When less than 3 puzzles have been completed
        if (gamesWon < 3) {
            Debug.Log ("Congrats! Next puzzle.");

            // Some UI text/animation ...
            wonPuzzleUI.SetActive (true);

        }
        // When the minigame has been won, 3 puzzles completed
        else {
            Debug.Log ("YOU ARE THE BEST!");
            wonGameUI.SetActive (true);
        }
    }

    public void ShufflePieces () {
        Debug.Log ("SHUFFLE");
        // Shuffle the puzzle pieces
        RandomUtils.Shuffle (puzzlePieces);

        for (int i = 0; i < 4; i++) {
            GameObject.Destroy (puzzlePieces[i].transform.GetChild (0).gameObject);
            GameObject child = Instantiate (piecesPrefabs[i], new Vector3 (0, 0, 0), Quaternion.identity);
            child.transform.parent = puzzlePieces[i].transform;
            child.transform.SetSiblingIndex (1);
            puzzlePieces[i].transform.GetChild (0).gameObject.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
        }
    }
}