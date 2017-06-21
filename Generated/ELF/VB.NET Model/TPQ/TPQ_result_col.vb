
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace TPQ


''' <summary>
'''Реализация раздела Результат обработкив виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPQ_result_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "TPQ_result"
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
            dt.TableName="TPQ_result"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("TextResult", Gettype(System.string))
            dt.Columns.Add("MomentArch_ID" , GetType(System.guid))
            dt.Columns.Add("MomentArch", Gettype(System.string))
            dt.Columns.Add("HourArch_ID" , GetType(System.guid))
            dt.Columns.Add("HourArch", Gettype(System.string))
            dt.Columns.Add("DayArch_ID" , GetType(System.guid))
            dt.Columns.Add("DayArch", Gettype(System.string))
            dt.Columns.Add("TotalArch_ID" , GetType(System.guid))
            dt.Columns.Add("TotalArch", Gettype(System.string))
            dt.Columns.Add("IsError_VAL" , Gettype(System.Int16))
            dt.Columns.Add("IsError", Gettype(System.string))
            dt.Columns.Add("LogMessage", Gettype(System.string))
            dt.Columns.Add("StartTime", GetType(System.DateTime))
            dt.Columns.Add("EndTime", GetType(System.DateTime))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New TPQ_result
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As TPQ.TPQ_result
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(TPQ.TPQ_result))
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
        Public Shadows Function Item( vIndex as object ) As TPQ.TPQ_result
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("TPQ_resultID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", textresult" 
           mFieldList =mFieldList+","+.ID2Base("MomentArch") 
           mFieldList =mFieldList+","+.ID2Base("HourArch") 
           mFieldList =mFieldList+","+.ID2Base("DayArch") 
           mFieldList =mFieldList+","+.ID2Base("TotalArch") 
           mFieldList =mFieldList+ ", iserror" 
           mFieldList =mFieldList+ ", logmessage" 
           mFieldList =mFieldList+","+.Date2Base("StartTime") 
           mFieldList =mFieldList+","+.Date2Base("EndTime") 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
