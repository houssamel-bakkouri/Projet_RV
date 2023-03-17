using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public GameObject GameO;
    public int trashNumber;
    public Game Game;

    [SerializeField] private AudioSource errorAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        Game = GameO.GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Cube>(out var cube))
        {
            if (cube.trashNumber == trashNumber)
            {
                Game.AddScore(1);
            }
            else
            {
                Game.AddScore(-1);
                errorAudioSource.Play();
            }
            Destroy(cube.gameObject);
        }
    }
}
