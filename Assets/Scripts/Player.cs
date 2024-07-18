using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	//Variables
	public int numeroDeLlantas;
	public int numeroDePuertas;
	public float cantidadDeGasolina;
	public float moveH;
	public float moveTotal;
	public float speed;
	
	private void Start()
	{
		Debug.Log("Normal message");
		Debug.LogWarning("Warning message");
		Debug.LogError("Error message");
	}

	private int Suma()
	{
		numeroDeLlantas = 4;
		numeroDePuertas = 5;
		cantidadDeGasolina = 1.5f;

		return numeroDeLlantas + numeroDePuertas;
	}

	private void Update()
	{
		moveH = Input.GetAxis("Horizontal");
		moveTotal = moveH * speed * Time.deltaTime;
		transform.Translate(moveTotal, 0, 0);
	}

	public static Action OnLeftArrowPressed;

	private void OnEnable()
	{
		OnLeftArrowPressed += MovePlayer;
	}

	private void MovePlayer()
	{
		Debug.Log("Moving the player");
	}

	public void RaisingOnMovePlayer()
	{
		OnLeftArrowPressed?.Invoke();
	}

}