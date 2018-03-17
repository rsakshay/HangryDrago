using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectable : MonoBehaviour
{

    public DataTypes.Constants.TypesOfFruit fruit;
    public float disappearTime;
    public float singleRotationTime;
    public int particlesEmitted;
    public ParticleSystem myParticleSystem;

    private bool canCollect = true;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == DataTypes.Constants.PLAYER_TAG && canCollect)
        {
            CanvasManager.Instance.TurnOnFruitUI(fruit);
            canCollect = false;
            myParticleSystem.Emit(particlesEmitted);
            myParticleSystem.Stop();
            DestroyFruit();
            collider.gameObject.GetComponent<PlayerFlingScript>().PlayEatingSound();
        }
    }

    private void DestroyFruit()
    {
        var rotationSeq = DOTween.Sequence();

        rotationSeq.Append(transform.DORotate(new Vector3(transform.rotation.x, 180.0f, transform.rotation.z), singleRotationTime));
        rotationSeq.Append(transform.DORotate(new Vector3(transform.rotation.x, 0.0f, transform.rotation.z), singleRotationTime));
        rotationSeq.Append(transform.DORotate(new Vector3(transform.rotation.x, 180.0f, transform.rotation.z), singleRotationTime));
        rotationSeq.Append(transform.DORotate(new Vector3(transform.rotation.x, 0.0f, transform.rotation.z), singleRotationTime));
        rotationSeq.Append(transform.DORotate(new Vector3(transform.rotation.x, 180.0f, transform.rotation.z), singleRotationTime));
        rotationSeq.Append(transform.DORotate(new Vector3(transform.rotation.x, 0.0f, transform.rotation.z), singleRotationTime));
        rotationSeq.Append(transform.DORotate(new Vector3(transform.rotation.x, 180.0f, transform.rotation.z), singleRotationTime));
        rotationSeq.Append(transform.DORotate(new Vector3(transform.rotation.x, 0.0f, transform.rotation.z), singleRotationTime));

        rotationSeq.Play();

        transform.DOScale(new Vector3(0.05f, 0.05f, 0.05f), disappearTime)
            .OnComplete(() =>
            {
                rotationSeq.Kill();
                myParticleSystem.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        );
    }
}
