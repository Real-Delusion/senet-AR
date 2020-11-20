using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private CharacterController _characterController;

    // ------------------------------ Para el movimiento --------------------------------
    public float velocidad = 0.01f;

    private Vector3 _dirMov = Vector3.zero;
    private float turnAmount;

    // -----------------------------------------------------------------------------------

    //------------------------------------ Sonidos ---------------------------------------
    private AudioSource sonidoAndar;

    // -------------------------------- EstadosPlayer -----------------------------------
    public enum EstadosPlayer {
        Quieto,
        Andar
    }

    public EstadosPlayer _estado = EstadosPlayer.Quieto;

    public EstadosPlayer Estado {
        get => _estado;
        set {
            _estado = value;
/*
            // Si el estado es andar
            if (_estado == EstadosPlayer.Andar) {
                //Debug.Log("andando");
                // aquí añadiremos animación de andar del personaje
                //gameObject.transform.Find("TheLastMutongo").gameObject.GetComponent<Animator>().SetBool("andar", true);
            }

            // Si el estado es quieto
            if (_estado == EstadosPlayer.Quieto) {
                //Debug.Log("quieto");
                // aquí añadiremos animación de quieto del personaje
                gameObject.transform.Find ("Mutongo").gameObject.GetComponent<Animator> ().SetBool ("andar", false);
                this.gameObject.transform.GetChild (1).gameObject.SetActive (false);
                sonidoAndar.Pause ();
            }*/
        }
    }
    // -------------------------------- EstadosPlayer -----------------------------------

    //-----------------------------------------------

    // Use this for initialization
    void Start () {
        // audio source sonido andar
        sonidoAndar = GetComponent<AudioSource> ();
    }

    //------------------------------------------------

    // Update is called once per frame
    void Update () {
        if (Estado == EstadosPlayer.Andar) {
            gameObject.transform.Find ("Mutongo").gameObject.GetComponent<Animator> ().SetBool ("andar", true);
            this.gameObject.transform.GetChild (1).gameObject.SetActive (true);
            if (!sonidoAndar.isPlaying) {
                sonidoAndar.Play ();
            }
        } else {
            gameObject.transform.Find ("Mutongo").gameObject.GetComponent<Animator> ().SetBool ("andar", false);
            this.gameObject.transform.GetChild (1).gameObject.SetActive (false);
            sonidoAndar.Pause ();
        }
    }
}