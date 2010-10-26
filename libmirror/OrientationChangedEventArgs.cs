namespace Mirror
{
    public class OrientationChangedEventArgs 
    {
        public Orientation Orientation { get; protected set; }

        public OrientationChangedEventArgs(Orientation orientation)
        {
            Orientation = orientation;
        }
    }
}