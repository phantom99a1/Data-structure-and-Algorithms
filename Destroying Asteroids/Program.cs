namespace Destroying_Asteroids
{
    public class Solution
    {
        public bool AsteroidsDestroyed(
            int mass,
            int[] asteroids
        )
        {

            Array.Sort(asteroids);

            long currentMass = mass;

            foreach (int asteroid in asteroids)
            {
                if (currentMass < asteroid)
                {
                    return false;
                }

                currentMass += asteroid;
            }

            return true;
        }
    }
}
