using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bird : MonoBehaviour {

    public SphereCollider distanceTrigger;

    public float hoverDistance;
    public float hoverTime;
    public float birdPause;

    public float birdSpeed;

    public float resetSpeed;
    public float stayOnGround;

    private Vector3 originalPosition;
    private DataTypes.Constants.EnemyStates currentState;

    private void Start()
    {
        originalPosition = transform.position;
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == DataTypes.Constants.PLAYER_TAG && currentState == DataTypes.Constants.EnemyStates.Resting)
        {
            BeginAttack(collider.gameObject);
        }
    }

    private void BeginAttack(GameObject target)
    {
        currentState = DataTypes.Constants.EnemyStates.Attacking;
        gameObject.transform
            .DOMove(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + hoverDistance, gameObject.transform.position.z), hoverTime)
            .SetEase(Ease.OutQuad)
            .OnComplete( () =>
            {
                StartCoroutine(ChargePlayer(target.transform));
            });
    }

    private IEnumerator WaitForSeconds(float pauseTime)
    {
        yield return new WaitForSeconds(pauseTime);
    }

    private IEnumerator ChargePlayer(Transform playerTrans)
    {
        yield return new WaitForSeconds(birdPause);
        var direction = playerTrans.position - transform.position;
        gameObject.transform.DOMove(playerTrans.position, (direction.magnitude)/birdSpeed)
            .OnComplete(() => {
                StartCoroutine(ResetState());
            });
    }

    private IEnumerator ResetState()
    {
        yield return new WaitForSeconds(stayOnGround);
        gameObject.transform.DOMove(originalPosition, (originalPosition - gameObject.transform.position).magnitude / resetSpeed)
            .OnComplete(() => {
                currentState = DataTypes.Constants.EnemyStates.Resting;
            });
    }
}
