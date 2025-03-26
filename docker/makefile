.PRONY: up migrate

up:
	docker-compose up -d

migrate:
	dotnet ef database update -s ../src/MedCare.API -p ../src/MedCare.DAL.Postgres
