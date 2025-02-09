namespace MedCare.DAL.Entities;

// "Я – основа всех сущностей, но я сам по себе не существую".
// Работаем с ним через наследников
public abstract class BaseEntity
{
    public Guid Id { get; set; }
}