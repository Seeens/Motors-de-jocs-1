using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;

public class UI_DebugInfo : MonoBehaviour
{

    //[SerializeField] private Player_State _playerState;
    //[SerializeField] private Player_Controller _playerControl;

    private Text _currentHealth;
    private Text _currentSpeed;
    private Text _currentSpell;


    void Start()
    {
        /* Get the text componenets of the text boxes and scripts*/
        _currentHealth = GameObject.Find("CurrentHealth").GetComponent<Text>();
        _currentSpeed = GameObject.Find("CurrentSpeed").GetComponent<Text>();
        _currentSpell = GameObject.Find("CurrentSpell").GetComponent<Text>();

        //_playerControl = transform.parent.GetComponent<Player_Controller>();
        //_playerState = transform.parent.GetComponent<Player_State>();
    }

    void Update()
    {
    
    }

    public void UpdateHealth(float health)
    {
        _currentHealth.text = "Health: " + health;
    }

    public void UpdateSpeed(float speed)
    {
        _currentSpeed.text = "Speed: " + speed;
    }

    public void UpdateSpell(string spell)
    {
        _currentSpell.text = "    Spell: " + spell;
    }

}
