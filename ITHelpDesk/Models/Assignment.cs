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
    /// Assignment class will keep track of the IT Staff assigned to a ticket.
    /// </summary>

    [Table("Assignment")]
    public partial class Assignment
    {
        public int AssignmentId { get; set; }

        public DateTime? AssignmentDate { get; set; }

        [StringLength(1024)]
        public string AssignmentComment { get; set; }

        public int TicketId { get; set; }

        public int ITStaffId { get; set; }

        public virtual ITStaff ITStaff { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
