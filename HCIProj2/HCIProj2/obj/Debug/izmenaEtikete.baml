   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5   	   C ?HCIProj2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:HCIProj2HCIProj2 5   	   #clr-namespace:HCIProj2HCIProj2 5   	   7 clr-namespace:HCIProj2.ShortcutsHCIProj2.Shortcuts 5	   	      HCIProj2.izmenaEtikete   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   -
validationclr-namespace:HCIProj2     5   	   (localclr-namespace:HCIProj2     5   	   5commands clr-namespace:HCIProj2.Shortcuts     5	   	     � Title$  izmeni etiketu��5   	   $	��700��6    $
��1100��6-    � 	Resources 5       �� 
TargetType �� Property �� Value��%R   '_�       �� 5   
   " _�6)   .�5      ��  � ��$ 30(�6)   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$' !commands:Precice.ZatvoriProzorCmd��5      6E     5   
   -   5        $&  commands:Precice.EtiketaEnterCmd��5      6D   .��5      � .+�5   
   �� $
��Auto=�6   .��5      �� $��0 0 10 0q�6   .+�5      �� $��Izmena etikete��6   $��38(�62   $��Center=�6@   6_   � 5      $��	0 30 0 15q�6    � ColumnDefinitions 5       �� 5!      �� 5"      $��2* �6+   .+�5$      �� $	��ID:��6    $��38(�6+   $��0��69   $��0��6F   $
��Bold"�6V   $��Center=�6h   $��Center=�6�   6�   �� 5%      -   5        $��textB_id��5%   E    �� 
IsReadOnly . 	 �� AcceptsReturn	 . $��0��6�   $��1��6�   
 �� TextWrapping$

 Wrap=�6�   $��5q�6�   $��38(�6�   .��6�   ��5&      �� 5'       �� Path$ Id�6&    �� UpdateSourceTrigger$ 	LostFocus=�60    �� NotifyOnValidationError .  �� ValidationRules 5(   "     HCIProj2.Duzina_Provera  5)   &   ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�6@      polje$ Id��6b   
   Min$ 3��6m   
   Max$ 45��6u   5+      .��5,   )    =� ErrorTemplate 5-      �� 5.      .R�5/   "   � .+�50   &   ��  ��Name$ textBox��6B   �� 51   &   $
��Wrap=�60   $��0 60 0 5q�6D   $��38(�6W   
���  ����6e   �� *[0].ErrorContent+6�   52   #   53      .��54   4   55      56      � 5:      $��	0 35 0 15q�6    5;      �� 5<      �� 5=      $��2* �6+   .+�5?      �� $��Opis:��6    $��38(�6-   $
��Bold"�6;   $��Center=�6M   $��Center=�6h   6�   �� 5@      -   5        $��
textB_opis��5@   3   	 . $

 Wrap=�6i   $��1��6}   $��5q�6�   $	��100��6�   $��38(�6�   .��6�   ��5A      �� 5B      $
 Opis�6&   $ 	LostFocus=�62    .  5C   "     5D   &   $ RawProposedValue=�6@   $
 Opis��6b   $ 3��6o   $	 600��6w   5F      .��5G   (    5H      �� 5I      .R�5J   "   � .+�5K   &   �� $ textBox��6B   �� 5L   &   $
��Wrap=�60   $��0 90 0 5q�6D   $��38(�6W   
���  ����6e   �� *[0].ErrorContent+6�   5M   #   5N      .��5O   4   5P      5Q      � 5T      $��	0 40 0 15q�6    5U      �� 5V      �� 5W      $��2* �6+   .+�5Y      �� $��Boja:��6    $��38(�6-   $
��Bold"�6;   $��Center=�6M   $��Center=�6h   6�   �� 5Z      -   5        $��combo_color��5Z   /   $��1��6    �� SelectedIndex$ 0��6B   .@�5[      �� .��5\      �� $��38(�6(   $	��700��66   
����  �
����  �$
��Blue��6f   6t   5]      �� 5^      .��5_      �� $��38(�6(   $	��700��66   
��� ���
��� ���$��Yellow��6j   6z   5`      �� 5a      .��5b      �� $��38(�6(   $	��700��66   
�������
�������$
��Pink��6f   6t   5c      �� 5d      .��5e      �� $��38(�6(   $	��700��66   
��� ���
��� ���$��Orange��6j   6z   5f      �� 5g      .��5h      �� $��38(�6(   $	��700��66   
��� � �
��� � �$��Green��6h   6w   5i      �� 5j      .��5k      �� $��38(�6(   $	��700��66   
���**��
���**��$��Brown��6h   6w   5l      �� 5n      .��5o      �� $��38(�6(   $	��700��66   
���  ��
���  ��$	��Red��6d   6q   5p      5q      5r      � 5u      $��	0 30 0 10q�6    5v      �� 5w      �� 5x      $��* �6+   �� 5y      $��* �6+   .+�5{      �� -   5        $��Brisanje��5{      $��5 5 5 5q�6-   $��38(�6U   $��60��6c   $��Brisanje��6o   6�   �� 5|      -   5        $��Izlaz��5|      $��5 5 5 5q�6*   $��38(�6O   $��60��6]   $��1��6i   $��Izlaz��6y   6�   �� 5}      -   5        $��Sacuvaj��5}      $��5 5 5 5q�6B   $��38(�6S   $��60��6a   $��2��6m   $��Sacuvaj��6}   6�   5~      5�      5�      5�      5�      