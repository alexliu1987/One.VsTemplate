namespace $safeprojectname$.Infrastructure
{
    public class FileInfoDto
    {
        public bool Result { get; set; }
        public string Path { get; set; }
        public string Message { get; set; }
        public object FileInfo { get; set; }
    }
}