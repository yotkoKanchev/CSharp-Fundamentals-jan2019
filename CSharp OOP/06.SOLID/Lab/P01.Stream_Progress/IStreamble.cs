namespace P01.Stream_Progress
{
    public interface IStreamble
    {
        int Length { get; set; }

        int BytesSent { get; set; }
    }
}
