   M S B A M L   `   `   `  ����H  DPanel Gościa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Panel_GościaPanel_Gościa  5   	   !    Panel_Gościa.PanelPacjenta   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Panel_Gościa     5   	     � Title$  PanelPacjenta��5   	   $	��500��6   $	��410��6,    � 
ResizeMode$ NoResize=�68   .��5	      � .+�5
   
   � $
��Left=�6   $��50��6*   $	��Top=�66   $	��392��6N   ���#e1f5fe.+�5      �� -   5         ��Name$ 	lbl_Witaj��5      $��Center=�6(   $��10q�6E   $��Center=�6Q   $	��372��6l   $��30��6x   5      � 5   
   $	��100��6   $��0,0,0,0q�6   $��Bottom=�6-    � ColumnDefinitions 5      �� 5      $
��131* �6#   �� 5      $
��273* �6#   .+�5      �� -   5         ��Name$ btn_ZapiszWizytę��5      $��zapisz��6/   $
��Left=�6@   $	��Top=�6[   $	��100��6s   $	��100��6   5      �� 5      -   5        $ 	btn_Konto��5      $��konto��6)   $
��Left=�69   $��	169,0,0,0q�6T   $	��Top=�6g   $	��100��6   $	��100��6�   $��1��6�   5      �� 5      -   5        $ btn_idk��5      $
��Left=�6&   $��wyloguj��6B   $��	100,0,0,0q�6T   $	��Top=�6g   $	��100��6   $	��100��6�   $��2��6�   5      �� 5      -   5        $ 
btn_Wizyty��5      $
��Left=�6*   $��wizyty��6E   $��69,0,0,0q�6V   $	��Top=�6h   $	��100��6�   $	��100��6�   $��1��6�   5      5       � 5   
   -   5          �Name$ wizFrame��5        � NavigationUIVisibility$ Hidden=�6%   $
��Left=�6E   $	��321��6`   $��	0,50,-6,0q�6m   $	��Top=�6�   $	��410��6�   5!      5"      