
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace bpdi


''' <summary>
'''Реализация раздела Модульв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class iu_int_modules_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "iu_int_modules"
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
            dt.TableName="iu_int_modules"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Sequence", Gettype(System.Int32))
            dt.Columns.Add("TheIcon", Gettype(System.string))
            dt.Columns.Add("GroupName", Gettype(System.string))
            dt.Columns.Add("name", Gettype(System.string))
            dt.Columns.Add("Caption", Gettype(System.string))
            dt.Columns.Add("visibleControl_VAL" , Gettype(System.Int16))
            dt.Columns.Add("visibleControl", Gettype(System.string))
            dt.Columns.Add("controldocmode", Gettype(System.string))
            dt.Columns.Add("otherdocmode", Gettype(System.string))
            dt.Columns.Add("mydocmode", Gettype(System.string))
            dt.Columns.Add("AllObjects_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllObjects", Gettype(System.string))
            dt.Columns.Add("ColegsObject_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ColegsObject", Gettype(System.string))
            dt.Columns.Add("SubStructObjects_VAL" , Gettype(System.Int16))
            dt.Columns.Add("SubStructObjects", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New iu_int_modules
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As bpdi.iu_int_modules
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(bpdi.iu_int_modules))
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
        Public Shadows Function Item( vIndex as object ) As bpdi.iu_int_modules
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("iu_int_modulesID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", sequence" 
           mFieldList =mFieldList+ ", theicon" 
           mFieldList =mFieldList+ ", groupname" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", caption" 
           mFieldList =mFieldList+ ", visiblecontrol" 
           mFieldList =mFieldList+ ", controldocmode" 
           mFieldList =mFieldList+ ", otherdocmode" 
           mFieldList =mFieldList+ ", mydocmode" 
           mFieldList =mFieldList+ ", allobjects" 
           mFieldList =mFieldList+ ", colegsobject" 
           mFieldList =mFieldList+ ", substructobjects" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
