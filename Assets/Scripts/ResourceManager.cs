using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager> {

	public IDictionary<string, GameObject> Prefabs = new Dictionary<string, GameObject>();
    public IDictionary<string, AudioClip> Sounds = new Dictionary<string, AudioClip>();

    void Awake () {
        InitializePrefabs();
        InitializeSounds();
    }

    private void InitializePrefabs()
    {
        Prefabs.Add("Boulder", Resources.Load("Prefabs/Boulder") as GameObject);
        Prefabs.Add("Echo", Resources.Load("Prefabs/Echo") as GameObject);
        Prefabs.Add("Key", Resources.Load("Prefabs/Key") as GameObject);
        Prefabs.Add("Pulse", Resources.Load("Prefabs/Pulse") as GameObject);
    }

    private void InitializeSounds()
    {
        Prefabs.Add("CalmForest", Resources.Load("Sounds/CalmForest") as GameObject);
        Prefabs.Add("Echo", Resources.Load("Sounds/Echo") as GameObject);
        Prefabs.Add("Lake", Resources.Load("Sounds/Lake") as GameObject);
        Prefabs.Add("StepsCave", Resources.Load("Sounds/StepsCave") as GameObject);
        Prefabs.Add("StepsDirt", Resources.Load("Sounds/StepsDirt") as GameObject);
        Prefabs.Add("StepsGrass", Resources.Load("Sounds/StepsGrass") as GameObject);
        Prefabs.Add("SadCave", Resources.Load("Sounds/SadCave") as GameObject);
        Prefabs.Add("Whoosh", Resources.Load("Sounds/Whoosh") as GameObject);
    }
}
