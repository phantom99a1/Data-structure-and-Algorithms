namespace Angle_Between_Hands_of_a_Clock
{
    public class Solution
    {
        public double AngleClock(int hour, int minutes)
        {
            hour %= 12;
            double minAngle = 6.0 * minutes;
            double hourAngle = 30.0 * hour + 0.5 * minutes;
            double diff = Math.Abs(hourAngle - minAngle);

            return Math.Min(diff, 360.0 - diff);
        }
    }
}
