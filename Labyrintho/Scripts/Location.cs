namespace Labyrintho
{
    public struct Location
    {
        //Variables for location
        public float x { get; set; }
        public float y { get; set; }
        
        //Sets location
        public Location (float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
