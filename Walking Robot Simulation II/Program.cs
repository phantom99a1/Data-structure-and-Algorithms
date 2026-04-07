namespace Walking_Robot_Simulation_II
{
    public class Robot
    {
        int[] pos;
        int[] limit;
        int dir;
        int total;

        public Robot(int width, int height)
        {
            pos = new int[2];
            limit = new int[2] { width - 1, height - 1 };
            dir = 0;
            total = 2 * (width + height - 2);
        }

        public void Step(int num)
        {
            if (num == 0) return;

            num = num % total;

            if (num == 0 && pos[0] == 0 && pos[1] == 0)
            {
                dir = 3;
                return;
            }

            if (dir == 0)
            {
                pos[0] += num;

                if (pos[0] > limit[0])
                {
                    num = pos[0] - limit[0];
                    pos[0] = limit[0];
                    dir = 1;
                    Step(num);
                }

                return;
            }

            if (dir == 1)
            {
                pos[1] += num;

                if (pos[1] > limit[1])
                {
                    num = pos[1] - limit[1];
                    pos[1] = limit[1];
                    dir = 2;
                    Step(num);
                }

                return;
            }

            if (dir == 2)
            {
                pos[0] -= num;

                if (pos[0] < 0)
                {
                    num = -pos[0];
                    pos[0] = 0;
                    dir = 3;
                    Step(num);
                }

                return;
            }

            if (dir == 3)
            {
                pos[1] -= num;

                if (pos[1] < 0)
                {
                    num = -pos[1];
                    pos[1] = 0;
                    dir = 0;
                    Step(num);
                }

                return;
            }
        }

        public int[] GetPos()
        {
            return pos;
        }

        public string GetDir()
        {
            if (dir == 0) return "East";

            if (dir == 1) return "North";

            if (dir == 2) return "West";

            return "South";
        }
    }

    /**
     * Your Robot object will be instantiated and called as such:
     * Robot obj = new Robot(width, height);
     * obj.Step(num);
     * int[] param_2 = obj.GetPos();
     * string param_3 = obj.GetDir();
     */
}
