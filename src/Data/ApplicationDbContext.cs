using filedChallenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace filedChallenge.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) {

        }
        public DbSet<Payment> Payments {get; set;}
        public DbSet<PaymentState> PaymentStates {get; set;}
    }
}