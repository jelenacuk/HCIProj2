   M S B A M L   `   `   `  ����C  ?HCIProj2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:HCIProj2HCIProj2  5   	   7 clr-namespace:HCIProj2.ShortcutsHCIProj2.Shortcuts  5   	       HCIProj2.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:HCIProj2     5   	   5commands clr-namespace:HCIProj2.Shortcuts     5   	   -   5          � Title$  
MainWindow��5	   	   $	��750��6   $
��1240��6)    � 	Resources 5       �� 
TargetType �� Property �� Value��%R   '_�       �� 5   
   " _�6)   .�5      ��  � ��$ 30(�6)   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$+ %commands:Precice.IzlistajSakrijLokale��5      6I     5   
   -   5        $$ commands:Precice.DodajLokalCmd��5      6B     5   
   -   5        $&  commands:Precice.DodajEtiketuCmd��5      6D     5   
   -   5        $" commands:Precice.DodajTipCmd��5      6@     5   
   -   5        $' !commands:Precice.PrikaziLokaleCmd��5      6E     5   
   -   5        $( "commands:Precice.PrikaziEtiketeCmd��5      6F     5   
   -   5        $' !commands:Precice.PrikaziTipoveCmd��5      6E     5   
   -	   5        $ commands:Precice.PomocCmd��5      6=     5   
   -
   5        $ commands:Precice.NazadCmd��5      6=     5   
   -   5        $( "commands:Precice.PretragaNaMapiCmd��5      6F   .��5      ]� .+�5    
   o� $	��Top=�6   .@�5!      m� -   5        $��Izlistaj��5!       m� Command$+ %commands:Precice.IzlistajSakrijLokale��6(   $��_Sakrij Lokale��6X   $��34(�6p   $��1q�6~   
���   � � ToolTip$5 /Sakriva listu lokala koji nisu na mapi - CTRL+I��6�   5"      �� 5#      6   m� 5$      $��_Dodaj��6   $��34(�6'   $��1q�65   
���   �.@�5%      m� $$ commands:Precice.DodajLokalCmd��6   $��_Dodaj Lokal��6D   $��34(�6Z   	 m� InputGestureText$	 Ctrl+Q��6h   m� 5&      $&  commands:Precice.DodajEtiketuCmd��6   $��_Dodaj Etiketu��6F   $��34(�6^   $	 Ctrl+W��6l   m� 5'      $" commands:Precice.DodajTipCmd��6   $��34(�6B   $��
_Dodaj Tip��6P   $	 Ctrl+E��6d   5(      �� 5)      m� 5*      $��	_Prikaži��6   $��34(�6)   $��1q�67   
���   �.@�5+      m� $' !commands:Precice.PrikaziLokaleCmd��6   $��_Prikaži Lokale��6G   $��34(�6`   $	 Alt+Q��6n   m� 5,      $( "commands:Precice.PrikaziEtiketeCmd��6   $��_Prikaži Etikete��6H   $��34(�6b   $	 Alt+W��6p   m� 5-      $' !commands:Precice.PrikaziTipoveCmd��6   $��_Prikaži Tipove��6G   $��34(�6`   $	 Alt+E��6n   5.      �� 5/      m� 50      -   5        $	��PNM��50      $��Pretraga��6"   $��34(�65   $��1q�6C   
���   �$( "commands:Precice.PretragaNaMapiCmd��6k   $' !Pretraži lokale na mapi - CTRL+P��6�   51      �� 52      6   m� 53      -   5        $��Nazad��53   )   {�.  $ commands:Precice.NazadCmd��66   $��_Nazad��6Z   $��34(�6j   $��1q�6x   
���   �$) #Povratak na odabir gradova = CTRL+N��6�   6�   �� 54      6   m� 55      -   5        $��Pomoc��55      $ commands:Precice.NazadCmd��6%   $��_Pomoc��6I   $��34(�6Y   $��1q�6g   
���   �.@�56      m� $ commands:Precice.PomocCmd��6   $��_Online Pomoc��6?   $��34(�6V   $	 Ctrl+F1��6d   m� 57      -   5        $��	tutorijal��57   4   $��
_Tutorijal��6E   $��34(�6Y   58      5:      ]� 5;   
   .+�5<      �� -   5        
 ��Name$
 ListaLokala��5<   `   $
��Left=�6   $��0 40 0 0q�6N   $��0��6u   $��0��6�   ��6.   �� *Lokali+ � ContextMenu 5=      �� 5>      $��25(�6"   .@�5?      m� -   5        $��Ažuriraj lokal��5?   #    m� Icon 5@      �� 5A   "   $��Images/update.jpg��6(   $��20��6C   $��20��6O   $
��Left=�6Z   5C      m� 5D      -   5        $��Obriši lokal��5D   #    5E      �� 5F   "   $��Images/remove.png��6(   $��20��6C   $��20��6O   $
��Left=�6Z   5H      5I      ��5K      �� 5L      .R�5M      � .+�5N      �� $��45��6?   ��6$   �� *	Ikonica+6?   �� 5O      $��25(�6<   $��Center=�6J   ��6(   �� *Id+6J   �� 5P      $��  ��6(   $��25(�62   $��Center=�6@   �� 5Q      $��25(�6?   $��Center=�6M   ��6(   �� *Naziv+6M   5R      5S      5U      �� 5V      $��Right=�6   
�������._�5W      (�  (� Stretch$
 Fill=�6   .��5X      �� -   5        $��
MainScroll��5X   #   $	��900��65   $	��550��6A   $��Visible=�6N   .��5Y      �� 
�������._�5Z      (� $
 Fill=�6&    �� PanningMode$
 Both=�65   ��. $��Visible=�6z   $��Visible=�6�   .��5[   "   �� -   5        $
��Mapa��5[   D   $
��1650��6*   $	��900��67    J� 	AllowDrop . ��5\   &   �� 5]   *   ��. $
 Both=�6Z    j� 
AlignmentX$
 Left=�6�    j� 
AlignmentY$	 Top=�6�    j� Stretch$ Uniform=�6�    �� ImageSource 6z   �� *
MapaPath+6�    5_   &   �� 5`   *   -   5        $��contextMenu��5`   D   $��25(�66   .@�5a   .   m� -   5        $��Ažuriraj lokal��5a   7    5b   2   �� 5c   6   $��Images/update.jpg��6<   $��20��6W   $��20��6c   $
��Left=�6n   5e   /   m� 5f   .   -   5        $��Ukloni sa mape��5f   7    5g   2   �� 5h   6   $��Images/java.png��6<   $��20��6U   $��20��6a   $
��Left=�6l   5j   /   m� 5k   .   -   5        $��Obriši lokal��5k   7    5l   2   �� 5m   6   $��Images/remove.png��6<   $��20��6W   $��20��6c   $
��Left=�6n   5o   /   5p   +   5s   #   5t      5u      5v      5w      5x      5y      5{      5|      