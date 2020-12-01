using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour {
    public bool hasWon;

    public PuzzlePiece pieceOne;
    public PuzzlePiece pieceThree;
    public PuzzlePiece pieceFour;
    // Start is called before the first frame update
    void Start () { }

    // Update is called once per frame
    void Update () {
        // Check if the pieces are correct
        bool ok = hasWon;

        if (pieceOne.PlacedPiece && pieceThree.PlacedPiece && pieceFour.PlacedPiece) {
            hasWon = true;
        } 

        if (!ok && (pieceOne.PlacedPiece && pieceThree.PlacedPiece && pieceFour.PlacedPiece)) {
            Debug.Log ("WON!");
            
        }

    }
}