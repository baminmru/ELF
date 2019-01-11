
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace TPSRV


''' <summary>
'''Реализация раздела Модемыв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPSRV_MODEMS_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "TPSRV_MODEMS"
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
            dt.TableName="TPSRV_MODEMS"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("PortNum", Gettype(System.string))
            dt.Columns.Add("IsUsable_VAL" , Gettype(System.Int16))
            dt.Columns.Add("IsUsable", Gettype(System.string))
            dt.Columns.Add("IsUsed_VAL" , Gettype(System.Int16))
            dt.Columns.Add("IsUsed", Gettype(System.string))
            dt.Columns.Add("UsedUntil", GetType(System.DateTime))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New TPSRV_MODEMS
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As TPSRV.TPSRV_MODEMS
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(TPSRV.TPSRV_MODEMS))
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
        Public Shadows Function Item( vIndex as object ) As TPSRV.TPSRV_MODEMS
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("TPSRV_MODEMSID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", portnum" 
           mFieldList =mFieldList+ ", isusable" 
           mFieldList =mFieldList+ ", isused" 
           mFieldList =mFieldList+","+.Date2Base("UsedUntil") 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
