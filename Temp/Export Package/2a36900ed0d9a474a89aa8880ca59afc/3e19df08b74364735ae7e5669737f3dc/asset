using UnityEngine;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour {

	public delegate void StartFn();
	public delegate void UpdateFn();
	public delegate void ExitFn();

	
	protected class State
	{
		public State(string stateName, UpdateFn fnUpdate = null, StartFn fnStart = null, ExitFn fnExit = null)
		{
			_name = stateName;
			_fnStart = fnStart;
			_fnUpdate = fnUpdate;
			_fnExit = fnExit;
		}

		public void Start()
		{
			if (_fnStart != null) 
			{
				_fnStart ();
			}
		}

		public void Update()
		{
			if (_fnUpdate != null)
			{
				_fnUpdate();
			}
		}
		
		public void Exit()
		{
			if (_fnExit != null)
			{
				_fnExit();
			}
		}
		
		public readonly string 			_name;
		public readonly StartFn         _fnStart;
		public readonly UpdateFn		_fnUpdate;
		public readonly ExitFn			_fnExit;
	};

	private Dictionary<string, State> _states = new Dictionary<string, State>();
	private State _currentState;

	// Use this for initialization
	public virtual void Start () {
	
	}

	public virtual void Update () {
		if (_currentState != null)
			_currentState.Update ();
	}

	protected void AddState(string name, UpdateFn fnUpdate = null, StartFn fnStart = null, ExitFn fnExit = null)
	{
		_states.Add(name, new State(name, fnUpdate,fnStart, fnExit));
	}
	

	public void SetState(string newStateName)
	{
		State state = _states [newStateName];
		if ( !IsValidateStatesChang(state) )
			return;
		SetState (state);
	}

	protected bool IsEmpty {
		get {
			return _states.Count == 0;
		}
	}
	private void SetState(State newState)
	{
		if (_currentState != null)
		{
			_currentState.Exit ();
		}
		_currentState = newState;
		_currentState.Start();
	}

	private bool IsValidateStatesChang(State state)
	{
	   return state != null && state != _currentState;
	}
}
