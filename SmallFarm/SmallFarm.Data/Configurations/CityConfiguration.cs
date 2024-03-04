using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallFarm.Data.Entities;

namespace SmallFarm.Data.Configurations
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(SeedCities());
        }

        private static List<City> SeedCities()
        {
            List<string> bulgarianCities = new List<string>
            {
                "Sofia", "Plovdiv", "Varna", "Burgas", "Ruse", "Stara Zagora", "Pleven", "Sliven", "Dobrich", "Shumen",
                "Haskovo", "Pernik", "Yambol", "Blagoevgrad", "Veliko Tarnovo", "Gabrovo", "Vratsa", "Montana", "Vidin",
                "Razgrad", "Silistra", "Kyustendil", "Targovishte", "Lovech", "Kurdzhali", "Teteven", "Popovo", "Svishtov",
                "Sandanski", "Kazanlak", "Dimitrovgrad", "Harmanli", "Kardzhali", "Dupnitsa", "Panagyurishte", "Gotse Delchev",
                "Petrich", "Berkovitsa", "Karnobat", "Sevlievo", "Nova Zagora", "Radomir", "Troyan", "Pazardzhik", "Botevgrad",
                "Samokov", "Svilengrad", "Kyustendil", "Gorna Oryahovitsa", "Karnobat", "Radomir", "Troyan", "Pazardzhik",
                "Botevgrad", "Samokov", "Svilengrad", "Gorna Oryahovitsa", "Kyustendil", "Chirpan", "Byala Slatina", "Troyan",
                "Dupnitsa", "Radnevo", "Kozloduy", "Cherven Bryag", "Radomir", "Simeonovgrad", "Kavarna", "Bobov Dol", "Roman",
                "Pavel Banya", "Topolovgrad", "Dolni Chiflik", "Tvarditsa", "Isperih", "Dryanovo", "Suvorovo", "Dve Mogili",
                "Varshets", "Mizia", "Belene", "Kuklen", "General Toshevo", "Letnitsa", "Knezha", "Malko Tarnovo", "Tsarevo",
                "Rudozem", "Devin", "Dalgopol", "Alfatar", "Antonovo", "Apriltsi", "Batak", "Belogradchik", "Beloslav",
                "Bozhurishte", "Bregovo", "Breznik", "Brusartsi", "Chernomorets", "Devin", "Dospat", "Dulovo", "Elena",
                "Elin Pelin", "Etropole", "Glavinitsa", "Gramada", "Gulubovo", "Gurkovo", "Ivaylovgrad", "Kableshkovo",
                "Kalofer", "Kavarna", "Kirkovo", "Kostenets", "Laki", "Levski", "Loznitsa", "Madan", "Madzharovo", "Merichleri",
                "Momchilgrad", "Nessebar", "Nikolaevo", "Nikopol", "Omurtag", "Opaka", "Panagyurishte", "Parvomay", "Pavel Banya",
                "Pirdop", "Pomorie", "Radomir", "Rakitovo", "Rila", "Roman", "Sarnitsa", "Satovcha", "Septemvri", "Simeonovgrad",
                "Slavyanovo", "Smyadovo", "Sopot", "Stamboliyski", "Straldzha", "Strazhitsa", "Strumyani", "Sungurlare", "Sveti Vlas",
                "Tervel", "Topolovgrad", "Tran", "Tsarevo", "Tutrakan", "Ugarchin", "Valchedram", "Varbitsa", "Vetovo", "Zavet",
                "Alfatar", "Antonovo", "Aytos", "Belene", "Belitsa", "Bozhurishte", "Brusartsi", "Chernomorets", "Cherven Bryag",
                "Dospat", "Dulovo", "Elhovo", "Gulyantsi", "Isperih", "Kableshkovo", "Kostenets", "Levski", "Madzharovo",
                "Merichleri", "Nessebar", "Nikopol", "Opaka", "Parvomay", "Pirdop", "Pomorie", "Rakitovo", "Rila", "Roman",
                "Septemvri", "Smyadovo", "Sopot", "Suvorovo", "Tervel", "Tran", "Tutrakan", "Ugarchin", "Valchedram", "Varbitsa"
            };

            List<City> list = new List<City>();
            int id = 0;
            foreach (var city in bulgarianCities.Distinct().OrderBy(c => c))
            {
                id++;
                list.Add(new City() { Id = id, Name = city });
            }

            return list;
        }
    }
}
