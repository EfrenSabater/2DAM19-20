   M S B A M L   `   `   `  ����E  AGestorCine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GestorCine
GestorCine  5   	   9!clr-namespace:GestorCine.ComandosGestorCine.Comandos  5   	       GestorCine.GestionarSalas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GestorCine     5   	   6commands!clr-namespace:GestorCine.Comandos     5   	     � Title$  GestionarSalas��5	   	   $	��650��5
   	   $	��900��5   	   $	��800��5   	   $
��1200��5   	    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$% commands:CustomCommands.Agregar��5      5        5   
   -   5        $' !commands:CustomCommands.Modificar��5      5       � 	Resources 5       �� 
TargetType   datosStackPanel �� Property �� Value  estadoTextBlock �� BasedOn �� Triggers	 �� Binding
 �� Path �� Value  modificarTextBlock  hiddenStackPanel  noDisponibleComboBoxItem��%  &	        '�� �     &	 4    7��&	 �    &	     &	 $    �� 5   
   " ��6   .�5      ��  �@��Orientation$ Vertical=�6,   6?   �� 5       � ��$ Center=�64   6E   5      �� 5   
   " ��6   .�5      ��  � ��$ 40(�6)   66   �� 5        � ��$ Center=�64   6E   �� 5!       � ��$ 0,0,0,5q�6'   69   5"      �� 5$   
   " ��6   8    5%      �� 5&      	 6   �� $!
 SalaSeleccionada.Disponible� True6S   .a�5'      ��  � ��
 � � �6C   �� 5(       � ��$ 
DISPONIBLE��6-   6B   5)      �� 5*      	 6   �� $!
 SalaSeleccionada.Disponible�	 False6S   .a�5+      ��  � ��
 �  ��6A   �� 5,       � ��$ NO DISPONIBLE��6-   6E   5-      5/      �� 51   
   " ��6   .�52      ��  � ��$ 10(�6)   66   53      �� 55   
   " ��6   .�56      ��  �@��Orientation$ Vertical=�6,   6?   �� 57       � ��$ 0,30,0,0q�6'   6:    58      �� 59      	 6   �� $
 	NuevaSala� 6A   Z� .a�5:      ��  � y�$ Hidden=�63   6D   5;      5=      �� 5?   
   " ��6    5@      �� 5A      	 6   �� $!
 SalaSeleccionada.Disponible�	 false6S   .a�5B      ��  �@��
IsSelected . 6B   5C      5E      5F      .��5H      ]� ��. .+�5I   
   �� $��Bottom=�6    �� Orientation$ Vertical=�5J      $��10q�5K      $	��250��5L      .+�5M      �� #��[  6   .+�5N      �� Número de sala6,   �� 5O        separadorBorder#��[ 6   ._�5P      �� ��6    �� $
 SalaSeleccionada.Numero�6P   5Q      5R      � 5S       � ColumnDefinitions 5T      �� 5U      6)   �� 5V      6)   .+�5X      �� $��0��6   #��[  5Y      .+�5Z      �� 	Capacidad6+   �� 5[      #��[ 6   ._�5\      �� ��6$   �� $ 
 SalaSeleccionada.Capacidad�6W   5]      5_      �� 5`      $��1��6   #��[  5a      .+�5b      �� Estado6(   �� 5c      #��[ 6   ._�5d      �� #��[ 6$   6O   5e      5f      5g      5h      �� 5j   
   $��Right=�6   $ Vertical=�5k      $��10q�5l      $	��200��5m      .+�5n      �� $%��commands:CustomCommands.Agregar��6     stackedButton#��[ 5o      .��6<   Agregar sala6J   �� 5p      $'��!commands:CustomCommands.Modificar��6   #��[ 5q      .��6<   Modificar sala6L   �� 5r      #��[ 6   .+�5s      �� #��[ 6   Modificando la sala:6^   �� 5t      {�.  ��5u      �� $
 NuevaSala.Numero�6C   �� 5v      #��[ 6   Capacidad de la sala:6_   �� 5w      ��6   �� $
 NuevaSala.Capacidad�6F   �� 5x      #��[ 6   Disponibilidad de la sala:6d   �� 5y      .@�5z      ��  �� 
IsSelected 6#   �� *NuevaSala.Disponible+.��6O   
Disponible6[   �� 5{      #��[ 6#   .��6U   No disponible6d   5|      � 5}       5~      �� 5      6-   �� 5�      6-   .+�5�      �� -   5         ��Name$ guardarCambiosButton��5�      $��0��5�        guardarCancelarButton#��[ 5�      .��5�   @   	Guardar6I   �� 5�      -   5        $ cancelarCambiosButton��5�      $��1��5�      #��[ 5�      .��5�   A   
Cancelar6K   5�      5�      5�      �� 5�   
   $	��2pxq�6   $��10q�5�      ._�5�      �� $
��Auto=�6   $
��Auto=�5�      .��5�      �� ��6   �� $
 
ListaSalas� �� SelectedItem 5�      �� $
 SalaSeleccionada���5�      �� 5�      .R�5�      �� $��30(�6(   �� 5�   "   $�Sala ��6&   65    �� 5�   "   �6&   �� $
 Numero�6E   5�      5�      5�      5�      5�      5�      5�      