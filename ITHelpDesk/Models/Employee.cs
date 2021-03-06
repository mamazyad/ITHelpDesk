/*
* Description: This application is a web-based incident tracking system for IT Help Desks. 
* Author: mamazyad
* Due date: 27/02/2018
*/

namespace ITHelpDesk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Employee class pertains to all the employees in a company using the IT Help Desk system.
    /// </summary>

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(128)]
        public string Username { get; set; }

        [StringLength(128)]
        public string FirstName { get; set; }

        [StringLength(128)]
        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }

        [StringLength(128)]
        public string JobTitle { get; set; }

        [StringLength(128)]
        public string Department { get; set; }

        [StringLength(128)]
        public string ExtensionNumber { get; set; }

        [StringLength(128)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(128)]
        public string OfficeNumber { get; set; }

        public virtual ITStaff ITStaff { get; set; }

        public virtual Staff Staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
