namespace API_EF_Hash_Token.API.Forms
{
    public class FileForm
    {
        public string Directory { get; private set; }
        public IFormFile File { get; set; }

        public FileForm()
        {
            Directory = "C:\\Users\\n.daddabbo\\Desktop\\Labo\\Labo_Api\\API_EF_Hash_Token.API\\wwwroot\\Images";
        }
    }
}
