using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class CityFromExternalSystem
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Inhabitants { get; set; }

        public CityFromExternalSystem(string name , string nickname , int inhabitants)
        {
            Name = name;
            NickName = nickname;
            Inhabitants = inhabitants;
        }
    }

    public class ExternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("antwepr", "'t Stad'", 500000);
        }
    }

    public class City
    {
        public string FullName { get; set; }
        public long Inhabitants { get; set; }

        public City(string fullName,long inhabitants)
        {
            FullName = fullName;
            Inhabitants = inhabitants;
        }

    }

    public interface ICityAdapter
    {
        City GetCity();
    }

    public class CityAdapter : ICityAdapter
    {
        public ExternalSystem ExternalSystem { get; set; } = new();
        public City GetCity()
        {
            // call into the external system
            var cityFromExternalSystem = ExternalSystem.GetCity();
            //adapt the cityFromExternalCity to a City
            return new City(
            $"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}", cityFromExternalSystem.Inhabitants);
        }
    }


}
