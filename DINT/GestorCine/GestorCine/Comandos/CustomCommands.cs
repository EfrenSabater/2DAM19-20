using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestorCine.Comandos
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand AgregarSala = new RoutedUICommand(
            "AgregarSala", "AgregarSala", typeof(CustomCommands));

        public static readonly RoutedUICommand ModificarSala = new RoutedUICommand(
            "ModificarSala", "ModificarSala", typeof(CustomCommands));
    }
}
