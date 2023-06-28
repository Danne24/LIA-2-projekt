## Zhipster Location Database Helper

# Create a new migration script compares classes to snapshotfile.
Add-Migration "Initial DB"  -Context ZhipsterLocationDbContext -StartupProject Zhipster.Internal.Api.Location -OutputDir "Migrations/" -Project Zhipster.Internal.Api.Data -Verbose 

# Execute migrations scripts against sql server
Update-Database -Context ZhipsterLocationDbContext -StartupProject Zhipster.Internal.Api.Location -Project Zhipster.Internal.Api.Data -Verbose

# Revert to target migration script
Update-Database –TargetMigration: "201709281135067_Initial DB"

