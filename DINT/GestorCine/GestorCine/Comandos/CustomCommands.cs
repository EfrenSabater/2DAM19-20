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
        public static readonly RoutedUICommand Agregar = new RoutedUICommand(
            "Agregar", "Agregar", typeof(CustomCommands));

        public static readonly RoutedUICommand Modificar = new RoutedUICommand(
            "Modificar", "Modificar", typeof(CustomCommands));

        public static readonly RoutedUICommand Eliminar = new RoutedUICommand(
            "Eliminar", "Eliminar", typeof(CustomCommands));

        public static readonly RoutedUICommand Actualizar = new RoutedUICommand(
            "Actualizar", "Actualizar", typeof(CustomCommands));
    }
}
