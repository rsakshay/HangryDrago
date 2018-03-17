using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mole : MonoBehaviour {

    public SphereCollider distanceTrigger;
    public Transform moleHole;

    public float popupDistance;
    public float pause;

    public float jumpSpeed;
    public float jumpHeight;

    public float stayUnderGroundtime;

    private Vector3 originalPosition;
    private Vector3 originalHolePos;
    private DataTypes.Constants.EnemyStates currentState;
    private bool hasHoleAppeared;

    private void Start()
    {
        originalPosition = transform.position;
        originalHolePos = moleHole.position;
        hasHoleAppeared = false;
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == DataTypes.Constants.PLAYER_TAG && currentState == DataTypes.Constants.EnemyStates.Resting)
        {
            BeginAttack();
        }
    }

    private void BeginAttack()
    {
        if (!hasHoleAppeared)
        {
            moleHole.DOMove(new Vector3(moleHole.position.x, moleHole.position.y + popupDistance, moleHole.position.z), pause);
            hasHoleAppeared = true;
        }

        currentState = DataTypes.Constants.EnemyStates.Attacking;
       
        gameObject.transform
            .DOMove(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + popupDistance, gameObject.transform.position.z), pause)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                StartCoroutine(HighJump());
            });
    }

    private IEnumerator HighJump()
    {
        yield return new WaitForSeconds(pause);
        gameObject.transform.DOMove(transform.position + (transform.up * jumpHeight), (transform.up * jumpHeight).magnitude / jumpSpeed)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => {
                ResetState();
            });
    }

    private void ResetState()
    {
        gameObject.transform.DOMove(originalPosition, (originalPosition - gameObject.transform.position).magnitude / jumpSpeed)
            .SetEase(Ease.InQuad)
            .OnComplete(() => {
                currentState = DataTypes.Constants.EnemyStates.Resting;
            });
    }
}
