using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLiteAspNetCoreMvcIdentity.Models
{
    public class AntwoordCommentaar
    {
        public int Id { get; set; }

        // Wie heeft deze commentaar gegeven, b.v.
        // leerkracht die opmerkingen geeft bij een Antwoord
        // of leerling die een verbetering toevoegt
        virtual public ApplicationUser Eigenaar { get; set; }

        public string Commentaar { get; set; }

        public DateTime LaatsteWijziging { get; set; }
    }
}
