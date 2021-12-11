namespace AdventOfCode._2021._11
{
    public class DumboOctopus
    {
        public DumboOctopus(int energy)
        {
            Energy = energy;
            Handled = false;
        }
        
        public int Energy { get; private set; }
        public bool Handled { get; private set; }

        public void NextStep()
        {
            Energy += 1;
            Handled = false;
        }

        public void Flash()
        {
            Energy = 0;
            Handled = true;
        }

        public void Touch()
        {
            if (Energy != 0)
                Energy += 1;
        }
    }
}