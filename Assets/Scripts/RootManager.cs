﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootManager : MonoBehaviour
{
    [SerializeField] RootVisual prefab;

    private List<RootVisual> _visuals = new List<RootVisual>();

    public bool CheckForCollision(Vector2 position, float radius)
    {
        foreach(var visual in _visuals)
        {
            if (visual.CheckForCollision(position, radius))
                return true;
        }
        return false;
    }

    public RootVisual GetCurrent()
    {
        if (_visuals.Count > 0)
        {
            return _visuals[_visuals.Count - 1];
        }
        return null;
    }

    public void CreateNewVisual(Vector2 position)
    {
        CreateNewVisual(null, 0, position);
    }

    public void CreateNewVisual(RootVisual parent, int connectedIndex, Vector2 position)
    {
        var visual = Instantiate(prefab);
        visual.transform.SetParent(this.transform, true);
        visual.transform.position = position;
        visual.SetConnection(parent, connectedIndex);
        _visuals.Add(visual);
    }

    public void DestroyAllRoots() {
        foreach(var root in _visuals) {
            Destroy(root.gameObject);
        }
        _visuals.Clear();
    }

    public bool HasCurrent()
    {
        return GetCurrent() != null;
    }
}
