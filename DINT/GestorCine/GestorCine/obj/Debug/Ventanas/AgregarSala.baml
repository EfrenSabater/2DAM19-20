   M S B A M L   `   `   `  ����E  AGestorCine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GestorCine.VentanasGestorCine.Ventanas  5   	   9!clr-namespace:GestorCine.ComandosGestorCine.Comandos  5   	   %    GestorCine.Ventanas.AgregarSala   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GestorCine.Ventanas     5   	   6commands!clr-namespace:GestorCine.Comandos     5   	     � Title$  AgregarSala��5	   	   $	��350��5
   	   $	��450��5   	    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�5   	    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$% commands:CustomCommands.Agregar��5      5       � 	Resources 5       �� 
TargetType   MaterialDesignRaisedButton �� BasedOn �� Property	 �� Value  MaterialDesignTextBox  MaterialDesignComboBox��%�  '��       7   '�� �     7  '�� �     '�� *    7  �� 5   
   " ��6   8   .�5      ��  � ��$	 Center=�64   6E   �� 5       � ��$		 150��6&   64   5      �� 5   
   " ��6   8   .�5      ��  � ��$	 0,0,0,30q�6'   6:   5      �� 5   
   " ��6   .�5      ��  � ��$	 0,0,0,5q�6'   69   5       �� 5"   
   " ��6   8   .�5#      ��  � ��$	 0,5,0,0q�6'   69   5$      5%      .��5'      ]� ��.  $��10q�5(      .+�5)   
   �� $	��Top=�6   
 �� Orientation$
 Vertical=�5*      .+�5+      �� Número de sala6(   �� 5,      ��6   ��  �� Path$ NuevaSala.Numero�6?   �� 5-      Capacidad de la sala6.   �� 5.      ��6   �� $ NuevaSala.Capacidad�6B   �� 5/      Disponibilidad6(   �� 50      .@�51      ��  �� 
IsSelected 6   �� $ NuevaSala.Disponible�.��6P   
Disponible6\   �� 52      .��6   No disponible6.   53      54      � 55   
   $��Bottom=�6    � ColumnDefinitions 56      �� 57      6%   �� 58      6%   .+�5:      �� $��0��6   $%��commands:CustomCommands.Agregar��5;      .��6?   	Agregar6H   �� 5<      -   5         ��Name$ cancelarButton��5=      $��1��5<      .��5>   2   
Cancelar6<   5?      5@      5A      