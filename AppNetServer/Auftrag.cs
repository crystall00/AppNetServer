//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppNetServer
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Auftrag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Auftrag()
        {
            this.Offerte = new HashSet<Offerte>();
        }
    
        public int auftragsNummer { get; set; }
        public Nullable<System.DateTime> erstelldatum { get; set; }
        public string titel { get; set; }
        public string beschreibung { get; set; }
        public string ort { get; set; }
        public Nullable<System.DateTime> ausschreibungsende { get; set; }
        public long Id { get; set; }
        public bool ausgeschrieben { get; set; }
    
        [JsonIgnore]
        public virtual Auftraggeber Auftraggeber { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Offerte> Offerte { get; set; }
    }
}
