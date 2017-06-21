
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace bpu


''' <summary>
'''Реализация раздела Данные сотрудникав виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class iu_u_def_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "iu_u_def"
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
            dt.TableName="iu_u_def"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("theClient_ID" , GetType(System.guid))
            dt.Columns.Add("theClient", Gettype(System.string))
            dt.Columns.Add("lastname", Gettype(System.string))
            dt.Columns.Add("name", Gettype(System.string))
            dt.Columns.Add("surname", Gettype(System.string))
            dt.Columns.Add("curRole_ID" , GetType(System.guid))
            dt.Columns.Add("curRole", Gettype(System.string))
            dt.Columns.Add("sendtomail_VAL" , Gettype(System.Int16))
            dt.Columns.Add("sendtomail", Gettype(System.string))
            dt.Columns.Add("freelancer_VAL" , Gettype(System.Int16))
            dt.Columns.Add("freelancer", Gettype(System.string))
            dt.Columns.Add("email", Gettype(System.string))
            dt.Columns.Add("thephone", Gettype(System.string))
            dt.Columns.Add("login", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New iu_u_def
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As bpu.iu_u_def
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(bpu.iu_u_def))
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
        Public Shadows Function Item( vIndex as object ) As bpu.iu_u_def
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("iu_u_defID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("theClient") 
           mFieldList =mFieldList+ ", lastname" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", surname" 
           mFieldList =mFieldList+","+.ID2Base("curRole") 
           mFieldList =mFieldList+ ", sendtomail" 
           mFieldList =mFieldList+ ", freelancer" 
           mFieldList =mFieldList+ ", email" 
           mFieldList =mFieldList+ ", thephone" 
           mFieldList =mFieldList+ ", login" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
