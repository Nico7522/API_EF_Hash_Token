namespace API_EF_Hash_Token.API.Forms
{
    public class FileForm
    {
        public string Directory { get; set; }
        public IFormFile File { get; set; }

        public FileForm()
        {
            Directory = "C:\\Users\\n.daddabbo\\source\\repos\\API_EF_Hash_Token\\API_EF_Hash_Token.API\\wwwroot\\Images";
        }
    }
}
