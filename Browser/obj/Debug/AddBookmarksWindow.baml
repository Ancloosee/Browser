   M S B A M L   `   `   `  ����B  >Browser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BrowserBrowser  5   	        Browser.AddBookmarksWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Browser     5   	     � Title$  AddBookmarksWindow��5   	    � WindowStyle$ SingleBorderWindow=�6$   $	��150��6E   $	��300��6R   $	��150��6^   $	��150��6n   $	��300��6~   $	��300��6�   .��5
   
   �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��Center=�6   $��Center=�6.   $��0��6I   $��0��6Y   $��4��6f   ._�5      �� $+��%Добавление закладки��6   $��20(�63   6C   5      �� 5    
   $��0��6   $��1��6!   ._�5!      �� $��20(�6   $��Center=�6&   $��Center=�6C   Имя6c   5"      �� 5$   
   -   5        $��NameTB��5$      $��1��6    $��3��60   $��1��6D   $��5q�6Q   6^   �� 5&   
   $��Center=�6   $��Center=�6.   $��0��6I   $��2��6Y   ._�5'      �� $��20(�6   URl6+   5(      �� 5*   
   -   5        $��URLTB��5*      $��1��6   $��3��6/   $��2��6C   $��5q�6P   6]   �� 5,   
   -   5        $��Cancel��5,   C   $��3��6&   $��1��63   $��5q�6Q   .��6\   Отменить6f   �� 5-   
   -   5        $��OK��5-   ?   $��3��6"   $��3��6/   $��5q�6I   .��6T   Готово6\   5/      50      