   M S B A M L   `   `   `  ????K  GFarmersMarketApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FarmersMarketAppFarmersMarketApp  5   	       FarmersMarketApp.Admin   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:FarmersMarketApp     5   	     ? Title$  Admin??5   	   $	??450??6   $	??800??6$   .??5	      ? ??5
   
   ?? 5       j? Stretch$
 Fill=?6   .+?5   
   ?? -   5        $??	Home Page??5      $
??Left=?6%   $??442,349,0,0q?6@   $	??Top=?6U   $??42??6m   $	??264??6y   $
??Bold"?6?   $??SemiCondensed&?6?   $??Comic Sans MS)?6?    J? Opacity$	 0.6Q?6?   $??0q?6  #??[" ?6"  $??16(?6]  ??6?   Z?  ? 	Resources 5       ?? 
TargetType ?? Property ?? Value??%^   '??       ?? 5      " ??6   .?5      ??  ?@??CornerRadius$ 5??65   5      5      5      ?? 5   
   $??Product Name??6   $
??Left=?6'   $??
208,29,0,0q?6B   $??Comic Sans MS)?6V   $	??Top=?6q   $??16(?6?   $	??142??6?   ???	#FF1716166?   ?? 5   
   $??
Product ID??6   $
??Left=?6%   $??
208,82,0,0q?6@   $??Comic Sans MS)?6T   $	??Top=?6o   $??16(?6?   $	??142??6?   ???	#FF1716166?   ?? 5   
   $??Amount ( kg )??6   $
??Left=?6(   $??208,143,0,0q?6C   $??Comic Sans MS)?6X   $	??Top=?6s   $??16(?6?   $	??142??6?   ???	#FF1716166?   ?? 5   
   $??Price (CAD) / kg??6   $
??Left=?6+   $??192,205,0,0q?6F   $??Comic Sans MS)?6[   $	??Top=?6v   $??16(?6?   $	??142??6?   ???	#FF1716166?   ?? 5   
   -   5         ??Name$ p_name??5      $
??Left=?6"   $??
377,34,0,0q?6=    ?? TextWrapping$
 Wrap=?6Q   $	??Top=?6e   $	??231??6}   $??16(?6?   ?? 5   
   -   5        $ p_price??5      $
??Left=?6#   $??377,210,0,0q?6>   $
 Wrap=?6S   $	??Top=?6g   $	??231??6   $??16(?6?   ?? 5   
   -   5        $ p_amount??5      $
??Left=?6$   $??377,148,0,0q?6?   $
 Wrap=?6T   $	??Top=?6h   $	??231??6?   $??16(?6?   ?? 5   
   -   5        $
 p_id??5      $
??Left=?6    $??
377,87,0,0q?6;   $
 Wrap=?6O   $	??Top=?6c   $	??231??6{   $??16(?6?   ?? 5   
   -   5        	 ??Name$	 update??5      $??Update??6!   $??442,277,0,0q?62   $	??Top=?6G   $??42??6_   $	??102??6k   $
??Bold"?6?   $??SemiCondensed&?6?   $??Comic Sans MS)?6?   $	 0.6Q?6?   $??0q?6  $??16(?6  $
??Left=?6#  ??6?   Z?  5      ??%^   '??       ?? 5      " ??6   .?5      ??  ?@??CornerRadius$ 5??65   5       5!      ??5"      ?? 5#      
 ?? ResourceKey#
 Z ?6!   5%      ?? 5&   
   -   5        $	 insert??5&      $??Insert??6!   $
??Left=?62   $??127,277,0,0q?6M   $	??Top=?6b   $??42??6z   $	??102??6?   $
??Bold"?6?   $??SemiCondensed&?6?   $??Comic Sans MS)?6?   $	 0.6Q?6  $??0q?6  $??16(?60  ??6?   Z?  5'      ??%^   '??       ?? 5(      " ??6   .?5)      ??  ?@??CornerRadius$ 5??65   5*      5+      ??5,      ?? 5-      #
 Z ?6!   5/      ?? 50   
   -   5        $	 delete??50      $??Delete??6!   $
??Left=?62   $??298,277,0,0q?6M   $	??Top=?6b   $??42??6z   $	??102??6?   $
??Bold"?6?   $??SemiCondensed&?6?   $??Comic Sans MS)?6?   $	 0.6Q?6  $??0q?6  $??16(?60  ??6?   Z?  51      ??%^   '??       ?? 52      " ??6   .?53      ??  ?@??CornerRadius$ 5??65   54      55      ??56      ?? 57      #
 Z ?6!   59      ?? 5:   
   -	   5        $	 search??5:      $??Search??6!   $
??Left=?62   $??604,277,0,0q?6M   $	??Top=?6b   $??42??6z   $	??102??6?   $
??Bold"?6?   $??SemiCondensed&?6?   $??Comic Sans MS)?6?   $	 0.6Q?6  $??0q?6  $??16(?60  ??6?   Z?  5;      ??%^   '??       ?? 5<      " ??6   .?5=      ??  ?@??CornerRadius$ 5??65   5>      5?      ??5@      ?? 5A      #
 Z ?6!   5C      ?? 5D   
   -
   5        $??List All Data??5D      $
??Left=?6)   $??127,349,0,0q?6D   $	??Top=?6Y   $??42??6q   $	??273??6}   $
??Bold"?6?   $??SemiCondensed&?6?   $??Comic Sans MS)?6?   $	 0.6Q?6  $??0q?6  $??16(?6)  ??6?   Z?  5E      ??%^   '??       ?? 5F      " ??6   .?5G      ??  ?@??CornerRadius$ 5??65   5H      5I      ??5J      ?? 5K      #
 Z ?6!   5M      5O      5P      