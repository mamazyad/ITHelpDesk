/*
* Description: This application is a web-based incident tracking system for IT Help Desks. 
* Author: mamazyad
* Due date: 27/02/2018
*/

namespace ITHelpDesk.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// DbContext class is the bridge between the entity classes and the database. It is responsible for interacting with the database.
    /// </summary>

    public partial class ITHelpDeskDbContext : DbContext
    {
        public ITHelpDeskDbContext()
            : base("name=ITHelpDeskDbContext")
        {
        }

        public virtual DbSet<Assignment> Assignments
        {
            get; set;
        }
        public virtual DbSet<Category> Categories
        {
            get; set;
        }
        public virtual DbSet<Criterion> Criteria
        {
            get; set;
        }
        public virtual DbSet<Employee> Employees
        {
            get; set;
        }
        public virtual DbSet<Feedback> Feedbacks
        {
            get; set;
        }
        public virtual DbSet<ITHelpDeskAdmin> ITHelpDeskAdmins
        {
            get; set;
        }
        public virtual DbSet<ITStaff> ITStaffs
        {
            get; set;
        }
        public virtual DbSet<KnowledgeBase> KnowledgeBases
        {
            get; set;
        }
        public virtual DbSet<Staff> Staffs
        {
            get; set;
        }
        public virtual DbSet<Ticket> Tickets
        {
            get; set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Criterion>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.Criterion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.ITStaff)
                .WithRequired(e => e.Employee);

            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.Staff)
                .WithRequired(e => e.Employee);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITStaff>()
                .HasMany(e => e.Assignments)
                .WithRequired(e => e.ITStaff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITStaff>()
                .HasMany(e => e.Categories)
                .WithRequired(e => e.ITStaff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITStaff>()
                .HasOptional(e => e.ITHelpDeskAdmin)
                .WithRequired(e => e.ITStaff);

            modelBuilder.Entity<ITStaff>()
                .HasMany(e => e.KnowledgeBases)
                .WithRequired(e => e.ITStaff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.TicketsAccelarated)
                .WithOptional(e => e.Accelerator)
                .HasForeignKey(e => e.AccelaratedBy);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.TicketsCreated)
                .WithRequired(e => e.StaffOwner)
                .HasForeignKey(e => e.TicketOwner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Assignments)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);
        }
    }
}
