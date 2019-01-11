
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace TPLT


''' <summary>
'''Реализация раздела Граничные значенияв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLT_VALUEBOUNDS_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "TPLT_VALUEBOUNDS"
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
            dt.TableName="TPLT_VALUEBOUNDS"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("PNAME_ID" , GetType(System.guid))
            dt.Columns.Add("PNAME", Gettype(System.string))
            dt.Columns.Add("PTYPE_ID" , GetType(System.guid))
            dt.Columns.Add("PTYPE", Gettype(System.string))
            dt.Columns.Add("PMIN", GetType(System.double))
            dt.Columns.Add("PMAX", GetType(System.double))
            dt.Columns.Add("ISMIN_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ISMIN", Gettype(System.string))
            dt.Columns.Add("ISMAX_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ISMAX", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New TPLT_VALUEBOUNDS
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As TPLT.TPLT_VALUEBOUNDS
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(TPLT.TPLT_VALUEBOUNDS))
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
        Public Shadows Function Item( vIndex as object ) As TPLT.TPLT_VALUEBOUNDS
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("TPLT_VALUEBOUNDSID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("PNAME") 
           mFieldList =mFieldList+","+.ID2Base("PTYPE") 
           mFieldList =mFieldList+ ", pmin" 
           mFieldList =mFieldList+ ", pmax" 
           mFieldList =mFieldList+ ", ismin" 
           mFieldList =mFieldList+ ", ismax" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
