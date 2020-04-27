using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public const float DEFAULT_DRIVING_SPEED = 100;
        public const float MIN_DRIVING_SPEED = 80;
        public const float MAX_DRIVING_SPEED = 120;
        public const int SPIN_FACTOR = 18;
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public int spinAngle = 0;
        public float speed;
        float distanceTravelled;
        bool crashing = false;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
                speed = DEFAULT_DRIVING_SPEED;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                if (!crashing)
                {
                    speed = Random.Range(MIN_DRIVING_SPEED, MAX_DRIVING_SPEED);
                    distanceTravelled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                }
                
                if (crashing)
                {
                    Spin();
                }
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }


        // Adding for simplicity purposes
        void OnCollisionEnter(Collision aCollidingObject)
        {
            if (aCollidingObject.collider.tag == "car")
            {
                crashing = true;
                Spin();
            }
        }

        void Spin()
        {
            
            if (speed > 0)
            {
                spinAngle += SPIN_FACTOR;
                speed -= 5;
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = Quaternion.AngleAxis(spinAngle, Vector3.up);
            }

            else if (speed <= 0)
            {
                speed = DEFAULT_DRIVING_SPEED;
                spinAngle = 0;
                crashing = false;
            }
        }
    }
}