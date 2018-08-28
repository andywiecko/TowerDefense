﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildManager : MonoBehaviour {

	public static buildManager instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("more then one buildManager is presented!");
		}	
		instance = this;
		
	}

	public GameObject standardTurretPrefab;
	public GameObject missleLauncherPrefab;
	public GameObject buildEffect;

 	public NodeUI nodeUI;

	private TurretBlueprint turretToBuild;
	private Node selectedNode;

	public bool CanBuild{ get {return turretToBuild != null;} }
	public bool HasMoney{ get {return PlayerStats.Money >= turretToBuild.cost;} }


	public void SelectNode (Node node)
	{

		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}
		selectedNode = node;
		turretToBuild = null;
		
		nodeUI.SetTarget(node);

	}
	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}

	public void SelectTurretToBuild (TurretBlueprint turret)
	{
		turretToBuild = turret;
		DeselectNode();
	}

	public TurretBlueprint GetTurretToBuild()
	{
		return turretToBuild;
	}
}
