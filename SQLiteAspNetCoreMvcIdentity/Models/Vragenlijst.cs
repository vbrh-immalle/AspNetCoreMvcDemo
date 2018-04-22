using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteAspNetCoreMvcIdentity.Models
{
    public class Vragenlijst
    {
        public int Id { get; set; }

        // De Eigenaar van een Vragenlijst, meestal een leerkracht
        public ApplicationUser Eigenaar { get; set; }

        // Een titel die gegeven wordt aan de vragenlijst
        public string Titel { get; set; }

        // Eventuele extra informatie over de vragenlijst (zichtbaar voor leerlingen)
        public string Omschrijving { get; set; }

        // Eventuele extra opmerkingen enkel zichtbaar voor de leerkracht
        public string Opmerkingen { get; set; }

        // Wanneer er de laatste keer een vraag werd toegevoegd of verwijderd of de titel veranderd werd
        public DateTime LaatsteWijziging { get; set; }

        // Of de Vragenlijst op punten staat
        public bool Gequoteerd { get; set; }

        // Elke Vraag die tot deze Vragenlijst behoort
        public virtual ICollection<Vraag> Vragen { get; set; }
    }
}
