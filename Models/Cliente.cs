using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteAPI.Models
{
    [Table("Clientes")] // <-- Nombre real de la tabla en la base de datos
    public class Cliente
    {
        [Column("Id")] // Opcional, pero recomendable si no se llama "Id"
        public int Id { get; set; }

        [Column("Nombre")] // Opcional: solo si el campo en la tabla se llama diferente
        public string Nombre { get; set; }

        [Column("Correo")] // Igual que arriba
        public string Correo { get; set; }
    }
}
