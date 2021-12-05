namespace day05
{
    public class Line
    {
        public int x1;
        public int y1;
        public int x2;
        public int y2;


        public Line(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public override string ToString()
        {
            return $"{this.x1},{this.y1} : {this.x2},{this.y2}";
        }
    }

}