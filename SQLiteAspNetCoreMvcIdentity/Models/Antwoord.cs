using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteAspNetCoreMvcIdentity.Models
{
    public class Antwoord
    {
        public int Id { get; set; }

        // De leerling die een vraag beantwoord heeft
        public virtual ApplicationUser Eigenaar { get; set; }

        // De vraag die beantwoord is
        public virtual Vraag Vraag { get; set; }

        // Het antwoord dat een leerling geeft (optioneel)
        public string Tekst { get; set; }

        // Een afbeelding die de leerling upload (optioneel)
        public string Afbeelding { get; set; }

        // Wanneer het antwoord (Tekst of Afbeelding) voor het laatste gewijzigd is
        // Tijdens een test kan een antwoord b.v. nog gewijzigd worden
        public DateTime LaatsteWijziging { get; set; }
        
        // Mogen leerlingen nog wijziging aanbrengen?
        // Na afloop van b.v. een test wordt alle vragen van de test afgesloten.
        // Een Vraag of Vragenlijst kan niet afgesloten worden: er zijn altijd wijzigingen mogelijk (b.v. typefouten).
        // Er moet door de gebruikers wel op gelet worden dat een Vraag niet zodanig veranderd wordt, dat deze niet meer overeenstemd met de vraag.
        // Dit kan met een waarschuwing (als er al Antwoorden gegeven zijn op een Vraag).
        public bool Afgesloten { get; set; }
    }
}
