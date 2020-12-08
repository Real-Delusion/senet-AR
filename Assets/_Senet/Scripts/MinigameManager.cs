using System.Collections;
using System.Collections.Generic;
using RealDelusion.Utils;
using UnityEngine;

// NOTES: The controlPiece has to be piece n2, the right up corner.

public class MinigameManager : MonoBehaviour {
    // Controls whether the game has been won or not
    public bool hasWon;

    // List of each puzzlepiece except control piece
    public PuzzlePiece[] puzzlePieces = new PuzzlePiece[3];

    // List of all renderes for each piece
    private Renderer[] puzzleRenderer = new Renderer[4];

    // Panel when completed puzzle
    public GameObject wonPuzzleUI;

    // Panel when won
    public GameObject wonGameUI;

    // Ready to play UI
    public GameObject readyToPlayUI;

    // Timer object
    public GameObject timer;

    // List of all available textures (different puzzles)
    public Texture[] puzzles = new Texture[2];

    // Number of puzzles completed
    private int gamesWon = 0;

    // List of puzzle prefabs
    public GameObject[] piecesPrefabs = new GameObject[3];

    // NUmber of puzzles to solve
    private int puzzlesAmount = 3;

    // Control piece
    public PuzzlePiece controlPiece;

    // List of all available rotations for the puzzle pieces (only 90 degree differences)
    private float[] pieceRotations = new float[] {
        0f,
        90f,
        180f,
        270f
    };

    // Start is called before the first frame update
    void Start ()
    {
        TutorialGameManager tutorial = GetComponent<TutorialGameManager>();
        // Getting the saved state of the checkbox 
        tutorial.stateCheckbox = PlayerPrefs.GetInt("dontShowAgain") == 1 ? true : false;

        Debug.Log("Checking state of the checkbox: " + tutorial.stateCheckbox);

        // If the checkbox was marked before it skips the tutorial
        if (tutorial.stateCheckbox)
        {
            // Load Game
            tutorial.SkipTutorial();
            //StartMinigame(); // Call StartMiniGame from "yes" buttom of "are you ready?" canvas
        }
        else
        {
            // Load Tutorial
            tutorial.ShowQuestion();
        }
    }

    // Update is called once per frame
    void Update () {

        // We need this value so we only notice once when the game has been won
        bool ok = hasWon;

        // Check if the pieces are positioned correctly (except for the 'control' piece, n2)
        if (puzzlePieces[0].PlacedPiece && puzzlePieces[1].PlacedPiece && puzzlePieces[2].PlacedPiece) {
            hasWon = true;
        }

        if (!ok && (puzzlePieces[0].PlacedPiece && puzzlePieces[1].PlacedPiece && puzzlePieces[2].PlacedPiece)) {
            GameWon ();
            hasWon = false;
        }

    }

    // Changes the puzzle texture to a random one out of the list
    public void ChangeToRandomTexture () {
        Renderer one = GameObject.Find ("oneRender").GetComponent<Renderer> ();
        Renderer two = GameObject.Find ("twoRender").GetComponent<Renderer> ();
        Renderer three = GameObject.Find ("threeRender").GetComponent<Renderer> ();
        Renderer four = GameObject.Find ("fourRender").GetComponent<Renderer> ();
        puzzleRenderer[0] = one;
        puzzleRenderer[1] = two;
        puzzleRenderer[2] = three;
        puzzleRenderer[3] = four;
        Debug.Log ("TEXTURE");
        Texture texture = RandomUtils.Choose (puzzles);
        foreach (Renderer renderer in puzzleRenderer) {
            renderer.material.SetTexture ("_MainTex", texture);
        }
    }

    // Sets all values needed to start the minigame
    public void StartMinigame (bool tutorial) {
        Debug.Log("Minigame started");

        // Hide ready to play panel 
        readyToPlayUI.SetActive(false);

        // Hide panel
        wonPuzzleUI.SetActive (false);

        // Set number of puzzles to solve

        // Game mode
        if (tutorial)
        {
            // Tutorial mode
            puzzlesAmount = 1;
            timer.GetComponent<Timer>().timeRemaining = 300f; // 300s
        }
        else
        {
            // Normal mode
            puzzlesAmount = 3;
            timer.GetComponent<Timer>().timeRemaining = 30f; // 30s
        }

        // Show timer
        timer.SetActive(true);

        // Set time remaining

        // Get pieces out of parent...

        // Change pieces order
        ShufflePieces ();

        // Choose a puzzle
        ChangeToRandomTexture ();

        // Rotate the puzzle pieces
        RotatePieces ();
    }

    // Sets a random rotation for each puzzle piece
    public void RotatePieces () {
        Debug.Log ("ROTATE");
        foreach (PuzzlePiece piece in puzzlePieces) {
            piece.gameObject.transform.Rotate (0f, RandomUtils.Choose (pieceRotations), 0f);
        }
        //controlPiece.gameObject.transform.Rotate (0f, RandomUtils.Choose (pieceRotations), 0f);

    }

    // Controls what to do when the minigame has been won
    public void GameWon () {
        gamesWon++;

        foreach (PuzzlePiece piece in puzzlePieces)
        {
            piece.PlacedPiece = false;
        }  
        // When less than 3 puzzles have been completed
        if (gamesWon < puzzlesAmount) {
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

        for (int i = 0; i < 3; i++) {
            // Delete the old puzzle pieces
            // First round
            if (puzzlePieces[i].transform.childCount > 0) {
                GameObject.Destroy (puzzlePieces[i].transform.GetChild (0).gameObject);
            }

            // Second or third round
            GameObject coupling = GameObject.Find ("coupling" + piecesPrefabs[i].gameObject.name);
            if (coupling.transform.childCount > 0) {
                GameObject.Destroy (coupling.transform.GetChild (0).gameObject);
            }

            // Reset imagetarget positions
            puzzlePieces[i].gameObject.transform.parent.gameObject.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
            
            // Create new puzzle pieces
            GameObject child = Instantiate (piecesPrefabs[i], new Vector3 (0, 0, 0), Quaternion.identity);
            child.transform.parent = puzzlePieces[i].transform;
            child.transform.SetSiblingIndex (1);
            puzzlePieces[i].transform.GetChild (0).gameObject.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
            puzzlePieces[i].transform.GetChild (0).gameObject.transform.localRotation = Quaternion.identity;

            // Reassign coupling object
            puzzlePieces[i].correctPos = coupling.transform;
        }
    }
}