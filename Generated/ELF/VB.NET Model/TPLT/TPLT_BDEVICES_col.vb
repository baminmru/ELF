
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace TPLT


''' <summary>
'''Реализация раздела Описаниев виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLT_BDEVICES_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "TPLT_BDEVICES"
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
            dt.TableName="TPLT_BDEVICES"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("TheNode_ID" , GetType(System.guid))
            dt.Columns.Add("TheNode", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("ThePhone", Gettype(System.string))
            dt.Columns.Add("Addr", Gettype(System.string))
            dt.Columns.Add("DEVType_ID" , GetType(System.guid))
            dt.Columns.Add("DEVType", Gettype(System.string))
            dt.Columns.Add("Shab_ID" , GetType(System.guid))
            dt.Columns.Add("Shab", Gettype(System.string))
            dt.Columns.Add("DevGrp_ID" , GetType(System.guid))
            dt.Columns.Add("DevGrp", Gettype(System.string))
            dt.Columns.Add("THESCHEMA_ID" , GetType(System.guid))
            dt.Columns.Add("THESCHEMA", Gettype(System.string))
            dt.Columns.Add("TheServer_ID" , GetType(System.guid))
            dt.Columns.Add("TheServer", Gettype(System.string))
            dt.Columns.Add("NPLOCK", GetType(System.DateTime))
            dt.Columns.Add("CONNECTED_VAL" , Gettype(System.Int16))
            dt.Columns.Add("CONNECTED", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New TPLT_BDEVICES
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As TPLT.TPLT_BDEVICES
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(TPLT.TPLT_BDEVICES))
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
        Public Shadows Function Item( vIndex as object ) As TPLT.TPLT_BDEVICES
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("TPLT_BDEVICESID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("TheNode") 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", thephone" 
           mFieldList =mFieldList+ ", addr" 
           mFieldList =mFieldList+","+.ID2Base("DEVType") 
           mFieldList =mFieldList+","+.ID2Base("Shab") 
           mFieldList =mFieldList+","+.ID2Base("DevGrp") 
           mFieldList =mFieldList+","+.ID2Base("THESCHEMA") 
           mFieldList =mFieldList+","+.ID2Base("TheServer") 
           mFieldList =mFieldList+","+.Date2Base("NPLOCK") 
           mFieldList =mFieldList+ ", connected" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
