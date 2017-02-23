using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryTool.ViewModels
{
    public class UserView
    {
        public string UserID { get; set; }

        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public RoleView Role { get; set; } // Titulos de los encabezados.

        public List<RoleView> Roles { get; set; }
    }
}