   M S B A M L   `   `   `  ����H  DPanel Gościa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Panel_GościaPanel_Gościa  5   	       Panel_Gościa.admin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Panel_Gościa     5   	     � Title$  admin��5   	   $	��600��6   $	��480��6$    � 
ResizeMode$ NoResize=�60   .��5	      �  � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      �� 5      $��80 �6   .+�5   
   � $
��Left=�6   $��30��6*   $	��Top=�66   $	��480��6N   ���#e1f5fe.+�5      �� -   5         ��Name$ 	lbl_Witaj��5      $��Witaj Adminie: ��6'   $��Center=�6A   $��Center=�6^   $	��480��6y   $��30��6�   $��0��6�   5      �� 5   
   -   5         ��Name$ btnProjekcja��5      $��Układ Startu��6'   $
��Left=�6>   $��80��6Y   $��80��6d   $��2��6p   $��-5,0,0,0q�6�   �� 5   
   -   5        $ btnDodajBadanie��5      $��Dodaj Badanie��6+   $
��Left=�6C   $	��Top=�6^   $��80��6v   $��80��6�   $��2��6�   $��75,0,0,0q�6�   6�   �� 5   
   -   5        $ btnEdytujBadanie��5      $
��Left=�6,   $	��Top=�6G   $��80��6_   $��80��6j   $��2��6v   $��	155,0,0,0q�6�   ��5      �� 5      $
��Wrap=�6   $��Edytuj Badanie��60   5      �� 5   
   -   5        $ btnDodajOsobe��5      $��Dodaj Osobe��6(   $
��Left=�6>   $��	235,0,0,0q�6Y   $	��Top=�6l   $��80��6�   $��80��6�   $��2��6�   6�   �� 5   
   -   5        $ btnEdytujOsobe��5      $
��Left=�6)   $��	315,0,0,0q�6D   $	��Top=�6W   $��80��6o   $��80��6z   $��2��6�   ��5      �� 5      $
��Wrap=�6   $��Edytuj Osobe��60   5       � 5!   
   -   5          �Name$ AdminContent��5!      $
��Left=�6'   $	��440��6B   $��1��6O   $	��Top=�6\   $��480                ��6t     � NavigationUIVisibility$ Hidden=�5"      $��0,0,-6,0q�62   �� 5#   
   -   5        $ 
btnWyloguj��5#      $��Wyloguj��6%   $
��Left=�67   $��
395,0,-6,0q�6R   $��2��6f   $	��Top=�6s   $��85��6�   $��80��6�   6�   �� 5$   
   -	   5        $ 
btnraporty��5$      $��Raporty��6%   $
��Left=�67   $��80��6R   $��80��6]   $��1��6i   $��
-5,381,0,0q�6�   5%      5&      