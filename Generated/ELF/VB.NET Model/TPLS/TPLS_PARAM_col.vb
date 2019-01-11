
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace TPLS


''' <summary>
'''Реализация раздела Параметры на схемев виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLS_PARAM_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "TPLS_PARAM"
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
            dt.TableName="TPLS_PARAM"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("ArchType_ID" , GetType(System.guid))
            dt.Columns.Add("ArchType", Gettype(System.string))
            dt.Columns.Add("Param_ID" , GetType(System.guid))
            dt.Columns.Add("Param", Gettype(System.string))
            dt.Columns.Add("POS_LEFT", GetType(System.double))
            dt.Columns.Add("POS_TOP", GetType(System.double))
            dt.Columns.Add("HIDEPARAM_VAL" , Gettype(System.Int16))
            dt.Columns.Add("HIDEPARAM", Gettype(System.string))
            dt.Columns.Add("HideOnSchema_VAL" , Gettype(System.Int16))
            dt.Columns.Add("HideOnSchema", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New TPLS_PARAM
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As TPLS.TPLS_PARAM
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(TPLS.TPLS_PARAM))
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
        Public Shadows Function Item( vIndex as object ) As TPLS.TPLS_PARAM
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("TPLS_PARAMID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("ArchType") 
           mFieldList =mFieldList+","+.ID2Base("Param") 
           mFieldList =mFieldList+ ", pos_left" 
           mFieldList =mFieldList+ ", pos_top" 
           mFieldList =mFieldList+ ", hideparam" 
           mFieldList =mFieldList+ ", hideonschema" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
