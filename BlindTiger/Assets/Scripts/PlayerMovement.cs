using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Way Points")] public Transform entrance;

    public float lookSpeed = 1f;
    public float moveSpeed = 1f;
    public bool moving;
    public Transform start;

    public IEnumerator Move(Transform target)
    {
        Debug.Log("In move");
        Debug.Log("Distance: " + Vector3.Distance(transform.position,
            new Vector3(target.position.x, transform.position.y, target.position.z)));

        moving = true;

        while (Vector3.Distance(transform.position,
            new Vector3(target.position.x, transform.position.y, target.position.z)) > 0.001f)
        {
            var newPos = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(newPos.x, transform.position.y, newPos.z);

            //Debug.Log(transform.position);

            yield return null;
        }

        moving = false;

        yield return null;
    }

    public IEnumerator Look(Transform target)
    {
        Debug.Log("In look");

        var diff = 1f;
        var direction = new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position;

        while (diff > 0.001f)
        {
            var toRotation = Quaternion.LookRotation(direction);
            var oldRot = transform.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.Euler(transform.rotation.eulerAngles.x, toRotation.eulerAngles.y,
                    transform.rotation.eulerAngles.z), lookSpeed * Time.deltaTime);


            diff = Vector3.Distance(oldRot.eulerAngles, transform.eulerAngles);
            yield return null;
        }

        yield return null;
    }

    public IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}