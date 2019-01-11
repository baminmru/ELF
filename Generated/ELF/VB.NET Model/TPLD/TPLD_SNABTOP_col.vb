
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace TPLD


''' <summary>
'''Реализация раздела Поставщикв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLD_SNABTOP_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "TPLD_SNABTOP"
        End Function



''' <summary>
'''Вернуть даные текущей коллекции в виде DataTable
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function CreateDataTable() As System.Data.DataTable
            Dim dt As DataTable
            dt = New DataTable
            dt.TableName="TPLD_SNABTOP"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("CNAME", Gettype(System.string))
            dt.Columns.Add("CADDRESS", Gettype(System.string))
            dt.Columns.Add("CFIO", Gettype(System.string))
            dt.Columns.Add("CPHONE", Gettype(System.string))
            dt.Columns.Add("CREGION", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New TPLD_SNABTOP
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As TPLD.TPLD_SNABTOP
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(TPLD.TPLD_SNABTOP))
catch ex as System.Exception
 Debug.Print( ex.Message + " >> " + ex.StackTrace)
end try
        End Function


''' <summary>
'''Получить элемент коллекции, более свежий вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Shadows Function Item( vIndex as object ) As TPLD.TPLD_SNABTOP
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("TPLD_SNABTOPID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", cname" 
           mFieldList =mFieldList+ ", caddress" 
           mFieldList =mFieldList+ ", cfio" 
           mFieldList =mFieldList+ ", cphone" 
           mFieldList =mFieldList+ ", cregion" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
