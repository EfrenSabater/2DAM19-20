   M S B A M L   `   `   `  ����E  AGestorCine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GestorCine.VentanasGestorCine.Ventanas  5   	   9!clr-namespace:GestorCine.ComandosGestorCine.Comandos  5   	   )    #GestorCine.Ventanas.GestionarVentas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GestorCine.Ventanas     5   	   6commands!clr-namespace:GestorCine.Comandos     5   	     � Title$  GestionarVentas��5	   	   $	��800��5
   	   $
��1000��5   	   $	��800��5   	   $
��1000��5   	    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$% commands:CustomCommands.Agregar��5      5       � 	Resources 5       �� 
TargetType �� Property �� Value   mainComboBox  MaterialDesignComboBox �� BasedOn  MaterialDesignRaisedButton��%�  '��       '�� z     &	  5    7  '�� �    7  �� 5   
   " ��6   .�5      ��  � ��$ 30(�6)   66   �� 5       � ��$ Center=�62   6C   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   6C   �� 5       �@��Orientation$ Vertical=�6,   6?   �� 5       � ��$ 0,30,0,0q�6'   6:   5      �� 5    
   " ��6   8   .�5!      ��  � ��$ 40��6'   64   �� 5"       � ��$ 0,10,0,0q�6'   6:   5#      �� 5%   
   " ��6   8   .�5&      ��  � ��$ Center=�64   6E   �� 5'       � ��$	 250��6&   64   �� 5(       � ��$ 50��6'   64   �� 5)       � ��$ 30(�6)   66   5*      5+      .��5,      � $��20q�6    � RowDefinitions 5-   
   �� 5.      6   �� 5/      6   �� 50      6   �� 51      6   .+�53   
   �� $��0��6   .+�54      ]� ��.  .+�55      �� $
��Left=�6   
Sesión:6<   �� 56      -   5        	 ��Name$	 consultarSalasButton��59      $��Right=�56      $	��200��57      $��20(�58      .��5:   <   Consultar salas6M   5I      �� 5J      #��[  6   ��5K      �� 
 �� Path$
 ListaSesiones� �� SelectedItem 5L      �� $
 NuevaVenta.Sesion���5M      �� 5N      .R�5O      �� �� 5P      $�
Pelicula: ��6"   66    �� 5Q      �6"   �� $
 Pelicula.Titulo�6J    �� 5R      $�
 |  Hora: ��6"   66    �� 5S      �6"   �� $

 Hora�6?    �� 5T      $�
 |  Sala: ��6"   66    �� 5U      �6"   �� $
 Sala.Numero�6F   5V      5W      5Y      5Z      �� 5[   
   $��1��6   .+�5\      �� Número de entradas:6-   �� 5]      $��40��6   $��0,10,0,0q�5^      ��5_      �� $
 NuevaVenta.Cantidad�6B   5`      �� 5a   
   $��2��6   .+�5b      �� Método de pago:6*   �� 5c      #��[  6    �� SelectedValue 5d      �� $
 NuevaVenta.Pago�.@�5e      �� .��6   
Efectivo6)   �� 5f      .��6   	Tarjeta6(   �� 5g      .��6   Bizum6&   5h      5i      �� 5j   
   $��3��6   .+�5k      �  � ColumnDefinitions 5l      �� 5m      6)   �� 5n      6)   .+�5p      �� $��0��6   $%��commands:CustomCommands.Agregar��5q      .��6C   	Confirmar6N   �� 5r      -   5        $	 limpiarButton��5s      $��1��5r      .��5t   5   	Limpiar6>   5u      5v      5w      5x      