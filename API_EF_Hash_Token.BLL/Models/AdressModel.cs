using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class AdressModel
    {
        public int AdressId { get; init; }
        public int Number { get; set; }
        public string CityName { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }


        /// <summary>
        /// Constructeur pour récupérer les adresses
        /// </summary>
        /// <param name="number">Le numéro</param>
        /// <param name="cityName">Le nom de la ville</param>
        /// <param name="street">Le nom de la rue</param>
        /// <param name="country">Le nom du pays</param>
        public AdressModel(int number, string cityName, string street, string country)
        {
            this.Number = number;
            this.CityName = cityName;
            this.Street = street;
            this.Country = country;
        }
        /// <summary>
        /// Constructeur pour créer une adresse
        /// </summary>
        /// <param name="adressId">L'id de l'adresse</param>
        /// <param name="number">Le numéro</param>
        /// <param name="cityName">Le nom de la ville</param>
        /// <param name="street">Le nom de la rue</param>
        /// <param name="country">Le nom du pays</param>
        /// <param name="country"></param>
        public AdressModel(int adressId, int number, string cityName, string street, string country)
            : this(number, cityName, street, country)
        {
            this.AdressId = adressId;
        }
    }
}
