
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace TPQ


''' <summary>
'''Реализация раздела Описаниев виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPQ_DEF_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "TPQ_DEF"
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
            dt.TableName="TPQ_DEF"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("TheSessionID_ID" , GetType(System.guid))
            dt.Columns.Add("TheSessionID", Gettype(System.string))
            dt.Columns.Add("TheDevice_ID" , GetType(System.guid))
            dt.Columns.Add("TheDevice", Gettype(System.string))
            dt.Columns.Add("ArchType_ID" , GetType(System.guid))
            dt.Columns.Add("ArchType", Gettype(System.string))
            dt.Columns.Add("ArchTime", GetType(System.DateTime))
            dt.Columns.Add("QueryTime", GetType(System.DateTime))
            dt.Columns.Add("IsUrgent_VAL" , Gettype(System.Int16))
            dt.Columns.Add("IsUrgent", Gettype(System.string))
            dt.Columns.Add("RepeatTimes", Gettype(System.Int32))
            dt.Columns.Add("RepeatInterval", Gettype(System.Int32))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New TPQ_DEF
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As TPQ.TPQ_DEF
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(TPQ.TPQ_DEF))
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
        Public Shadows Function Item( vIndex as object ) As TPQ.TPQ_DEF
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("TPQ_DEFID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("TheSessionID") 
           mFieldList =mFieldList+","+.ID2Base("TheDevice") 
           mFieldList =mFieldList+","+.ID2Base("ArchType") 
           mFieldList =mFieldList+","+.Date2Base("ArchTime") 
           mFieldList =mFieldList+","+.Date2Base("QueryTime") 
           mFieldList =mFieldList+ ", isurgent" 
           mFieldList =mFieldList+ ", repeattimes" 
           mFieldList =mFieldList+ ", repeatinterval" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
