   M S B A M L   `   `   `  ����A  =MedLab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MedLab.PagesMedLab.Pages  5          MedLab.Pages.BuhPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MedLab.Pages     5      j fSyncfusion.SfGridConverter.WPF, Version=20.1460.0.58, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.SfGrid.WPF, Version=20.1460.0.58, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.Wpf, Version=20.1460.0.58, Culture=neutral, PublicKeyToken=3d67ed1f87d44c896
syncfusion!http://schemas.syncfusion.com/wpf    5      -   5          N� Title$  BuhPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $	��377 �6   �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGrid��5         AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+6H     5      $: 4Название страховой компании��6%   $	 200 6�    6J   �� *?=ДанныеСтраховыхКомпаний.insurance_name+6�     5      $ 
Сумма��6%   $	 150 6N    64   �� *
Сумма+6N   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 auto 6)   	   CellTemplate	 5      �� 5      .R�5      �� 
 ��Name$
 BtnEdit��6=   -   5        $ ��Редактировать��5   %   
���   �6d   5      5      5      �� 5   
   -   5        $
 BtnAdd��5   L   $��Добавить��6   $��1��6$   $
��Left=�61   6\   �� 5    
   -   5        $
 	BtnDelete��5    L   $��Удалить��6   $��1��6#   $��Right=�60   6_   �� 5!   
   -   5        $
 Export��5!   K   $��Экспорт��6   $��1��6#   $
��Left=�60   $��	185,0,0,0q�6p   5%      5&      