using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TankController Pyr1, Pyr2;
    public static GameController i;
    [Header("Win vars")]
    public Winner winner;
    public TextMeshProUGUI WinText;
    public Animator anim;
    public AudioSource source;
    public enum Winner
    {
        Player1,
        Player2,
        NA
    }
    [Header("pause")]
    public GameObject Pause;
    public bool toggle;
    private bool LockEnum;
    // Start is called before the first frame update
    void Start()
    {
        winner = Winner.NA;
        i = this;

    }

    // Update is called once per frame
    void Update()
    {

        ChooseWinner();
        if (Input.GetButtonDown("Pause"))
        {
            toggle = !toggle;
        }
        Pause.SetActive(toggle);
        if (Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            Application.Quit();
            
            Debug.Log("Quit");
        }
    }

    public void ChooseWinner()
    {
        if (LockEnum == false)
        {
            if (Pyr1.Dead == true)
            {
                winner = Winner.Player2;
                LockEnum = true;
            }
            if (Pyr2.Dead == true)
            {
                winner = Winner.Player1;
                LockEnum = true;
            }
        }
        if (LockEnum == true)
        {
            switch (winner)
            {
                case Winner.Player1:
                    WinText.color = Color.green;
                    Pyr1.activeControls = TankController.ActiveControls.FullControllOff;
                    //source.Play();
                    WinText.text = "Winner is Green!";
                    anim.SetTrigger("Win");
                    Time.timeScale = 0;
                    break;
                case Winner.Player2:
                    //source.Play();
                    WinText.color = Color.red;
                    Pyr2.activeControls = TankController.ActiveControls.FullControllOff;
                    WinText.text = "Winner is Red!";
                    anim.SetTrigger("Win");
                    Time.timeScale = 0;
                    break;
                case Winner.NA:
                    break;
            }
        }
    }
    public void LoadMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
