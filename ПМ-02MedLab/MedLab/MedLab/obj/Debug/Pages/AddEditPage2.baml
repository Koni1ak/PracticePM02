   M S B A M L   `   `   `  ����A  =MedLab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MedLab.PagesMedLab.Pages  5          MedLab.Pages.AddEditPage2   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MedLab.Pages     5        N� Title$  AddEditPage2��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $:��4Название страховой компании��6   
�������67   �� 5   
   $��
Сумма��6   $��1��6!   
�������6.   �� 5   
   -   5         ��Name$ 
ComboGroup��5   T   $��1��6D    �� DisplayMemberPath$ insurance_name��6h   $��	5,0,278,0q�6�    �� SelectedItem 6   �� *0.ДанныеСтраховыхКомпаний+6�   �� 5   
   $��3��6)   $��1��69   $	��120��6F   $
��Left=�6R   ��6   �� *
Сумма+6R   �� 5   
   -   5        $��BtnSave��5   F   $��Сохранить��6   $��2��6%   $��5��69   6U   5      5      