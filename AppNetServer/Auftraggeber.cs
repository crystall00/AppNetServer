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
    
    public partial class Auftraggeber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Auftraggeber()
        {
            this.Auftrag = new HashSet<Auftrag>();
            this.UserClaim = new HashSet<UserClaim>();
            this.UserLogin = new HashSet<UserLogin>();
            this.Role = new HashSet<Role>();
        }
    
        public long Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public string adresse { get; set; }
        public string profilbild { get; set; }
        public string telefonnummer { get; set; }
        public string SecurityStamp { get; set; }
        public bool IsConfirmed { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Auftrag> Auftrag { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<UserClaim> UserClaim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<UserLogin> UserLogin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Role> Role { get; set; }
    }
}
