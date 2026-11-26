namespace Stone_Removal_Game
{
    public class Solution
    {
        public bool CanAliceWin(int n)
        {
            int stones = 10;
            bool aliceTurn = true;
            while (n >= stones)
            {
                n -= stones;
                stones--;
                aliceTurn = !aliceTurn;
            }
            return !aliceTurn;
        }
    }
}
