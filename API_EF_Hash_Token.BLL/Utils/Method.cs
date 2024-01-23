using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Utils
{
    internal static class Method
    {

        // Méthode pour vérifier l'extension de l'image
        internal static bool VerifyExtension(string fileName)
        {
            string extension = fileName.Substring(fileName.Length - 3);
            bool isAuthorized = false;
            string[] authorizedExtensions = new string[] { "jpg", "png" };

            foreach (var ext in authorizedExtensions)
            {
                if (ext == extension) isAuthorized = true;
            }
            return isAuthorized;
        }
    }
}
