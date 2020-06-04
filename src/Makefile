migrate_create:
	@dotnet ef migrations add $(name) --startup-project Student2.Server --context AppDbContext --project Student2.DAL

migrate_latest:
	@dotnet ef database update --startup-project Student2.Server --context AppDbContext --project Student2.DAL

migrate_remove:
	@dotnet ef migrations remove --startup-project Student2.Server --context AppDbContext --project Student2.DAL

migrate_reset:
	@dotnet ef database update 0 --startup-project Student2.Server --context AppDbContext --project Student2.DAL
	@dotnet ef migrations remove --startup-project Student2.Server --context AppDbContext --project Student2.DAL

migrate:
	@dotnet ef database update $(name) --startup-project Student2.Server --context AppDbContext --project Student2.DAL
