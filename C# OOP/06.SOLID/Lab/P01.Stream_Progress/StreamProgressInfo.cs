namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamble stream;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamble stream)
        {
            this.stream = stream;
        }

        public int CalculateCurrentPercent()
        {
            return (this.stream.BytesSent * 100) / this.stream.Length;
        }
    }
}
