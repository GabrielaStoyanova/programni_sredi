   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UI.ComponentsUI.Components  5      %clr-namespace:UI.Extras	UI.Extras  5           UI.Components.StudentsList   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:UI.Components     5      *extrasclr-namespace:UI.Extras     5        � 	Resources  5
      !   UI.Extras.PasswordConverter   PasswordConverter��%   &	          5   
   6#   5      .��5      � .+�5   
   �� .+�5      &   System.Windows.Controls.DataGrid  -   5        $��students��5   /      AutoGenerateColumns$ False��6?   ��6   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      
IsReadOnly$
 True��64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *Id+  5      $ Names��6)   $
 True��68    6J   �� *Names+  5      $ Password��6)   $
 True��6;    6M   �� *
Password+ �� 	Converter# [   �� ConverterParameter$ Password��  5      $
 Role��6)   $
 True��67    6I   �� *Role+  5      $ 
Expires In��6)   $
 True��6=    6O   �� *	Expires+5      �� 5      -   5         �� DisplayMemberPath$
 Date��5   5   ��6   �� *Events+6N   5      5      5      