migrate_create:
	@dotnet ef migrations add $(name) --startup-project Vjezba.Web --context ClientManagerDbContext --project Vjezba.DAL

migrate_latest:
	@dotnet ef database update --startup-project Vjezba.Web --context ClientManagerDbContext --project Vjezba.DAL

migrate_remove:
	@dotnet ef migrations remove --startup-project Vjezba.Web --context ClientManagerDbContext --project Vjezba.DAL


migrate:
	@dotnet ef database update $(name) --startup-project Vjezba.Web --context ClientManagerDbContext --project Vjezba.DAL
