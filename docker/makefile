.PRONY: up migrate front

up:
	docker-compose up -d

migrate:
	dotnet ef database update -s ../src/MedCare.API -p ../src/MedCare.DAL.Postgres

front:
	cd ../src/medcare-ui/ && code .

