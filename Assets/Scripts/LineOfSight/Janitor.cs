﻿using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PathableObject))]
public class Janitor : EnemyLineOfSight {

    [Header("Janitor Options")]
    public float coolDown = 2f;
    public float initialPauseTime = 0.5f;
    public float pickupDistance = 1f;
    public Vector2 dropOffPoint;

    private bool undetectableSeen;
    private PathableObject pathable;

    public void Start()
    {
        pathable = GetComponent<PathableObject>();
    }

    public override void OnUndetectableSeen(Player player)
    {
        if(undetectableSeen == false)
        {
            undetectableSeen = true;

            StartCoroutine(TravelToPlayer(player));
        }
    }

    IEnumerator TravelToPlayer(Player player)
    {
        pathable.Frozen = true;

        yield return new WaitForSeconds(initialPauseTime);

        pathable.Frozen = false;

        pathable.MoveTowards(player.transform.position);

        yield return WaitForReachPosition(player.transform.position, pickupDistance);

        pathable.Frozen = true;
        StartCoroutine(PickUp(player));
    }

    IEnumerator PickUp(Player player)
    {
        Transform originalPlayerParent = player.transform.parent;
        player.transform.parent = transform;
        player.Frozen = true;

        pathable.Frozen = false;

        Vector2 pickUpVector = pathable.MoveTowards(dropOffPoint);

        yield return WaitForReachPosition(dropOffPoint, pickupDistance, () =>
        {
            player.transform.localPosition = Vector3.zero;
        });

        player.transform.parent = originalPlayerParent;
        player.Frozen = false;

        pathable.MoveInDirection(-1f * pickUpVector);

        pathable.StartPatrolLeg();

        yield return new WaitForSeconds(coolDown);

        undetectableSeen = false;
    }

    IEnumerator WaitForReachPosition(Vector2 pos, float minDist, Action meanwhile = null)
    {
        while (Vector2.Distance(transform.position, pos) > minDist)
        {
            if(meanwhile != null)
            {
                meanwhile();
            }
            yield return null;
        }
    }
}
