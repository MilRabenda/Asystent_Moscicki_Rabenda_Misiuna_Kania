   M S B A M L   `   `   `  ����H  DPanel Gościa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Panel_GościaPanel_Gościa  5   	       Panel_Gościa.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Panel_Gościa     5   	   $��5q�5      ���#e1f5fe  � Title$  Login��5   	   $	��250��6   $	��200��6$    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�6   .��5      �  � RowDefinitions 5   
   �� 5      $��22 �6   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   � -   5        ���#e1f5fe5      �� 5   
   -   5         ��Name$ txtLogin��5      $��Center=�5      $��24��6/   $��Center=�5      $	��120��6-   $��37,10,33,10q�5      $��2��5       �� TextAlignment$ Center=�6B   .��6t   5      G� 5   
   -   5         G�Name$ txtPassword��5      $
��Left=�5       $��23��5!      $��Center=�5"      $	��120��5#      $��
37,10,0,11q�6   $��4��5$      $��Center=�6M   5&      �� 5(   
   -   5         ��Name$ btnLogin��5(      $��Zaloguj��6#   $	��100��5)      $��30��5+      $��Center=�5,      $��Center=�6,   $��5��5-      ��5.      �� 5/       �� 
TargetType" ��6   .�50      �� 	 �� Property	 �@�Cursor
 �� Value$

 Hand��6/   �� 51      	 � ��
 �#49a7cc63    �� Triggers 52      P� 53       P� Property �@J�IsMouseOver P� Value . . �54      �� 	 � ��
 �#b5ffff6;   55      57      ��59      �� 5:       �� 
TargetType" ��6"   .R�5;      �� $	��100��6   $��25��6)    �� CornerRadius$ 12��5<   !   #��z��5=   !   ._�5>      �� $��Center=�6+   $��Center=�6F   5?      5@      5B      �� 5D   
   -   5        $ btnClose��5D      $��X��6   $��Right=�5E      $	��Top=�5F      $��25��5G      $��22��6   $��16(�5H      
���   �$
��Bold"�5I   $   $��0��5L      $	��Top=�6!   $��Center=�6@   ��5M      �� 5N      " ��6   .�5O      �� 	 �@�Cursor$

 Hand��6/   �� 5P      	 � ��
 �#49a7cc63    5Q      P� 5R       �@J�IsMouseOver . . �5S      �� 	 � ��

 �  ��6;   5T      5V      ��5X      �� 5Y      " ��6"   .R�5Z      �� #��z��5\   !   ._�5]      �� $��Center=�6+   $��Center=�6F   5^      5_      5a      5b      5c      