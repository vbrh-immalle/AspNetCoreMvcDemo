using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteAspNetCoreMvcIdentity.Models
{
    public class Vraag
    {
        public int Id { get; set; }

        // De tekst die de vraag omschrijft
        public string Tekst { get; set; }

        // Een (eventuele) afbeelding die bij de vraag gebruikt wordt
        public string Afbeelding { get; set; }

        // Wanneer de laatste wijzigingen aan een vraag zijn gebeurd.
        // Dit kan handig zijn wanneer er b.v. typefouten zijn opgelost nadat deze vraag al gebruikt is in een Vragenlijst.
        public DateTime LaatsteWijziging { get; set; }

        // De te behalven punten voor deze Vraag (optioneel als het zonder punten is)
        public double MaxPunten { get; set; }

        // De leerkracht kan extra opmerkingen aan deze Vraag toevoegen die enkel zichtbaar is voor de leerkracht
        // b.v. een verbetersleutel
        public string Opmerkingen { get; set; }

        // Alle vragenlijsten waarin deze Vraag voorkomt (meestal slechts 1 voor een test)
        public virtual ICollection<Vragenlijst> Vragenlijsten { get; set; }

        // Alle antwoorden van alle leerlingen die op deze Vraag zijn gegeven (ook van b.v. vorige jaren)
        public virtual ICollection<Antwoord> Antwoorden { get; set; }
    }
}
