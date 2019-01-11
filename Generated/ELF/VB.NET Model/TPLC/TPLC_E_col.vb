
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace TPLC


''' <summary>
'''Реализация раздела Электроэнергияв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLC_E_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "TPLC_E"
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
            dt.TableName="TPLC_E"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("DCALL", GetType(System.DateTime))
            dt.Columns.Add("DCOUNTER", GetType(System.DateTime))
            dt.Columns.Add("E0", GetType(System.double))
            dt.Columns.Add("E1", GetType(System.double))
            dt.Columns.Add("E2", GetType(System.double))
            dt.Columns.Add("E3", GetType(System.double))
            dt.Columns.Add("E4", GetType(System.double))
            dt.Columns.Add("E0S", GetType(System.double))
            dt.Columns.Add("E1S", GetType(System.double))
            dt.Columns.Add("E2S", GetType(System.double))
            dt.Columns.Add("E3S", GetType(System.double))
            dt.Columns.Add("E4S", GetType(System.double))
            dt.Columns.Add("AP", GetType(System.double))
            dt.Columns.Add("AM", GetType(System.double))
            dt.Columns.Add("RP", GetType(System.double))
            dt.Columns.Add("RM", GetType(System.double))
            dt.Columns.Add("I1", GetType(System.double))
            dt.Columns.Add("I2", GetType(System.double))
            dt.Columns.Add("I3", GetType(System.double))
            dt.Columns.Add("U1", GetType(System.double))
            dt.Columns.Add("U2", GetType(System.double))
            dt.Columns.Add("U3", GetType(System.double))
            dt.Columns.Add("OKTIME", GetType(System.double))
            dt.Columns.Add("WORKTIME", GetType(System.double))
            dt.Columns.Add("errInfo", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New TPLC_E
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As TPLC.TPLC_E
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(TPLC.TPLC_E))
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
        Public Shadows Function Item( vIndex as object ) As TPLC.TPLC_E
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("TPLC_EID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.Date2Base("DCALL") 
           mFieldList =mFieldList+","+.Date2Base("DCOUNTER") 
           mFieldList =mFieldList+ ", e0" 
           mFieldList =mFieldList+ ", e1" 
           mFieldList =mFieldList+ ", e2" 
           mFieldList =mFieldList+ ", e3" 
           mFieldList =mFieldList+ ", e4" 
           mFieldList =mFieldList+ ", e0s" 
           mFieldList =mFieldList+ ", e1s" 
           mFieldList =mFieldList+ ", e2s" 
           mFieldList =mFieldList+ ", e3s" 
           mFieldList =mFieldList+ ", e4s" 
           mFieldList =mFieldList+ ", ap" 
           mFieldList =mFieldList+ ", am" 
           mFieldList =mFieldList+ ", rp" 
           mFieldList =mFieldList+ ", rm" 
           mFieldList =mFieldList+ ", i1" 
           mFieldList =mFieldList+ ", i2" 
           mFieldList =mFieldList+ ", i3" 
           mFieldList =mFieldList+ ", u1" 
           mFieldList =mFieldList+ ", u2" 
           mFieldList =mFieldList+ ", u3" 
           mFieldList =mFieldList+ ", oktime" 
           mFieldList =mFieldList+ ", worktime" 
           mFieldList =mFieldList+ ", errinfo" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
