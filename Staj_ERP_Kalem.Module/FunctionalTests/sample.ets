;#DropDB Staj-ERP-KalemEasyTest

#Application Staj-ERP-KalemWin
;#Application Staj-ERP-KalemWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef Staj-ERP-KalemWin

*Action About...
 
*Action OK

#EndIf

#IfDef Staj-ERP-KalemWeb
*Action Navigation(My Details)
#EndIf
