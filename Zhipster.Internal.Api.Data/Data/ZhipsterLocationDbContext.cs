using Microsoft.EntityFrameworkCore;
using Zhipster.Internal.Api.Data.Models;

namespace Zhipster.Internal.Api.Data.Data
{
	public class ZhipsterLocationDbContext : DbContext
	{
		public ZhipsterLocationDbContext(DbContextOptions<ZhipsterLocationDbContext> options) : base(options)
		{
		}

		//Tables
		public DbSet<ZipCodeSource> ZipCodeSources { get; set; }
		public DbSet<ForwarderZipCodeSource> ForwarderZipCodeSources { get; set; }
		public DbSet<SEZipCode> SEZipCodes { get; set; }
		public DbSet<NOZipCode> NOZipCodes { get; set; }
		public DbSet<DKZipCode> DKZipCodes { get; set; }
		public DbSet<FIZipCode> FIZipCodes { get; set; }
		public DbSet<NLZipCode> NLZipCodes { get; set; }
		public DbSet<DEZipCode> DEZipCodes { get; set; }
		public DbSet<USZipCode> USZipCodes { get; set; }
		public DbSet<BEZipCode> BEZipCodes { get; set; }
		public DbSet<FOZipCode> FOZipCodes { get; set; }
		public DbSet<GLZipCode> GLZipCodes { get; set; }
		public DbSet<ISZipCode> ISZipCodes { get; set; }
		public DbSet<SJZipCode> SJZipCodes { get; set; }
	}
}