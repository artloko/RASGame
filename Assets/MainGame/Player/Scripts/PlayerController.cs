using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    #region Singleton
    public static PlayerController instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public Interactable focus;
    public GameProcess gameProcess;

    public LayerMask movementMask;
    public LayerMask UIMask;
    PlayerMotor motor;
    Camera cam;

    public GameObject focusPanel;
    public GameObject Health;

    public Text nameText;
    public Text raceText;
    public Text classText;
    public Text genderText;
    public Text statusText;

    public Text HPText;
    public Image HealthBar;
    public GameObject shieldTargetIcon;

	void Start () {
        focusPanel.SetActive(false);
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        gameProcess = GetComponent<GameProcess>();
	}
	

	void Update ()
    {
        if (gameProcess.Player.Status != PlayerMainScript.statusEnum.Dead && gameProcess.Player.Status != PlayerMainScript.statusEnum.Paralyzed)
        {
            focusPanel.SetActive(false);
            Health.SetActive(false);
            nameText.text = null;
            raceText.text = null;
            classText.text = null;
            genderText.text = null;
            statusText.text = null;
            HPText.text = null;

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetMouseButtonDown(2))
            {
                if (Physics.Raycast(ray, out hit, 100))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        if (interactable != focus)
                        {
                            if (focus != null)
                                focus.OnDefocused();
                            focus = interactable;
                        }
                        interactable.OnFocused(transform);
                    }
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, 50, movementMask))
                {
                    motor.MoveToPoint(hit.point);

                    RemoveFocus();
                }
                if (Physics.Raycast(ray, out hit, 100))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                }
            }
        }
    }
    
    void LateUpdate()
    {
        if (focus != null)
        {
            focusPanel.SetActive(true);
            if (focus is Enemy)
            {
                Health.SetActive(true);
                nameText.text = (focus as Enemy).enemy.name;
                HPText.text = String.Format("{0}/{1}", (focus as Enemy).enemy.CurrentHealth, (focus as Enemy).enemy.MaxHealth);
                HealthBar.fillAmount = (focus as Enemy).enemy.CurrentHealth * 1.0f / (focus as Enemy).enemy.MaxHealth * 1.0f;
            }
            else if (focus is EnemyNPC)
            {
                Health.SetActive(true);
                nameText.text = (focus as EnemyNPC).enemy.CharacterName;
                raceText.text = String.Format("Race: {0}",(focus as EnemyNPC).enemy.Race.ToString());
                classText.text = String.Format("Class: {0}", (focus as EnemyNPC).enemy.Class.ToString());
                genderText.text = String.Format("Gender: {0}", (focus as EnemyNPC).enemy.Gender.ToString());
                statusText.text = String.Format("Status: {0}", (focus as EnemyNPC).enemy.Status.ToString());
                HPText.text = String.Format("{0}/{1}", (focus as EnemyNPC).enemy.CurrentHealth, (focus as EnemyNPC).enemy.MaxHealth);
                HealthBar.fillAmount = (focus as EnemyNPC).enemy.CurrentHealth * 1.0f / (focus as EnemyNPC).enemy.MaxHealth * 1.0f;

            }
            else if (focus is ItemPickUp)
            {
                nameText.text = (focus as ItemPickUp).item.name;
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        motor.StopFollowingTarget();
    }
}
